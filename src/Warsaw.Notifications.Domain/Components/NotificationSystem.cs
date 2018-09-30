using System.Collections.Generic;
using Warsaw.Notifications.Domain.Components.Models;

namespace Warsaw.Notifications.Domain.Components
{
    public class NotificationSystem : INotificationSystem
    {
        public NotificationSystem()
        {
            
        }


        public IEnumerable<District> GetAvaliableDistricts()
        {
            return new List<District>{ new District("Wola") };
        }

        public IEnumerable<Notification> GetNotificationsForDistrict(District district)
        {
            throw new System.NotImplementedException();
        }
    }
}