using System.Collections.Generic;
using Warsaw.Notifications.Domain.Components.Models;

namespace Warsaw.Notifications.Domain.Components
{
    public interface INotificationSystem
    {
        IEnumerable<Notification> GetNotificationsForDistrict(District district);
        IEnumerable<District> GetAvaliableDistricts();
    }
}