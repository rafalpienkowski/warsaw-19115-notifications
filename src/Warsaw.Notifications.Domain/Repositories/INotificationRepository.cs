using System.Collections.Generic;
using System.Threading.Tasks;
using Warsaw.Notifications.Domain.Components.Models;

namespace Warsaw.Notifications.Domain.Repositories
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetNotificationsForDistrictAsync(string districtName);
    }
}