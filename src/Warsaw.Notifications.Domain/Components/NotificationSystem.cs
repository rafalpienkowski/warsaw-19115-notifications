using System.Collections.Generic;
using Warsaw.Notifications.Domain.Components.Models;
using Warsaw.Notifications.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Warsaw.Notifications.Domain.Components
{
    public class NotificationSystem : INotificationSystem
    {
        private readonly INotificationRepository _repository;

        public NotificationSystem()
        {
            _repository = new NotificationRepository();
        }

        public Task<IEnumerable<District>> GetAvaliableDistrictsAsync()
        {
            return Task.FromResult<IEnumerable<District>>(new List<District>
            { 
                new District("Bemowo"),
                new District("Wola")
            });
        }

        public Task<IEnumerable<Notification>> GetNotificationsForDistrictAsync(District district)
        {
            return _repository.GetNotificationsForDistrictAsync(district.Name);
        }
    }
}