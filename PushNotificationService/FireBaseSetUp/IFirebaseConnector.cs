using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PushNotificationService.FireBaseSetUp
{
   public interface IFirebaseConnector
    {
        Task SendNotification(string token, string title, string body, Dictionary<string, string> keypairs);
       // Task SendMultipleNotifications(List<string> token, string title, string body, Dictionary<string, string> keypairs);
    }
}
