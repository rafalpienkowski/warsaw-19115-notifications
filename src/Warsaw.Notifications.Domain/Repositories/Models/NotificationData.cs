using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Warsaw.Notifications.Domain.Repositories.Models
{
    
    /// <summary>
    /// https://app.quicktype.io/ used
    /// </summary>
    internal partial class Welcome
    {
        [JsonProperty("result")]
        public WelcomeResult Result { get; set; }
    }

    internal partial class WelcomeResult
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("result")]
        public ResultResult Result { get; set; }
    }

    internal partial class ResultResult
    {
        [JsonProperty("notifications")]
        public Notification[] Notifications { get; set; }

        [JsonProperty("responseDesc")]
        public string ResponseDesc { get; set; }

        [JsonProperty("responseCode")]
        public string ResponseCode { get; set; }
    }

    internal partial class Notification
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("subcategory")]
        public string Subcategory { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("aparmentNumber")]
        public object AparmentNumber { get; set; }

        [JsonProperty("street2")]
        public string Street2 { get; set; }

        [JsonProperty("notificationType")]
        public string NotificationType { get; set; }

        [JsonProperty("createDate")]
        public long CreateDate { get; set; }

        [JsonProperty("siebelEventId")]
        public string SiebelEventId { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("yCoordOracle")]
        public double YCoordOracle { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("deviceType")]
        public string DeviceType { get; set; }

        [JsonProperty("statuses")]
        public Status[] Statuses { get; set; }

        [JsonProperty("xCoordOracle")]
        public double XCoordOracle { get; set; }

        [JsonProperty("notificationNumber")]
        public string NotificationNumber { get; set; }

        [JsonProperty("yCoordWGS84")]
        public long YCoordWgs84 { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("xCoordWGS84")]
        public long XCoordWgs84 { get; set; }
    }

    internal partial class Status
    {
        [JsonProperty("status")]
        public string StatusStatus { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("changeDate")]
        public long ChangeDate { get; set; }
    }

    internal partial class Welcome
    {
        internal static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, Converter.Settings);
    }

    internal static class Serialize
    {
        internal static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}