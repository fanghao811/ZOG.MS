using Abp.Notifications;
using ZOGLAB.MMMS.Dto;

namespace ZOGLAB.MMMS.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }
    }
}