using Microsoft.AspNetCore.Mvc;

namespace Warsaw.Notifications.Web.Controllers
{
    public class NotificationController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}