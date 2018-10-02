using System;
using System.Threading.Tasks;
using Xunit;
using Warsaw.Notifications.Domain.Repositories;
using FluentAssertions;
using Warsaw.Notifications.Domain.Repositories.Models;

namespace Warsaw.Notifications.Domain.Integration.Tests
{
    public class NotificationRepositoryTests
    {
        private NotificationRepository _sut;

        [Fact]
        public async Task GetNotificationsForDistrictAsync_ShouldReturnDataForWola()
        {
            _sut = new NotificationRepository();

            var result = await _sut.GetNotificationsForDistrictAsync("Wola");

            result.Should().NotBeNull();
            result.Should().BeOfType<Welcome>("API should return data in given format");
        }
    }
}
