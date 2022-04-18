using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PushNotificationService.Model
{
    public class NotificationModel
    {
        public string FcmToken { get; set; }
        public string Body { get; set; }
        public string SchoolLogo { get; set; }
        public string Title { get; set; }
        public long Id { get; set; }
    }
}
