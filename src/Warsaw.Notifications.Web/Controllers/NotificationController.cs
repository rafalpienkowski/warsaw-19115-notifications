using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Warsaw.Notifications.Domain.Components;
using Warsaw.Notifications.Domain.Components.Models;
using Warsaw.Notifications.Web.Models;

namespace Warsaw.Notifications.Web.Controllers {
    public class NotificationController : BaseController {
        private readonly INotificationSystem _notificationSystem;
        private readonly IEnumerable<District> _avaliableDistricts;

        public NotificationController (INotificationSystem notificationSystem) {
            _notificationSystem = notificationSystem;
            _avaliableDistricts = _notificationSystem.GetAvaliableDistricts();
        }

        public IActionResult Index () {
            ViewBag.AvaliableDistricts = _avaliableDistricts;
            return View ();
        }

        [Route("Notification/Search/{districtName}")]
        public IActionResult Search(string districtName){
            ViewBag.AvaliableDistricts = _avaliableDistricts;
            var notifications = new List<NotificationViewModel>{
                new NotificationViewModel{
                    District = "Bemowo"
                }
            };
            return View(notifications);
        }
    }
}