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
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IMapper _mapper;
        private ITokenService _tokenService;

        public UserService(IConfiguration config, IUserRepository userRepository,  IMapper mapper, ITokenService tokenService, IRefreshTokenRepository refreshTokenRepository)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _tokenService = tokenService;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<ReadUserDTO> UpdateUserProfileAsync(UpdateUserProfileDTO updateUserProfileDTO)
        {
            var user = await _userRepository.GetUserByIdAsync(updateUserProfileDTO.UserId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            // Cập nhật thông tin người dùng
            user.FullName = updateUserProfileDTO.FullName;
            user.Email = updateUserProfileDTO.Email;
            user.Address = updateUserProfileDTO.Address;
            user.PhoneNumber = updateUserProfileDTO.PhoneNumber;

            // Cập nhật thông tin vào DB
            var updatedUser = await _userRepository.UpdateUserAsync(user);
            if (updatedUser == null)
            {
                throw new InvalidOperationException("Failed to update user profile.");
            }

            // Chuyển đổi sang ReadUserDTO
            return _mapper.Map<ReadUserDTO>(updatedUser);
        }

        public async Task<ReadUserDTO> UpdateAvatarAsync(UpdateAvatarDTO updateAvatarDTO)
        {
            var user = await _userRepository.GetUserByIdAsync(updateAvatarDTO.UserId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            // Nếu không có avatar mới, giữ nguyên avatar cũ
            if (updateAvatarDTO.Avatar == null || updateAvatarDTO.Avatar.Length == 0)
            {
                return _mapper.Map<ReadUserDTO>(user);
            }

            // Lưu file avatar vào thư mục uploads/avatars
            // Xóa file hình cũ nếu có
            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "avatars");
            Directory.CreateDirectory(uploadFolder); // Tạo thư mục nếu chưa tồn tại
            if (updateAvatarDTO.Avatar != null && updateAvatarDTO.Avatar.Length > 0)
            {
                // Xóa file avatar cũ nếu có
                if (!string.IsNullOrEmpty(user.AvatarUrl))
                {
                    string oldAvatarPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", user.AvatarUrl.TrimStart('/'));
                    if (File.Exists(oldAvatarPath))
                    {
                        File.Delete(oldAvatarPath);
                    }
                }

                // Lưu file avatar mới
                string avatarFileName = $"{Guid.NewGuid()}{Path.GetExtension(updateAvatarDTO.Avatar.FileName)}";
                string avatarPath = Path.Combine(uploadFolder, avatarFileName);

                using (var stream = new FileStream(avatarPath, FileMode.Create))
                {
                    await updateAvatarDTO.Avatar.CopyToAsync(stream);
                }

                // Cập nhật URL avatar trong user
                user.AvatarUrl = $"/uploads/avatars/{avatarFileName}";
            }


            // Cập nhật thông tin vào DB
            var updatedUser = await _userRepository.UpdateUserAsync(user);
            if (updatedUser == null)
            {
                throw new InvalidOperationException("Failed to update avatar.");
            }
            // Chuyển đổi sang ReadUserDTO
            return _mapper.Map<ReadUserDTO>(updatedUser);
        }

        public async Task<ReadUserDTO> UpdateFaceImageAsync(UpdateFaceImageDTO updateFaceImageDTO)
        {
            var user = await _userRepository.GetUserByIdAsync(updateFaceImageDTO.UserId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            // Nếu không có face image mới, giữ nguyên face image cũ
            if (updateFaceImageDTO.FaceImage == null || updateFaceImageDTO.FaceImage.Length == 0)
            {
                return _mapper.Map<ReadUserDTO>(user);
            }

            // Lưu file face image vào thư mục uploads/faces
            // Xóa file hình cũ nếu có
            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "faces");
            Directory.CreateDirectory(uploadFolder); // Tạo thư mục nếu chưa tồn tại
            if (updateFaceImageDTO.FaceImage != null && updateFaceImageDTO.FaceImage.Length > 0)
            {
                // Xóa file face image cũ nếu có
                if (!string.IsNullOrEmpty(user.FaceImageUrl))
                {
                    string oldFaceImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", user.FaceImageUrl.TrimStart('/'));
                    if (File.Exists(oldFaceImagePath))
                    {
                        File.Delete(oldFaceImagePath);
                    }
                }

                // Lưu file face image mới
                string faceFileName = $"{Guid.NewGuid()}{Path.GetExtension(updateFaceImageDTO.FaceImage.FileName)}";
                string facePath = Path.Combine(uploadFolder, faceFileName);

                using (var stream = new FileStream(facePath, FileMode.Create))
                {
                    await updateFaceImageDTO.FaceImage.CopyToAsync(stream);
                }

                // Cập nhật URL face image trong user
                user.FaceImageUrl = $"/uploads/faces/{faceFileName}";
            }

            // Cập nhật thông tin vào DB
            var updatedUser = await _userRepository.UpdateUserAsync(user);
            if (updatedUser == null)
            {
                throw new InvalidOperationException("Failed to update face image.");
            }
            // Chuyển đổi sang ReadUserDTO
            return _mapper.Map<ReadUserDTO>(updatedUser);
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
                ExpiryDate = DateTime.UtcNow.AddDays(int.Parse(_config["Jwt:RefreshTokenExpiresDays"]!)),
                CreatedDate = DateTime.UtcNow
            };
            await _refreshTokenRepository.CreateRefreshTokenAsync(refreshTokenEntity);

            return new LoginResponseDTO
            {
                IsValid = true,
                Message = "Login successful.",
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                AccessTokenExpiresAt = DateTime.UtcNow.AddMinutes(int.Parse(_config["Jwt:AccessTokenExpiresMinutes"]!)),
                UserId = user.UserId,
                FullName = user.FullName, 
                AvatarUrl = user.AvatarUrl,
                FaceImageUrl = user.FaceImageUrl
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
            savedToken.ExpiryDate = DateTime.UtcNow.AddDays(int.Parse(_config["Jwt:RefreshTokenExpiresDays"]!));
            await _refreshTokenRepository.UpdateRefreshTokenAsync(savedToken);

            // 5. Trả về token mới
            return new LoginResponseDTO
            {
                IsValid = true,
                Message = "Login successful.",
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
                AccessTokenExpiresAt = DateTime.UtcNow.AddMinutes(int.Parse(_config["Jwt:AccessTokenExpiresMinutes"]!)),
                FullName = user.FullName,
                AvatarUrl = user.AvatarUrl,
                FaceImageUrl = user.FaceImageUrl
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
            } else
            {
                avatarUrl = "/uploads/avatars/default-avatar.png"; // Default avatar if not provided
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
            } else
            {
                faceImageUrl = null;
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

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }
    }
}
