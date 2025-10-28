using AutoMapper;

namespace NotificationAPI.Mapper
{
    public class NotificationMapper : Profile
    {
        public NotificationMapper()
        {
            CreateMap<Dto.CreateNotificationDto, Model.Notification>();
        }
    }
}
