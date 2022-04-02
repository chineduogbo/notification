using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PushNotificationService.FireBaseSetUp;
using PushNotificationService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PushNotificationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PushNotificationController : ControllerBase
    {
        private readonly IFirebaseConnector _firebasefcm;
        public PushNotificationController(IFirebaseConnector firebasefcm)
        {
            _firebasefcm = firebasefcm;
        }
        [HttpPost]
        public async Task<bool> Push(IList<NotificationModel> model)
        {
            foreach (var item in model)
            {
                Dictionary<string, string> Objectsformessage = new Dictionary<string, string>();

 
                Objectsformessage.Add("PictureUrl", item.SchoolLogo);

          

                if (item.FcmToken != "")
                {
                    await _firebasefcm.SendNotification(item.FcmToken, "AnnounceMents", item.Body, Objectsformessage);
                }
            }
            return true;
        }
    }
}
