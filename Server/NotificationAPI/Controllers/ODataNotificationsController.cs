using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using NotificationAPI.Model;
using NotificationAPI.Service.Interface;

namespace NotificationAPI.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ODataNotificationsController : ODataController
    {
        private readonly INotificationService _notificationService;

        public ODataNotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // GET: odata/ODataNotifications
        public IQueryable<Notification> Get(ODataQueryOptions<Notification> queryOptions) // <--- Kiểu tham số là User, kiểu trả về là IQueryable<ReadUserDTO>
        {
            // 1. Lấy IQueryable<User> từ Service/Repository
            IQueryable<Notification> users = _notificationService.GetNotificationsQueryable();

            // 2. Áp dụng các tùy chọn truy vấn OData vào IQueryable<User>
            // Điều này sẽ thực hiện lọc, sắp xếp, phân trang ở cấp độ DB (nếu dùng EF Core)
            // queryOptions.ApplyTo trả về IQueryable (non-generic), cần Cast lại về IQueryable<User>
            IQueryable<Notification> results = (IQueryable<Notification>)queryOptions.ApplyTo(users);

            // 3. Chiếu kết quả (hiện đang là IQueryable<User>) sang IQueryable<ReadUserDTO>
            // Đảm bảo bạn có cấu hình AutoMapper để ánh xạ từ User sang ReadUserDTO
            //IQueryable<PublicUserProfileDTO> projectedResults = results.ProjectTo<PublicUserProfileDTO>(_mapper.ConfigurationProvider);

            // 4. Trả về kết quả đã được chiếu. OData sẽ định dạng nó.
            return results;
        }
    }
}
