using AutoMapper;
using Azure.Core;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using UserAPI.DTOs;
using UserAPI.Helper;
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
        private readonly ITokenService _tokenService;
        private readonly IAiService _aiService;
        private readonly ILogger<UserService> _logger;

        public UserService(IConfiguration config, IUserRepository userRepository,  IMapper mapper, ITokenService tokenService, 
            IRefreshTokenRepository refreshTokenRepository, IAiService aiService, ILogger<UserService> logger)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _tokenService = tokenService;
            _refreshTokenRepository = refreshTokenRepository;
            _aiService = aiService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> AddorUpdateFaceEmbeddings(int userId, FaceImagesDTO faceImagesDTO)
        {
            // 1. Lấy user từ DB
            var user = await  _userRepository.GetUserByIdAsync(userId);
            if(user == null)
            {
                throw new InvalidOperationException("Không tìm thấy người dùng.");
            }

            // 2. Gọi AI Service để lấy embeddings
            AiFaceRegisterResponseModel? aiResponse = null;
            if (faceImagesDTO.FaceImages != null)
            {
                try
                {
                    aiResponse = await _aiService.RegisterFaceAsync(faceImagesDTO.FaceImages, user.Email);
                    if (aiResponse == null || !aiResponse.Success || aiResponse.Embeddings == null || aiResponse.Embeddings.Count != 5)
                    {
                        throw new Exception("Không lấy được embeddings từ AI server.");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "AIService đã ném ra một lỗi hệ thống trong quá trình thêm/cập nhật embeddings của userId {UserId}.", userId);
                    throw new Exception("Hệ thống xác thực khuôn mặt đang gặp sự cố. Vui lòng thử lại sau.");
                }
            }

            // 3. Chuyển embeddings sang JSON string để lưu vào DB
            string? embeddingsJson = null;
            if (aiResponse?.Embeddings != null)
            {
                embeddingsJson = System.Text.Json.JsonSerializer.Serialize(aiResponse.Embeddings);
            }
            user.FaceEmbeddingsJson = embeddingsJson;

            // 4. Cập nhật vào DB
            var updatedUser = await _userRepository.UpdateUserAsync(user);
            return updatedUser != null;
        }

        public async Task<PrivateUserProfileDTO> UpdateUserProfileAsync(UpdateUserProfileDTO updateUserProfileDTO)
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
            user.Gender = updateUserProfileDTO.Gender;
            user.DateOfBirth = string.IsNullOrEmpty(updateUserProfileDTO.DateOfBirth) ? null : DateHelper.Parse(updateUserProfileDTO.DateOfBirth);

            // Cập nhật thông tin vào DB
            var updatedUser = await _userRepository.UpdateUserAsync(user);
            if (updatedUser == null)
            {
                throw new InvalidOperationException("Failed to update user profile.");
            }

            // Chuyển đổi sang ReadUserDTO
            return _mapper.Map<PrivateUserProfileDTO>(updatedUser);
        }

        public async Task<PrivateUserProfileDTO> UpdateAvatarAsync(UpdateAvatarDTO updateAvatarDTO)
        {
            var user = await _userRepository.GetUserByIdAsync(updateAvatarDTO.UserId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            // Nếu không có avatar mới, giữ nguyên avatar cũ
            if (updateAvatarDTO.Avatar == null || updateAvatarDTO.Avatar.Length == 0)
            {
                return _mapper.Map<PrivateUserProfileDTO>(user);
            }

            // Tạo thư mục uploads/avatars/{email_sanitized}
            string safeEmail = user.Email.Replace("@", "_at_").Replace(".", "_dot_");
            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "avatars", safeEmail);
            Directory.CreateDirectory(uploadFolder);

            // Xóa file avatar cũ nếu có (và không phải default avatar)
            if (!string.IsNullOrEmpty(user.AvatarUrl) && !user.AvatarUrl.Contains("default-avatar.png"))
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
            user.AvatarUrl = $"/uploads/avatars/{safeEmail}/{avatarFileName}";

            // Cập nhật thông tin vào DB
            var updatedUser = await _userRepository.UpdateUserAsync(user);
            if (updatedUser == null)
            {
                throw new InvalidOperationException("Failed to update avatar.");
            }

            // Chuyển đổi sang DTO
            return _mapper.Map<PrivateUserProfileDTO>(updatedUser);
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
                    Message = "Email và Password không được để trống! "
                };
            }

            var user = await _userRepository.GetUserByEmailAsync(loginRequestDTO.Email);
            if (user == null)
            {
                return new LoginResponseDTO
                { 
                    IsValid = false,
                    Message = "Email này chưa từng có tài khoảng! "
                };
            }

            if (!VerifyPassword(loginRequestDTO.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new LoginResponseDTO
                {
                    IsValid = false,
                    Message = "Email hoặc mật khẩu không chính xác! "
                };
            }

            if(loginRequestDTO.Role != null && loginRequestDTO.Role != user.Role)
            {
                return new LoginResponseDTO
                {
                    IsValid = false,
                    Message = "Tài khoảng của bạn không được phép vào hệ thống này! "
                };
            }

            if(!user.IsActive)
            {
                return new LoginResponseDTO
                {
                    IsValid = false,
                    Message = "Tài khoảng của bạn đã bị khóa!"
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
                AvatarUrl = user.AvatarUrl
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
                AvatarUrl = user.AvatarUrl
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

        public async Task<PrivateUserProfileDTO> CustomerRegisterAsync(CustomerRegisterRequestDTO registerDto)
        {
            // 1.Check email tồn tại
            if (await IsEmailExistsAsync(registerDto.Email))
            {
                throw new InvalidOperationException("Email already exists.");
            }

            // 2. Gọi AI Service để đăng ký khuôn mặt và lấy 5 embeddings từ 5 ảnh
            AiFaceRegisterResponseModel? aiResponse = null;
            if (registerDto.FaceImages != null)
            {
                try
                {
                    aiResponse = await _aiService.RegisterFaceAsync(registerDto.FaceImages, registerDto.Email);
                    if (aiResponse == null || !aiResponse.Success || aiResponse.Embeddings == null || aiResponse.Embeddings.Count != 5)
                    {
                        throw new Exception("Không lấy được embeddings từ AI server.");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "AIService đã ném ra một lỗi hệ thống trong quá trình đăng ký của email {Email}.", registerDto.Email);
                    throw new Exception("Hệ thống xác thực khuôn mặt đang gặp sự cố. Vui lòng thử lại sau.");
                }
            }

            // 3. Hash password
            CreatePasswordHash(registerDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            // 4. Chuẩn bị thư mục lưu file (theo email)
            string safeEmail = registerDto.Email.Replace("@", "_at_").Replace(".", "_dot_");

            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            string avatarFolder = Path.Combine(uploadFolder, "avatars", safeEmail);

            Directory.CreateDirectory(avatarFolder);

            string? avatarUrl = null;

            // 4.1 Lưu Avatar
            if (registerDto.Avatar != null && registerDto.Avatar.Length > 0)
            {
                string avatarFileName = $"{Guid.NewGuid()}{Path.GetExtension(registerDto.Avatar.FileName)}";
                string avatarPath = Path.Combine(avatarFolder, avatarFileName);

                using (var stream = new FileStream(avatarPath, FileMode.Create))
                {
                    await registerDto.Avatar.CopyToAsync(stream);
                }
                avatarUrl = $"/uploads/avatars/{safeEmail}/{avatarFileName}";
            }
            else
            {
                avatarUrl = "/uploads/avatars/default-avatar.png";
            }

            // 4.2 Chuyển embeddings sang JSON string để lưu vào DB
            string? embeddingsJson = null;
            if (aiResponse?.Embeddings != null)
            {
                embeddingsJson = System.Text.Json.JsonSerializer.Serialize(aiResponse.Embeddings);
            }

            // 5. Tạo entity User
            var user = new User
            {
                FullName = registerDto.FullName,
                Email = registerDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = "Customer",
                Address = registerDto.Address,
                PhoneNumber = registerDto.PhoneNumber,
                Gender = registerDto.Gender,
                DateOfBirth = string.IsNullOrEmpty(registerDto.DateOfBirth) ? null : DateHelper.Parse(registerDto.DateOfBirth),
                AvatarUrl = avatarUrl,
                FaceEmbeddingsJson = embeddingsJson,
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            // 6. Lưu vào DB
            await _userRepository.CreateUserAsync(user);

            // 7. Map sang ReadUserDTO
            return _mapper.Map<PrivateUserProfileDTO>(user);
        }

        public async Task<PrivateUserProfileDTO> StadiumManagerRegisterAsync(StadiumManagerRegisterRequestDTO registerDto)
        {
            // 1. Check email tồn tại
            if (await IsEmailExistsAsync(registerDto.Email))
            {
                throw new InvalidOperationException("Email đã tồn tại.");
            }

            // 2. Gọi AI Server để xác thực CCCD
            if (registerDto.FrontCCCDImage == null || registerDto.FrontCCCDImage.Length == 0)
            {
                throw new InvalidOperationException("Cần cung cấp ảnh CCCD mặt trước để đăng ký.");
            }

            // 2. Gọi AI cho ảnh MẶT TRƯỚC
            AiCccdResponseModel? aiData;
            try
            {
                _logger.LogInformation("Đang gửi ảnh CCCD của email {Email} đến AI Service để xác thực.", registerDto.Email);
                aiData = await _aiService.ExtractInfoFromFrontCCCDImage(registerDto.FrontCCCDImage);
            }
            catch (Exception ex)
            {
                // Bắt các lỗi hệ thống từ AIService (mất kết nối, server AI lỗi 500...)
                _logger.LogError(ex, "AIService đã ném ra một lỗi hệ thống trong quá trình đăng ký của email {Email}.", registerDto.Email);
                throw new Exception("Hệ thống xác thực đang gặp sự cố. Vui lòng thử lại sau.");
            }

            // Kiểm tra kết quả trả về từ AI Service
            if (aiData == null)
            {
                // Trường hợp này xảy ra khi AIService xác định ảnh không hợp lệ (ví dụ: AI trả về JSON rỗng)
                _logger.LogWarning("AI Service không thể trích xuất dữ liệu từ ảnh CCCD của email {Email}.", registerDto.Email);
                throw new InvalidOperationException("Không thể xác thực thông tin từ ảnh CCCD. Vui lòng sử dụng ảnh rõ nét và hợp lệ.");
            }
            _logger.LogInformation("Xác thực CCCD qua AI thành công cho email {Email}.", registerDto.Email);

            // Kiểm tra các thông tin quan trọng từ AI
            var idFromAI = aiData.Id?.FirstOrDefault();
            var fullNameFromAI = aiData.Name?.FirstOrDefault();
            var dobFromAI = aiData.DateOfBirth?.FirstOrDefault();
            var genderFromAI = aiData.Gender?.FirstOrDefault();
            var originPlaceFromAI = aiData.OriginPlace?.FirstOrDefault();
            var currentPlaceFromAI = aiData.CurrentPlace?.FirstOrDefault();

            var fullAddress = string.Join(", ", aiData.CurrentPlace ?? new List<string>());


            // Kiểm tra các trường thông tin quan trọng
            if (string.IsNullOrWhiteSpace(fullNameFromAI) || string.IsNullOrWhiteSpace(dobFromAI))
            {
                throw new InvalidOperationException("Thông tin trích xuất từ CCCD không đầy đủ (thiếu tên hoặc ngày sinh).");
            }

            // Kiểm tra tuổi (ví dụ: phải trên 18 tuổi)
            var dateOfBirth = DateHelper.Parse(dobFromAI, "dd/MM/yyyy"); // Giả sử bạn có một hàm helper để parse ngày tháng
            if (dateOfBirth == null || (DateTime.UtcNow.Year - dateOfBirth.Year) < 18)
            {
                throw new InvalidOperationException("Người dùng phải từ 18 tuổi trở lên.");
            }

            // 2. Hash password
            CreatePasswordHash(registerDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            // 3. Lưu file frontCCCD & RearCCCD theo email
            string? frontCCCDUrl = null;
            string? rearCCCDUrl = null;
            string? avatarUrl = null;

            // Sanitize email để dùng làm tên thư mục
            string safeEmail = registerDto.Email.Replace("@", "_at_").Replace(".", "_dot_");

            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            string cccdFolder = Path.Combine(uploadFolder, "cccd", safeEmail);
            string avatarFolder = Path.Combine(uploadFolder, "avatars", safeEmail);

            Directory.CreateDirectory(cccdFolder);
            Directory.CreateDirectory(avatarFolder);

            if (registerDto.FrontCCCDImage != null && registerDto.FrontCCCDImage.Length > 0)
            {
                string frontFileName = $"front_{Guid.NewGuid()}{Path.GetExtension(registerDto.FrontCCCDImage.FileName)}";
                string frontPath = Path.Combine(cccdFolder, frontFileName);

                using (var stream = new FileStream(frontPath, FileMode.Create))
                {
                    await registerDto.FrontCCCDImage.CopyToAsync(stream);
                }
                frontCCCDUrl = $"/uploads/cccd/{safeEmail}/{frontFileName}";
            }

            if (registerDto.RearCCCDImage != null && registerDto.RearCCCDImage.Length > 0)
            {
                string rearFileName = $"rear_{Guid.NewGuid()}{Path.GetExtension(registerDto.RearCCCDImage.FileName)}";
                string rearPath = Path.Combine(cccdFolder, rearFileName);

                using (var stream = new FileStream(rearPath, FileMode.Create))
                {
                    await registerDto.RearCCCDImage.CopyToAsync(stream);
                }
                rearCCCDUrl = $"/uploads/cccd/{safeEmail}/{rearFileName}";
            }

            if (registerDto.Avatar != null && registerDto.Avatar.Length > 0)
            {
                string avatarFileName = $"{Guid.NewGuid()}{Path.GetExtension(registerDto.Avatar.FileName)}";
                string avatarPath = Path.Combine(avatarFolder, avatarFileName);

                using (var stream = new FileStream(avatarPath, FileMode.Create))
                {
                    await registerDto.Avatar.CopyToAsync(stream);
                }
                avatarUrl = $"/uploads/avatars/{safeEmail}/{avatarFileName}";
            }
            else
            {
                avatarUrl = "/uploads/avatars/default-avatar.png";
            }

            // 4. Tạo entity User
            var user = new User
            {
                FullName = fullNameFromAI,
                Email = registerDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = "StadiumManager",
                Address = fullAddress,
                PhoneNumber = registerDto.PhoneNumber,
                Gender = genderFromAI,
                DateOfBirth = dateOfBirth,
                AvatarUrl = avatarUrl,
                IdentityNumber = idFromAI,
                FrontCCCDUrl = frontCCCDUrl,
                RearCCCDUrl = rearCCCDUrl,
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            // 5. Lưu vào DB
            await _userRepository.CreateUserAsync(user);

            // 6. Map sang ReadUserDTO
            return _mapper.Map<PrivateUserProfileDTO>(user);
        }

        public async Task<bool> IsEmailExistsAsync(string email)
        {
           var user = await _userRepository.GetUserByEmailAsync(email);
            return user != null;
        }

        public async Task<PrivateUserProfileDTO> GetUserProfileAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return null!;
            }
            return _mapper.Map<PrivateUserProfileDTO>(user);
        }

        public async Task<PublicUserProfileDTO> GetOtherUserProfileAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return null!;
            }
            return _mapper.Map<PublicUserProfileDTO>(user);
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO)
        {
            var user = await _userRepository.GetUserByEmailAsync(resetPasswordDTO.Email);
            if (user == null)
            {
                return false;
            }

            // Cập nhật mật khẩu mới
            CreatePasswordHash(resetPasswordDTO.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return await _userRepository.UpdateUserAsync(user) != null;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }

        public async Task<LoginResponseDTO> LoginOrRegisterWithGoogleAsync(GoogleUserInfoDTO googleUser)
        {
            // 1. Tìm người dùng bằng email
            var user = await _userRepository.GetUserByEmailAsync(googleUser.Email);
            bool isNewUser = false;

            if (user == null)
            {
                // 2. Nếu không có -> Tạo người dùng mới
                isNewUser = true;
                user = new User
                {
                    FullName = googleUser.FullName,
                    Email = googleUser.Email,
                    GoogleId = googleUser.GoogleId,
                    Provider = "google",
                    Role = "Customer", // Mặc định là Customer (chỉ Customer mới được dùng Google Login)
                    IsActive = true, // Kích hoạt tài khoản ngay lập tức
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    AvatarUrl = "/uploads/avatars/default-avatar.png" // Bắt đầu với avatar mặc định
                };

                // Không cần tạo password hash vì họ sẽ luôn đăng nhập qua Google
                // Nếu logic yêu cầu password, bạn có thể tạo một chuỗi ngẫu nhiên
                CreatePasswordHash(Guid.NewGuid().ToString(), out byte[] hash, out byte[] salt);
                user.PasswordHash = hash;
                user.PasswordSalt = salt;

                await _userRepository.CreateUserAsync(user);
            }
            else
            {
                // 3. Nếu có -> Liên kết tài khoản nếu cần

                // Chỉ cho phép đăng nhập nếu là Customer
                if (user.Role != "Customer")
                {
                    return new LoginResponseDTO { IsValid = false, Message = "Tài khoản với vai trò quản trị không được phép đăng nhập bằng Google." };
                }

                // Kiểm tra nếu tài khoản bị khóa
                if (user.IsActive == false)
                {
                    return new LoginResponseDTO { IsValid = false, Message = "Tài khoản của bạn đã bị khóa." };
                }

                // Cập nhật GoogleId và Provider nếu chưa có
                if (string.IsNullOrEmpty(user.GoogleId))
                {
                    user.GoogleId = googleUser.GoogleId;
                    user.Provider = string.IsNullOrEmpty(user.Provider) ? "google" : $"{user.Provider},google";
                    await _userRepository.UpdateUserAsync(user);
                }
            }

            // 4. Tạo Access Token và Refresh Token của hệ thống bạn
            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            // 5. Lưu Refresh Token
            var refreshTokenEntity = new RefreshToken
            {
                Token = refreshToken,
                UserId = user.UserId,
                ExpiryDate = DateTime.UtcNow.AddDays(int.Parse(_config["Jwt:RefreshTokenExpiresDays"]!)),
                CreatedDate = DateTime.UtcNow
            };
            await _refreshTokenRepository.CreateRefreshTokenAsync(refreshTokenEntity);

            // 6. Trả về kết quả
            return new LoginResponseDTO
            {
                IsValid = true,
                Message = isNewUser ? "Đăng ký bằng Google thành công!" : "Đăng nhập bằng Google thành công!",
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                AccessTokenExpiresAt = DateTime.UtcNow.AddMinutes(int.Parse(_config["Jwt:AccessTokenExpiresMinutes"]!)),
                UserId = user.UserId,
                FullName = user.FullName,
                AvatarUrl = user.AvatarUrl
            };
        }

        public async Task<AdminUserStatsDTO> GetAdminUserStatsAsync()
        {
            return await _userRepository.GetAdminUserStatsAsync();
        }

        public async Task BanUserAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            user.IsActive = false;
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task UnbanUserAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            user.IsActive = true;
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task<LoginResponseDTO> LoginWithFaceAsync(AiFaceLoginRequestDTO aiFaceLoginRequestDTO)
        {
            // 1. Validate input
            if (aiFaceLoginRequestDTO.FaceImage == null || aiFaceLoginRequestDTO.FaceImage.Length == 0)
            {
                throw new ArgumentException("Ảnh khuôn mặt không hợp lệ.", nameof(aiFaceLoginRequestDTO.FaceImage));
            }

            // 2. Lấy tất cả user có embeddings
            var usersWithEmbeddings = await _userRepository.GetAllUserEmbeddingsAsync();

            if (usersWithEmbeddings == null || usersWithEmbeddings.Count == 0)
            {
                return new LoginResponseDTO
                {
                    IsValid = false,
                    Message = "Hệ thống chưa có người dùng nào được đăng ký khuôn mặt. Vui lòng đăng ký trước khi đăng nhập bằng khuôn mặt."
                };
            }

            // 3. Gọi AI Service để xác thực khuôn mặt
            AiFaceLoginResponseModel? aiResponse;
            try
            {
                aiResponse = await _aiService.LoginWithFaceAsync(aiFaceLoginRequestDTO.FaceImage, usersWithEmbeddings);

                if (aiResponse == null || !aiResponse.Success || aiResponse.Email == null)
                {
                    return new LoginResponseDTO
                    {
                        IsValid = false,
                        Message = aiResponse.Message ?? "Xác thực khuôn mặt thất bại hoặc không khớp dữ liệu."
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AIService đã ném ra một lỗi hệ thống trong quá trình đăng nhập khuôn mặt.");
                return new LoginResponseDTO
                {
                    IsValid = false,
                    Message = "Hệ thống xác thực khuôn mặt đang gặp sự cố. Vui lòng thử lại sau."
                };
            }
           
            // 4. Tìm user theo email trả về từ AI
            var user = await _userRepository.GetUserByEmailAsync(aiResponse.Email);
            if (user == null)
            {
                return new LoginResponseDTO
                {
                    IsValid = false,
                    Message = "Không tìm thấy người dùng với email được xác thực từ khuôn mặt."
                };
            }

            // 5. Kiểm tra vai trò (chỉ Customer được phép đăng nhập bằng khuôn mặt)
            if (user.Role != "Customer")
            {
                return new LoginResponseDTO
                {
                    IsValid = false,
                    Message = "Tài khoản với vai trò quản trị không được phép đăng nhập bằng khuôn mặt."
                };
            }

            // 6. Kiểm tra trạng thái tài khoản
            if (!user.IsActive)
            {
                return new LoginResponseDTO
                {
                    IsValid = false,
                    Message = "Tài khoản của bạn đã bị khóa."
                };
            }

            // 7. Tạo Access Token và Refresh Token
            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();
            var refreshTokenEntity = new RefreshToken
            {
                Token = refreshToken,
                UserId = user.UserId,
                ExpiryDate = DateTime.UtcNow.AddDays(int.Parse(_config["Jwt:RefreshTokenExpiresDays"]!)),
                CreatedDate = DateTime.UtcNow
            };
            await _refreshTokenRepository.CreateRefreshTokenAsync(refreshTokenEntity);

            // 8. Trả về kết quả
            return new LoginResponseDTO
            {
                IsValid = true,
                Message = "Đăng nhập bằng khuôn mặt thành công!",
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                AccessTokenExpiresAt = DateTime.UtcNow.AddMinutes(int.Parse(_config["Jwt:AccessTokenExpiresMinutes"]!)),
                UserId = user.UserId,
                FullName = user.FullName,
                AvatarUrl = user.AvatarUrl
            };
        }

        public async Task<UserStatisticsDTO> GetUserStatisticsAsync()
        {
            return await _userRepository.GetUserStatisticsAsync();
        }
    }
}
