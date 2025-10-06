using UserAPI.DTOs;
using UserAPI.Model;
using UserAPI.Repository;
using UserAPI.Repository.Interface;
using UserAPI.Service.Interface;

namespace UserAPI.Service
{
    public class BiometricCredentialService : IBiometricCredentialService
    {
        private readonly IConfiguration _config;
        private readonly IBiometricCredentialRepository _biometricCredentialRepository;
        private readonly ITokenService _tokenService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public BiometricCredentialService(IConfiguration config, IBiometricCredentialRepository biometricCredentialRepository, ITokenService tokenService, IRefreshTokenRepository refreshTokenRepository)
        {
            _config = config;
            _biometricCredentialRepository = biometricCredentialRepository;
            _tokenService = tokenService;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task DeleteBiometricCredentialAsync(int userId, string deviceId)
        {
            await _biometricCredentialRepository.DeleteAsync(userId, deviceId);   
        }

        public async Task<string> GenerateBiometricCredentialAsync(int userId, string deviceId, string? deviceName)
        {
            // 1. Tạo một token ngẫu nhiên, an toàn
            var biometricToken = Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N");

            // 2. Tạo đối tượng credential mới
            var newCredential = new BiometricCredential
            {
                UserId = userId,
                Token = biometricToken, // Hash token này trước khi lưu nếu muốn bảo mật hơn nữa
                DeviceId = deviceId,
                DeviceName = deviceName,
                IsActive = true
            };

            // 3. Lưu vào DB
            await _biometricCredentialRepository.CreateAsync(newCredential);

            // 4. Trả token về cho client
            return biometricToken;
        }

        public async Task<LoginResponseDTO> LoginWithBiometricAsync(string biometricToken)
        {
            // 1. Tìm credential trong DB
            var credential = await _biometricCredentialRepository.GetByTokenAsync(biometricToken);

            // 2. Nếu không tìm thấy hoặc không active
            if (credential == null || credential.User == null)
            {
                return new LoginResponseDTO
                {
                    IsValid = false,
                    Message = "Cần đăng nhập vào tài khoảng và mở khóa tính năng sinh trắc học."
                };
            } else if (!credential.User.IsActive)
            {
                return new LoginResponseDTO
                {
                    IsValid = false,
                    Message = "Tài khoản đã bị khóa."
                };
            } else if (!credential.IsActive)
            {
                return new LoginResponseDTO
                {
                    IsValid = false,
                    Message = "Tính năng sinh trắc học đã bị vô hiệu hóa. Vui lòng đăng nhập vào tài khoản để mở khóa."
                };
            }

            // 3. Tạo JWT token
            var user = credential.User;
            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            // 4. Lưu refresh token vào DB
            var refreshTokenEntity = new RefreshToken
            {
                Token = refreshToken,
                UserId = user.UserId,
                ExpiryDate = DateTime.UtcNow.AddDays(int.Parse(_config["Jwt:RefreshTokenExpiresDays"]!)),
                CreatedDate = DateTime.UtcNow
            };
            await _refreshTokenRepository.CreateRefreshTokenAsync(refreshTokenEntity);

            // 5. Trả về cho client
            return new LoginResponseDTO
            {
                IsValid = true,
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                UserId = user.UserId,
                FullName = user.FullName,
                AvatarUrl = user.AvatarUrl,
            };
        }
    }
}
