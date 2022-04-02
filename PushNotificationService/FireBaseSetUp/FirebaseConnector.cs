using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace PushNotificationService.FireBaseSetUp
{
   public class FirebaseConnector :IFirebaseConnector
    {
        private readonly FirebaseMessaging messaging; 
      
        public FirebaseConnector()
        {
            
            var app = FirebaseApp.Create(new AppOptions() { Credential = GoogleCredential.FromFile("absu-60f99-firebase-adminsdk-c269k-c5efd73b24.json").CreateScoped("https://www.googleapis.com/auth/firebase.messaging") });
            messaging = FirebaseMessaging.GetMessaging(app);
           
        }

        private Message CreateNotification(string title, string notificationBody, string token,Dictionary<string,string> keypairs)
        {
            return new Message()
            {
                Token = token,
                Data = keypairs,
                
                Notification = new Notification()
                {
                    Body = notificationBody,
                    Title = title,
                    
                },
                Android = new AndroidConfig()
                {
                    Priority = Priority.High,
                    Notification = new AndroidNotification()
                    {
                        Sound = "default",
                        Color = "#CA3434",
                       // ImageUrl = baseUrl + "Images/ProfilePictures/Avatar.jpg"
                    }
                },
               
            };
        }
  

        public async Task SendNotification(string token, string title, string body, Dictionary<string, string> keypairs)
        {
            var result = await messaging.SendAsync(CreateNotification(title, body, token,keypairs));
        }

      
    }
}
