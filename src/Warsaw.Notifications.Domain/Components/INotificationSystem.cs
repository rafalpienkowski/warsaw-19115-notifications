using System.Collections.Generic;
using System.Threading.Tasks;
using Warsaw.Notifications.Domain.Components.Models;

namespace Warsaw.Notifications.Domain.Components
{
    public interface INotificationSystem
    {
        Task<IEnumerable<Notification>> GetNotificationsForDistrictAsync(District district);
        Task<IEnumerable<District>> GetAvaliableDistrictsAsync();
    }
}