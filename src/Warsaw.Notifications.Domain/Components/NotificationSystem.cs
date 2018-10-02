using System.Collections.Generic;
using Warsaw.Notifications.Domain.Components.Models;
using Warsaw.Notifications.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Warsaw.Notifications.Domain.Components
{
    public class NotificationSystem : INotificationSystem
    {
        private readonly INotificationRepository _repository;

        internal NotificationSystem(string apikey)
        {
            _repository = new NotificationRepository(apikey);
        }

        public NotificationSystem(IOptions<ConfigurationManager> settings)
        {
            _repository = new NotificationRepository(settings);
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