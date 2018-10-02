using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Warsaw.Notifications.Domain.Repositories.Models;
using DomainModel = Warsaw.Notifications.Domain.Components.Models;
using Warsaw.Notifications.Domain.Repositories.Extensions;

[assembly:InternalsVisibleTo("Warsaw.Notifications.Domain.Integration.Tests")]

namespace Warsaw.Notifications.Domain.Repositories
{
    internal class NotificationRepository : INotificationRepository
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;
        
        public NotificationRepository()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://api.um.warszawa.pl");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            _apiKey = "";
        }

        public async Task<IEnumerable<DomainModel.Notification>> GetNotificationsForDistrictAsync(string districtName)
        {
            var action = "api/action/19115store_getNotificationsForDistrict?id=28dc65ad-fff5-447b-99a3-95b71b4a7d1e";
            var response = await _client.GetAsync($"{action}&district={districtName}&apikey={_apiKey}");
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            var welcome = Welcome.FromJson(jsonString);

            if(!welcome.Result.Success)
            {
                return new List<DomainModel.Notification>();
            }

            return welcome.Result.Result.Notifications.ToDomainModel();
        }
    }
}