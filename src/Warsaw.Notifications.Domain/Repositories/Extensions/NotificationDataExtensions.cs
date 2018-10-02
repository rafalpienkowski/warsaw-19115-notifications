using System;
using System.Collections.Generic;
using System.Linq;
using Warsaw.Notifications.Domain.Components.Models;
using ApiModel = Warsaw.Notifications.Domain.Repositories.Models;

namespace Warsaw.Notifications.Domain.Repositories.Extensions
{
    internal static class NotificationDataExtensions
    {
        private static long _unixDateTimeZeroTicks = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc).Ticks;

        internal static IEnumerable<Notification> ToDomainModel(this IEnumerable<ApiModel.Notification> notifications)
        {
            var list = new List<Notification>();
            list.AddRange(notifications.Select(n => n.ToDomainModel()));
            return list;
        }

        internal static Notification ToDomainModel(this ApiModel.Notification notification)
        {
            var longDate = notification.CreateDate;
            return new Notification
            {
                Category = notification.Category,
                City = notification.City,
                Subcategory = notification.Subcategory,
                District = notification.District,
                AparmentNumber = notification.AparmentNumber,
                NotificationType = notification.NotificationType,
                NotificationNumber = notification.NotificationNumber,
                CreateDate = notification.CreateDate.ToDateTime(),
                Source = notification.Source,
                Street = notification.Street,
                Event = notification.Event,
                Statuses = notification.Statuses.ToDomainModel()
            };
        }

        internal static IEnumerable<Status> ToDomainModel(this IEnumerable<ApiModel.Status> statuses)
        {
            var list = new List<Status>();
            list.AddRange(statuses.Select(s => s.ToDomainModel()));
            return list;
        }

        internal static Status ToDomainModel(this ApiModel.Status status)
        {
            return new Status
            {
                Name = status.StatusStatus,
                Description = status.Description,
                ChangeDate = status.ChangeDate.ToDateTime()
            };
        }

        internal static DateTime ToDateTime(this long ticks)
        {
            return new DateTime(_unixDateTimeZeroTicks + ticks * 10000, DateTimeKind.Utc);
        }
    }
}