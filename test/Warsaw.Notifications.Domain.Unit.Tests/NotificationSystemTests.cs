using System;
using System.Threading.Tasks;
using Warsaw.Notifications.Domain.Components;
using FluentAssertions;
using Xunit;
using System.Collections.Generic;
using Warsaw.Notifications.Domain.Components.Models;

namespace Warsaw.Notifications.Domain.Unit.Tests
{
    public class NotificationSystemTests
    {

        private NotificationSystem _notificationSystem;

        [Fact]
        public async Task GetAvaliableDistrictsAsync_ShouldReturnOnlyWolaAndBemowo()
        {
            _notificationSystem = new NotificationSystem(string.Empty);
            var expectedResult = new List<District>
            { 
                new District("Bemowo"),
                new District("Wola")
            };


            var results = await _notificationSystem.GetAvaliableDistrictsAsync();

            results.Should().NotBeNull();
            results.Should().BeEquivalentTo(expectedResult);
        }
    }
}
