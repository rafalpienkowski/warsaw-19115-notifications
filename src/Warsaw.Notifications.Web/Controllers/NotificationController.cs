using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warsaw.Notifications.Domain.Components;
using Warsaw.Notifications.Domain.Components.Models;
using Warsaw.Notifications.Web.Models;

namespace Warsaw.Notifications.Web.Controllers {
    public class NotificationController : BaseController {
        private readonly INotificationSystem _notificationSystem;
        private readonly IMapper _mapper;

        public NotificationController (INotificationSystem notificationSystem, IMapper mapper)
        { 
            _notificationSystem = notificationSystem;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index() 
        {
            ViewBag.AvaliableDistricts = await _notificationSystem.GetAvaliableDistrictsAsync();
            return View();
        }

        [Route ("Notification/Search/{districtName}")]
        public async Task<IActionResult> Search(string districtName) 
        {
            var districts = await _notificationSystem.GetAvaliableDistrictsAsync();
            var district = districts.SingleOrDefault(d => d.Name.Equals(districtName));

            ViewBag.District = district.Name;
            var notificationsRaw = await _notificationSystem.GetNotificationsForDistrictAsync(district);
            var notifications = _mapper.Map<List<NotificationViewModel>>(notificationsRaw);
            return View (notifications);
        }
    }
}