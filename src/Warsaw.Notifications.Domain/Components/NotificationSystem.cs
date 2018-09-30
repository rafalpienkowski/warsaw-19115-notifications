using System.Collections.Generic;
using Warsaw.Notifications.Domain.Components.Models;

namespace Warsaw.Notifications.Domain.Components
{
    public class NotificationSystem : INotificationSystem
    {
        private readonly string _apiKey = "9b03df8e-d95a-4747-a889-c6c98ad3de0b";

        public NotificationSystem()
        {
            
        }


        public IEnumerable<District> GetAvaliableDistricts()
        {
            return new List<District>
            { 
                new District("Bemowo"),
                new District("Wola")
            };
        }

        public IEnumerable<Notification> GetNotificationsForDistrict(District district)
        {
            return new List<Notification>{
                new Notification {
                    Category = "Proces Inwestycyjny",
                    City = "Warszawa",
                    Subcategory = "Śmieci",
                    District = "Bemowo",
                    NotificationNumber = "30892/13",
                    NotificationType = "INCYDENT",
                }
            };
        }
    }
}