using Newtonsoft.Json;

namespace Kashyapas.Calendarific.Client
{
    public class CalendarificApiResponse<T>
    {
        public Meta meta { get; set; }
        public T response { get; set; }
    }

    public class Meta
    {
        public int code { get; set; }
        public string error_type { get; set; }
        public string error_detail { get; set; }
    }

    public class CountriesResponse
    {
        public string url { get; set; }
        public ApiCountry[] countries { get; set; }
    }
    public class ApiCountry
    {
        public string country_name { get; set; }
        [JsonProperty("iso-3166")]
        public string iso3166 { get; set; }
        public int total_holidays { get; set; }
        public int supported_languages { get; set; }
        public string uuid { get; set; }
    }

    public class HolidaysResponse
    {
        public string url { get; set; }
        public ApiHoliday[] holidays { get; set; }
    }
    public class ApiHoliday
    {
        public string name { get; set; }
        public string description { get; set; }
        public HolidayCountry country { get; set; }
        public HolidayDate date { get; set; }
        public string[] type { get; set; }
        public string locations { get; set; }
        public string states { get; set; }
    }

    public class HolidayCountry
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class HolidayDate
    {
        public string iso { get; set; }
        public HolidayDatetime datetime { get; set; }
    }

    public class HolidayDatetime
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
    }
}
