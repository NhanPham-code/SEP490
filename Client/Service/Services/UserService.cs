using DTOs.OData;
using DTOs.UserDTO;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using Service.BaseService;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(GatewayHttpClient gateway)
        {
            _httpClient = gateway.Client;
        }

        private void AddBearerAccessToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("/users/login", loginRequestDTO);
            //response.EnsureSuccessStatusCode();  // Nếu không 2xx → throw HttpRequestException
            return await response.Content.ReadFromJsonAsync<LoginResponseDTO>();
        }

        public async Task<bool> CustomerRegisterAsync(CustomerRegisterRequestDTO dto)
        {
            using var form = new MultipartFormDataContent();

            form.Add(new StringContent(dto.FullName), nameof(dto.FullName));
            form.Add(new StringContent(dto.Email), nameof(dto.Email));
            form.Add(new StringContent(dto.Password), nameof(dto.Password));
            form.Add(new StringContent(dto.Role ?? "None"), nameof(dto.Role));

            if (!string.IsNullOrEmpty(dto.Address))
                form.Add(new StringContent(dto.Address), nameof(dto.Address));

            if (!string.IsNullOrEmpty(dto.PhoneNumber))
                form.Add(new StringContent(dto.PhoneNumber), nameof(dto.PhoneNumber));

            if (!string.IsNullOrEmpty(dto.Gender))
                form.Add(new StringContent(dto.Gender), nameof(dto.Gender));

            if (!string.IsNullOrEmpty(dto.DateOfBirth))
                form.Add(new StringContent(dto.DateOfBirth), nameof(dto.DateOfBirth));

            if (dto.Avatar != null)
            {
                var avatarContent = new StreamContent(dto.Avatar.OpenReadStream());
                avatarContent.Headers.ContentType =
                    new MediaTypeHeaderValue(dto.Avatar.ContentType);
                form.Add(avatarContent, nameof(dto.Avatar), dto.Avatar.FileName);
            }

            if (dto.FaceImages != null && dto.FaceImages.Any())
            {
                foreach (var faceImage in dto.FaceImages)
                {
                    if (faceImage != null && faceImage.Length > 0)
                    {
                        var faceContent = new StreamContent(faceImage.OpenReadStream());
                        faceContent.Headers.ContentType = new MediaTypeHeaderValue(faceImage.ContentType);
                        // Tên field là FaceImages (trùng tên property trong DTO)
                        form.Add(faceContent, "FaceImages", faceImage.FileName);
                    }
                }
            }

            var response = await _httpClient.PostAsync("/users/CustomerRegister", form);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> StadiumManagerRegisterAsync(StadiumManagerRegisterRequestDTO dto)
        {
            using var form = new MultipartFormDataContent();

            form.Add(new StringContent(dto.Email), nameof(dto.Email));
            form.Add(new StringContent(dto.Password), nameof(dto.Password));

            if (!string.IsNullOrEmpty(dto.PhoneNumber))
                form.Add(new StringContent(dto.PhoneNumber), nameof(dto.PhoneNumber));

            if (dto.FrontCCCDImage != null)
            {
                var frontContent = new StreamContent(dto.FrontCCCDImage.OpenReadStream());
                frontContent.Headers.ContentType =
                    new MediaTypeHeaderValue(dto.FrontCCCDImage.ContentType);
                form.Add(frontContent, nameof(dto.FrontCCCDImage), dto.FrontCCCDImage.FileName);
            }

            if (dto.RearCCCDImage != null)
            {
                var rearContent = new StreamContent(dto.RearCCCDImage.OpenReadStream());
                rearContent.Headers.ContentType =
                    new MediaTypeHeaderValue(dto.RearCCCDImage.ContentType);
                form.Add(rearContent, nameof(dto.RearCCCDImage), dto.RearCCCDImage.FileName);
            }

            if (dto.Avatar != null)
            {
                var avatarContent = new StreamContent(dto.Avatar.OpenReadStream());
                avatarContent.Headers.ContentType =
                    new MediaTypeHeaderValue(dto.Avatar.ContentType);
                form.Add(avatarContent, nameof(dto.Avatar), dto.Avatar.FileName);
            }

            var response = await _httpClient.PostAsync("/users/ManagerRegister", form);
            return response.IsSuccessStatusCode;
        }

        public async Task<LogoutResponseDTO> LogoutAsync(LogoutRequestDTO logoutRequestDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("/users/logout", logoutRequestDTO);
            response.EnsureSuccessStatusCode();  // Nếu không 2xx → throw HttpRequestException
            return await response.Content.ReadFromJsonAsync<LogoutResponseDTO>();
        }

        public async Task<LoginResponseDTO> RefreshTokenAsync(RefreshTokenRequestDTO refreshTokenRequestDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("/users/refreshToken", refreshTokenRequestDTO);
            response.EnsureSuccessStatusCode();  // Nếu không 2xx → throw HttpRequestException
            return await response.Content.ReadFromJsonAsync<LoginResponseDTO>();
        }

        public async Task<PrivateUserProfileDTO?> GetMyProfileAsync(string accessToken)
        {
            AddBearerAccessToken(accessToken);

            var response = await _httpClient.GetAsync("/users/me");
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadFromJsonAsync<PrivateUserProfileDTO>();
        }

        public async Task<PublicUserProfileDTO?> GetOtherUserByIdAsync(int userId)
        {
            return await _httpClient.GetFromJsonAsync<PublicUserProfileDTO>($"/users/otherProfile/{userId}");
        }

        public async Task<bool> IsEmailExistsAsync(string email)
        {
            var response = await _httpClient.PostAsJsonAsync($"/users/checkEmail", email);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<bool>();
                return result;
            }
            else
            {
                throw new HttpRequestException($"Error checking email existence: {response.ReasonPhrase}");
            }
        }

        public async Task<PrivateUserProfileDTO> UpdateUserProfileAsync(UpdateUserProfileDTO updateUserProfileDTO, string accessToken)
        {
            AddBearerAccessToken(accessToken);
            var response  = await _httpClient.PutAsJsonAsync("/users/update-profile", updateUserProfileDTO);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<PrivateUserProfileDTO>();
            }
            else
            {
                throw new HttpRequestException($"Error updating user profile: {response.ReasonPhrase}");
            }
        }

        public async Task<PrivateUserProfileDTO> UpdateAvatarAsync(UpdateAvatarDTO updateAvatarDTO, string accessToken)
        {
            AddBearerAccessToken(accessToken);

            using var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(updateAvatarDTO.UserId.ToString()), "UserId");

            if (updateAvatarDTO.Avatar != null)
            {
                var stream = updateAvatarDTO.Avatar.OpenReadStream();
                var fileContent = new StreamContent(stream);
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(updateAvatarDTO.Avatar.ContentType ?? "image/jpeg");
                formData.Add(fileContent, "Avatar", updateAvatarDTO.Avatar.FileName);
            }

            var response = await _httpClient.PutAsync("/users/update-avatar", formData);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<PrivateUserProfileDTO>();
            }
            else
            {
                throw new HttpRequestException($"Error updating avatar: {response.ReasonPhrase}");
            }
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO)
        {
            if(string.IsNullOrEmpty(resetPasswordDTO.Email) || string.IsNullOrEmpty(resetPasswordDTO.NewPassword) || resetPasswordDTO.NewPassword.Length < 6)
            {
                throw new ArgumentException("Invalid email or password");
            }

            var response = await _httpClient.PutAsJsonAsync("/users/forgot-password", resetPasswordDTO);
            return response.IsSuccessStatusCode;
        }

        public async Task<LoginResponseDTO> LoginWithGoogleAsync(GoogleApiLoginRequestDTO googleRequest)
        {
            // Gọi đến endpoint /users/google-auth của API Server
            var response = await _httpClient.PostAsJsonAsync("/users/google-auth", googleRequest);

            // Đọc kết quả trả về, dù thành công hay thất bại
            // API Server sẽ trả về cấu trúc LoginResponseDTO với IsValid = false nếu có lỗi
            return await response.Content.ReadFromJsonAsync<LoginResponseDTO>();
        }

        /// <summary>
        /// Lấy danh sách thông tin công khai của nhiều người dùng dựa trên danh sách ID.
        /// </summary>
        /// <param name="userIds">Danh sách các ID của người dùng cần lấy.</param>
        /// <returns>Một danh sách các PublicUserProfileDTO.</returns>
        public async Task<List<PublicUserProfileDTO>> GetUsersByIdsAsync(List<int> userIds, string accessToken)
        {
            AddBearerAccessToken(accessToken);

            // 1. Xử lý trường hợp danh sách ID rỗng hoặc null để tránh gọi API không cần thiết
            if (userIds == null || !userIds.Any())
            {
                return new List<PublicUserProfileDTO>();
            }

            // 1. Chuyển danh sách các số nguyên thành một chuỗi duy nhất, phân cách bằng dấu phẩy.
            // Ví dụ: [6008, 6009] -> "6008,6009"
            string commaSeparatedIds = string.Join(",", userIds);

            // 2. Xây dựng câu lệnh $filter sử dụng toán tử 'in'.
            // Ví dụ: "UserId in (6008,6009)"
            string odataFilter = $"UserId in ({commaSeparatedIds})";

            // 3. Tạo URL request hoàn chỉnh
            var requestUrl = $"/users/get?$filter={odataFilter}";

            try
            {
                // 4. Gửi request và đọc response
                var response = await _httpClient.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode(); // Ném lỗi nếu request thất bại

                string jsonString = await response.Content.ReadAsStringAsync();

                // 5. Deserialize bằng Newtonsoft.Json
                var odataResponse = JsonConvert.DeserializeObject<ODataResponse<PublicUserProfileDTO>>(jsonString);

                // Trả về danh sách người dùng từ thuộc tính 'Value', hoặc một danh sách rỗng nếu response là null
                return odataResponse?.Value ?? new List<PublicUserProfileDTO>();
            }
            catch (HttpRequestException e)
            {
                // (Tùy chọn) Ghi log lỗi ở đây
                Console.WriteLine($"An error occurred: {e.Message}");
                // Trả về danh sách rỗng hoặc ném lại lỗi tùy theo yêu cầu của ứng dụng
                return new List<PublicUserProfileDTO>();
            }
        }

        public async Task<OdataHaveCountResponse<AdminUserProfileDTO>> GetUsersForAdmin(string accessToken, UserSearchRequestDTO request)
        {
            var odataFilter = BuildODataFilter(request); // Giữ nguyên logic này
            var skip = (request.Page - 1) * request.PageSize;
            var top = request.PageSize;

            var requestUrl = $"/adminUsers/get?$filter={odataFilter}&$skip={skip}&$top={top}&$orderby=CreatedDate desc&$count=true";

            try
            {
                var response = await _httpClient.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();

                string jsonString = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<OdataHaveCountResponse<AdminUserProfileDTO>>(jsonString);

                return result ?? new OdataHaveCountResponse<AdminUserProfileDTO>();
            } catch (HttpRequestException e)
            {
                // (Tùy chọn) Ghi log lỗi ở đây
                Console.WriteLine($"An error occurred: {e.Message}");
                return new OdataHaveCountResponse<AdminUserProfileDTO>();
            }
            
        }

        private string BuildODataFilter(UserSearchRequestDTO request)
        {
            var filters = new List<string>();

            // Filter theo SearchTerm (email hoặc SĐT)
            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();
                filters.Add($"(contains(tolower(email), '{term}') or contains(phoneNumber, '{term}'))");
            }

            // Filter theo tháng đăng ký
            if (!string.IsNullOrWhiteSpace(request.Month) && request.Month.Contains('-'))
            {
                var parts = request.Month.Split('-');
                if (int.TryParse(parts[0], out int year) && int.TryParse(parts[1], out int month))
                {
                    filters.Add($"(year(CreatedDate) eq {year} and month(CreatedDate) eq {month})");
                }
            }

            // Filter theo trạng thái
            if (!string.IsNullOrWhiteSpace(request.Status))
            {
                if (request.Status.ToLower() == "active")
                {
                    filters.Add($"IsActive eq true");
                } else if (request.Status.ToLower() == "banned")
                {
                    filters.Add($"IsActive eq false");
                }
            }

            // Filter theo vai trò
            if (!string.IsNullOrWhiteSpace(request.Role))
            {
                filters.Add($"Role eq '{request.Role}'");
            }

            return string.Join(" and ", filters);
        }

        public async Task<AdminUserStatsDTO> GetUserStats(string accessToken)
        {
            AddBearerAccessToken(accessToken);

            var response = await _httpClient.GetAsync("/adminUsers/stats");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<AdminUserStatsDTO>();
        }

        public async Task<bool> BanUserAsync(int userId, string accessToken)
        {
            AddBearerAccessToken(accessToken);

            var response = await  _httpClient.PutAsJsonAsync($"/adminUsers/ban/{userId}", userId);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UnbanUserAsync(int userId, string accessToken)
        {
            AddBearerAccessToken(accessToken);

            var response = await _httpClient.PutAsJsonAsync($"/adminUsers/unban/{userId}", userId);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<PublicUserProfileDTO>> SearchUsersByPhoneAsync(string phoneNumber, string accessToken)
        {
            AddBearerAccessToken(accessToken);

            var requestUrl = $"/users/get?$filter=contains(PhoneNumber, '{phoneNumber}')";

            try
            {
                var response = await _httpClient.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode(); // Ném lỗi nếu request thất bại

                string jsonString = await response.Content.ReadAsStringAsync();

                // 5. Deserialize bằng Newtonsoft.Json
                var odataResponse = JsonConvert.DeserializeObject<ODataResponse<PublicUserProfileDTO>>(jsonString);

                // Trả về danh sách người dùng từ thuộc tính 'Value', hoặc một danh sách rỗng nếu response là null
                return odataResponse?.Value ?? new List<PublicUserProfileDTO>();
            }
            catch (HttpRequestException e)
            {
                // (Tùy chọn) Ghi log lỗi ở đây
                Console.WriteLine($"An error occurred: {e.Message}");
                // Trả về danh sách rỗng hoặc ném lại lỗi tùy theo yêu cầu của ứng dụng
                return new List<PublicUserProfileDTO>();
            }
        }

        // Thêm hàm này vào IUserService và class implement nó
        public async Task<List<PublicUserProfileDTO>> SearchUsersByEmailAsync(string email, string accessToken)
        {
            AddBearerAccessToken(accessToken);

            var requestUrl = $"/users/get?$filter=contains(Email, '{email}')";

            try
            {
                var response = await _httpClient.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();

                string jsonString = await response.Content.ReadAsStringAsync();

                var odataResponse = JsonConvert.DeserializeObject<ODataResponse<PublicUserProfileDTO>>(jsonString);

                return odataResponse?.Value ?? new List<PublicUserProfileDTO>();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"An error occurred while searching by email: {e.Message}");
                return new List<PublicUserProfileDTO>();
            }
        }

        public async Task<LoginResponseDTO> LoginWithFaceAsync(AiFaceLoginRequestDTO aiFaceLoginRequestDTO)
        {
            using var form = new MultipartFormDataContent();
            if (aiFaceLoginRequestDTO.FaceImage != null)
            {
                var faceContent = new StreamContent(aiFaceLoginRequestDTO.FaceImage.OpenReadStream());
                faceContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(aiFaceLoginRequestDTO.FaceImage.ContentType);
                form.Add(faceContent, "FaceImage", aiFaceLoginRequestDTO.FaceImage.FileName);
            }

            var response = await _httpClient.PostAsync("/users/face-login", form);
            return await response.Content.ReadFromJsonAsync<LoginResponseDTO>();
        }

        public async Task<bool> AddorUpdateFaceEmbeddings(FaceImagesDTO faceImagesDTO, string accessToken)
        {
            AddBearerAccessToken(accessToken);

            using var form = new MultipartFormDataContent();

            if (faceImagesDTO.FaceImages != null && faceImagesDTO.FaceImages.Any())
            {
                foreach (var faceImage in faceImagesDTO.FaceImages)
                {
                    if (faceImage != null && faceImage.Length > 0)
                    {
                        var faceContent = new StreamContent(faceImage.OpenReadStream());
                        faceContent.Headers.ContentType = new MediaTypeHeaderValue(faceImage.ContentType);
                        // Tên field là FaceImages (trùng tên property trong DTO)
                        form.Add(faceContent, "FaceImages", faceImage.FileName);
                    }
                }
            }

            var response = await _httpClient.PutAsync("/users/face-embeddings", form);
            return response.IsSuccessStatusCode;
        }
    }
}
