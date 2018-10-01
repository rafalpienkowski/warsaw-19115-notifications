using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public IActionResult Index () 
        {
            ViewBag.AvaliableDistricts = _notificationSystem.GetAvaliableDistricts();
            return View ();
        }

        [Route ("Notification/Search/{districtName}")]
        public IActionResult Search (string districtName) 
        {
            var district = _notificationSystem.GetAvaliableDistricts()
                .SingleOrDefault(d => d.Name.Equals(districtName));

            var notificationsRaw = _notificationSystem.GetNotificationsForDistrict(district);
            var notifications = _mapper.Map<List<NotificationViewModel>>(notificationsRaw);
            return View (notifications);
        }
    }
}