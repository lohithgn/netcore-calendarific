using Kashyapas.Calendarific.Client.Internal;

namespace Kashyapas.Calendarific.Client
{
    public class CalendarificOptions
    {
        /// <summary>
        /// The Calendarific api key.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// The Calendarific api uri.
        /// </summary>
        public string ApiUri { get; set; } = CalendarificDefaults.ApiUri;

        /// <summary>
        /// The Calendarific api version.
        /// </summary>
        public string ApiVersion { get; set; } = CalendarificDefaults.ApiVersion;
    }
}
