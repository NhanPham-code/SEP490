using AutoMapper;
using Azure.Core;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using UserAPI.DTOs;
using UserAPI.Model;
using UserAPI.Repository.Interface;
using UserAPI.Service.Interface;

namespace UserAPI.Service
{
    public class UserService : IUserService
    {

        private static readonly int EXP_TIME_OF_REFRESH_TOKEN = 7;

        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IMapper _mapper;
        private TokenService _tokenService;

        public UserService(IUserRepository userRepository,  IMapper mapper, TokenService tokenService, IRefreshTokenRepository refreshTokenRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _tokenService = tokenService;
            _refreshTokenRepository = refreshTokenRepository;
        }

        private bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
        {
            using var hmac = new HMACSHA512(storedSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(storedHash);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key; // tự động sinh salt
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public IQueryable<User> GetAllUsersForOData()
        {
            return _userRepository.GetAllUsers();
        }

        public async Task<LoginResponseDTO> CheckLoginAsync(LoginRequestDTO loginRequestDTO)
        {
            if(string.IsNullOrEmpty(loginRequestDTO.Email) || string.IsNullOrEmpty(loginRequestDTO.Password))
            {
                return new LoginResponseDTO 
                {
                    IsValid = false,
                    Message = "Email and password cannot be empty."
                };
            }

            var user = await _userRepository.GetUserByEmailAsync(loginRequestDTO.Email);
            if (user == null)
            {
                return new LoginResponseDTO
                { 
                    IsValid = false,
                    Message = "Invalid email or password! "
                };
            }

            if (!VerifyPassword(loginRequestDTO.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new LoginResponseDTO
                {
                    IsValid = false,
                    Message = "Invalid email or password! "
                };
            }

            if(loginRequestDTO.Role != null && loginRequestDTO.Role != user.Role)
            {
                return new LoginResponseDTO
                {
                    IsValid = false,
                    Message = "Invalid email or password! "
                };
            }

            if(!user.IsActive)
            {
                return new LoginResponseDTO
                {
                    IsValid = false,
                    Message = "Your account is banned!"
                };
            }

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            // Save refresh token to DB
            var refreshTokenEntity = new RefreshToken
            {
                Token = refreshToken,
                UserId = user.UserId,
                ExpiryDate = DateTime.UtcNow.AddDays(EXP_TIME_OF_REFRESH_TOKEN),
                CreatedDate = DateTime.UtcNow
            };
            await _refreshTokenRepository.CreateRefreshTokenAsync(refreshTokenEntity);

            return new LoginResponseDTO
            {
                IsValid = true,
                Message = "Login successful.",
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                FullName = user.FullName
            };
        }

        public async Task<LoginResponseDTO> RefreshTokenAsync(RefreshTokenRequestDTO request)
        {
            // 1. Giải mã Access Token đã hết hạn để lấy thông tin người dùng
            var principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            if (principal == null)
            {
                return new LoginResponseDTO
                {
                    IsValid = false,
                    Message = "Invalid access token."
                };
            }

            var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                return new LoginResponseDTO
                {
                    IsValid = false,
                    Message = "Invalid access token claims."
                };
            }

            // 2. Lấy user và refresh token từ DB
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null || !user.IsActive)
            {
                return new LoginResponseDTO
                {
                    IsValid = false,
                    Message = "User not found or deactivated."
                };
            }

            var savedToken = await _refreshTokenRepository.GetRefreshTokenAsync(userId, request.RefreshToken);
            if (savedToken == null || savedToken.ExpiryDate < DateTime.UtcNow)
            {
                return new LoginResponseDTO
                {
                    IsValid = false,
                    Message = "Refresh token is invalid or expired."
                };
            }

            // 3. Sinh token mới
            var newAccessToken = _tokenService.GenerateAccessToken(user);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            // 4. Cập nhật refresh token - lưu vào DB -
            // Giúp chống việc lạm dụng token cũ (mỗi Refresh Token chỉ được dùng 1 lần)
            savedToken.Token = newRefreshToken;
            savedToken.CreatedDate = DateTime.UtcNow;
            savedToken.ExpiryDate = DateTime.UtcNow.AddDays(EXP_TIME_OF_REFRESH_TOKEN);
            await _refreshTokenRepository.UpdateRefreshTokenAsync(savedToken);

            // 5. Trả về token mới
            return new LoginResponseDTO
            {
                IsValid = true,
                Message = "Token refreshed successfully.",
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
                FullName = user.FullName
            };
        }

        public async Task<LogoutResponseDTO> LogoutAsync(LogoutRequestDTO logoutRequestDTO)
        {
            // Giải mã Access Token để lấy thông tin người dùng
            var principal = _tokenService.GetPrincipalFromExpiredToken(logoutRequestDTO.AccessToken);
            if (principal == null)
            {
                return new LogoutResponseDTO
                {
                    IsValid = false,
                    Message = "Invalid access token."
                };
            }

            var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                return new LogoutResponseDTO { IsValid = false, Message = "Invalid access token." };
            }

            // Xóa Refresh Token khỏi DB (1 lần logout sẽ xóa 1 refresh token của thiết bị hiện tại)
            var deleteResult = await _refreshTokenRepository.DeleteRefreshTokenAsync(userId, logoutRequestDTO.RefreshToken);
            if (!deleteResult)
            {
                return new LogoutResponseDTO
                {
                    IsValid = false,
                    Message = "Failed to logout. Refresh token not found or invalid."
                };
            }

            return new LogoutResponseDTO
            {
                IsValid = true,
                Message = "Logout successful."
            };
        }

        public async Task<ReadUserDTO> RegisterAsync(RegisterRequestDTO registerDto)
        {
            // 1. Check email tồn tại
            if (await IsEmailExistsAsync(registerDto.Email))
            {
                throw new InvalidOperationException("Email already exists.");
            }

            // 2. Hash password
            CreatePasswordHash(registerDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            // 3. Lưu file avatar & face image
            string? avatarUrl = null;
            string? faceImageUrl = null;

            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            Directory.CreateDirectory(Path.Combine(uploadFolder, "avatars"));
            Directory.CreateDirectory(Path.Combine(uploadFolder, "faces"));

            if (registerDto.Avatar != null && registerDto.Avatar.Length > 0)
            {
                string avatarFileName = $"{Guid.NewGuid()}{Path.GetExtension(registerDto.Avatar.FileName)}";
                string avatarPath = Path.Combine(uploadFolder, "avatars", avatarFileName);

                using (var stream = new FileStream(avatarPath, FileMode.Create))
                {
                    await registerDto.Avatar.CopyToAsync(stream);
                }
                avatarUrl = $"/uploads/avatars/{avatarFileName}";
            }

            if (registerDto.FaceImage != null && registerDto.FaceImage.Length > 0)
            {
                string faceFileName = $"{Guid.NewGuid()}{Path.GetExtension(registerDto.FaceImage.FileName)}";
                string facePath = Path.Combine(uploadFolder, "faces", faceFileName);

                using (var stream = new FileStream(facePath, FileMode.Create))
                {
                    await registerDto.FaceImage.CopyToAsync(stream);
                }
                faceImageUrl = $"/uploads/faces/{faceFileName}";
            }

            // 4. Tạo entity User
            var user = new User
            {
                FullName = registerDto.FullName,
                Email = registerDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = registerDto.Role,
                Address = registerDto.Address,
                PhoneNumber = registerDto.PhoneNumber,
                AvatarUrl = avatarUrl,
                FaceImageUrl = faceImageUrl,
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            };

            // 5. Lưu vào DB
            await _userRepository.CreateUserAsync(user);

            // 6. Map sang ReadUserDTO
            return _mapper.Map<ReadUserDTO>(user);
        }

        public async Task<bool> IsEmailExistsAsync(string email)
        {
           var user = await _userRepository.GetUserByEmailAsync(email);
            return user != null;
        }

        public async Task<ReadUserDTO> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return null!;
            }
            return _mapper.Map<ReadUserDTO>(user);
        }

        public Task<bool> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ReadUserDTO> CreateUserAsync(RegisterRequestDTO createUserDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ReadUserDTO> UpdateUserAsync(UpdateUserProfileDTO updateUserProfileDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }
    }
}
