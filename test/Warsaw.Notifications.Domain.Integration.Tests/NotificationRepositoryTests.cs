using System;
using System.Threading.Tasks;
using Xunit;
using Warsaw.Notifications.Domain.Repositories;
using FluentAssertions;
using Warsaw.Notifications.Domain.Integration.Tests.Config;
using Warsaw.Notifications.Domain.Components.Models;
using System.Collections.Generic;

namespace Warsaw.Notifications.Domain.Integration.Tests
{
    public class NotificationRepositoryTests
    {
        private NotificationRepository _sut;

        private readonly string _warsawApiKey;

        public NotificationRepositoryTests()
        {
            var config = new Configuration();
            _warsawApiKey = config.WarsawApiKey;
        }

        [Fact]
        public async Task GetNotificationsForDistrictAsync_ShouldReturnDataForWola()
        {
            _sut = new NotificationRepository(_warsawApiKey);

            var result = await _sut.GetNotificationsForDistrictAsync("Wola");

            result.Should().NotBeNull();
            result.Should().BeOfType<List<Notification>>("API should return data in given format");
        }
    }
}
