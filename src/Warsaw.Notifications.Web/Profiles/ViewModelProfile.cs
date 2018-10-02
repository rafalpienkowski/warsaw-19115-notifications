using AutoMapper;
using Warsaw.Notifications.Web.Models;
using Warsaw.Notifications.Domain.Components.Models;

namespace Warsaw.Notifications.Web.Profiles
{
    public class ViewModelProfile : Profile
    {
        public ViewModelProfile()
        {
            CreateMap<NotificationViewModel, Notification>();
        }
    }
}