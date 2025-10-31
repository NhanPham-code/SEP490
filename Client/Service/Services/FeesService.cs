using DTOs.FeesDTO;
using DTOs.OData;
using Service.BaseService;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Web;


namespace Service.Services
{
    public class FeesService : IFeesService
    {
        private readonly HttpClient _httpClient;
        private readonly static string GATEWAY_URL = "http://localhost:7136";

        public FeesService(GatewayHttpClient gateway)
        {
            _httpClient = gateway.Client;
        }

        private void AddBearerAccessToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<IEnumerable<FeeDto>?> GetAllFeesAsync(string token)
        {
            AddBearerAccessToken(token);
            var response = await _httpClient.GetAsync("fees");
            response.EnsureSuccessStatusCode(); // Ném lỗi nếu request không thành công

            var data = await response.Content.ReadFromJsonAsync<IEnumerable<FeeDto>>();
            return data;
        }

        public async Task<FeeDto?> GetFeeByIdAsync(int id, string token)
        {
            AddBearerAccessToken(token);
            var response = await _httpClient.GetAsync($"fees/{id}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadFromJsonAsync<FeeDto>();
            return data;
        }

        public async Task<IEnumerable<FeeDto>?> GetFeesByMonthYearAsync(int month, int year, string token)
        {
            AddBearerAccessToken(token);
            // Query string sẽ được tự động chuyển tiếp bởi Gateway
            var response = await _httpClient.GetAsync($"fees/by-month-year?month={month}&year={year}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadFromJsonAsync<IEnumerable<FeeDto>>();
            return data;
        }

        public async Task<IEnumerable<FeeDto>?> GetFeesByOwnerIdAsync(int ownerId, string token)
        {
            AddBearerAccessToken(token);
            var response = await _httpClient.GetAsync($"fees/owner/{ownerId}");
            response.EnsureSuccessStatusCode();

           var data = await response.Content.ReadFromJsonAsync<IEnumerable<FeeDto>>();
            return data;
        }

        public async Task<IEnumerable<FeeDto>?> GetFeesByStadiumIdAsync(int stadiumId, string token)
        {
            AddBearerAccessToken(token);
            var response = await _httpClient.GetAsync($"fees/stadium/{stadiumId}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadFromJsonAsync<IEnumerable<FeeDto>>();
            return data;
        }

        public async Task<FeeDto> UpdateFeeToPaidAsync(int id, string token)
        {
            AddBearerAccessToken(token);
            // Phương thức PUT thường có body, nhưng trong trường hợp này body không cần thiết
            var response = await _httpClient.PutAsync($"fees/paid/{id}", null);
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadFromJsonAsync<FeeDto>();
            return data!;
        }

        public async Task<OdataHaveCountResponse<FeeDto>> GetFeesForOwner(string token, int ownerId, int month, int year)
        {
            AddBearerAccessToken(token);

            // Xây dựng các điều kiện lọc của OData
            var filters = new List<string>
            {
                $"OwnerId eq {ownerId}",
                $"Month eq {month}",
                $"Year eq {year}"
            };

            var filterQuery = string.Join(" and ", filters);

            // Xây dựng URL cuối cùng với các tham số OData
            // $count=true: Yêu cầu API trả về tổng số lượng bản ghi
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["$filter"] = filterQuery;
            queryString["$count"] = "true";
            queryString["$orderby"] = "FeeAmount desc"; // Sắp xếp phí từ cao đến thấp

            var fullUrl = $"fees/getQuery?{queryString}";

            var response = await _httpClient.GetAsync(fullUrl);
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadFromJsonAsync<OdataHaveCountResponse<FeeDto>>();
            return data ?? new OdataHaveCountResponse<FeeDto>();
        }

        public async Task<FeeDto?> UploadBillImage(string token, UploadBillImageDTO uploadBillImageDTO)
        {
            AddBearerAccessToken(token);

            // Khi gửi file, chúng ta phải sử dụng MultipartFormDataContent
            using var multipartContent = new MultipartFormDataContent();

            // 1. Thêm các thuộc tính dạng text (FeeId, StadiumName)
            multipartContent.Add(new StringContent(uploadBillImageDTO.FeeId.ToString()), name: nameof(UploadBillImageDTO.FeeId));
            if (!string.IsNullOrEmpty(uploadBillImageDTO.StadiumName))
            {
                multipartContent.Add(new StringContent(uploadBillImageDTO.StadiumName), name: nameof(UploadBillImageDTO.StadiumName));
            }

            // 2. Thêm file ảnh - ĐÂY LÀ PHẦN ĐÃ ĐƯỢC SỬA LỖI
            if (uploadBillImageDTO.BillImage != null && uploadBillImageDTO.BillImage.Length > 0)
            {
                // Tạo một MemoryStream để sao chép dữ liệu từ file vào
                var memoryStream = new MemoryStream();
                // Sao chép nội dung của file vào memoryStream
                await uploadBillImageDTO.BillImage.CopyToAsync(memoryStream);
                // Quan trọng: Đưa con trỏ của stream về vị trí đầu để HttpClient có thể đọc từ đầu
                memoryStream.Position = 0;

                // Tạo StreamContent từ MemoryStream (stream này sẽ không bị hủy sớm)
                var streamContent = new StreamContent(memoryStream);
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(uploadBillImageDTO.BillImage.ContentType);

                // Thêm vào multipart content với tên thuộc tính và tên file
                multipartContent.Add(streamContent, name: nameof(UploadBillImageDTO.BillImage), fileName: uploadBillImageDTO.BillImage.FileName);
            }

            // 3. Gửi request PUT đến API Gateway
            // HttpClient sẽ đọc từ MemoryStream một cách an toàn
            var response = await _httpClient.PutAsync("/fees/upload-bill", multipartContent);

            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var updatedFee = await response.Content.ReadFromJsonAsync<FeeDto>(options);
                return updatedFee;
            }

            // Xử lý lỗi nếu có
            var errorContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Lỗi khi upload hóa đơn: {errorContent}");
            // Ném ra một exception để Controller có thể bắt và trả về lỗi cho client
            throw new HttpRequestException($"Lỗi khi tải lên hóa đơn: {response.StatusCode} - {errorContent}");
        }
    }
}
