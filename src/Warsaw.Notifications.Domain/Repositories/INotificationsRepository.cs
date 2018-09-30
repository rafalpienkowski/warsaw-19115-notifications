using System.Collections.Generic;
using Warsaw.Notifications.Domain.Repositories.Models;

namespace Warsaw.Notifications.Domain.Repositories
{
    public interface INotificationsRepository
    {
        IEnumerable<NotificationData> GetNotificationsForDistrict(string districtName);
    }
}