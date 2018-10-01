using System.Collections.Generic;
using Warsaw.Notifications.Domain.Repositories.Models;

namespace Warsaw.Notifications.Domain.Repositories
{
    internal class NotificationRepository : INotificationsRepository
    {

        
        public IEnumerable<NotificationData> GetNotificationsForDistrict(string districtName)
        {
            throw new System.NotImplementedException();
        }
    }
}