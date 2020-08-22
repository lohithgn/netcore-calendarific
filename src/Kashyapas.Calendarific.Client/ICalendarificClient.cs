using System.Threading.Tasks;
using Kashyapas.Calendarific.Client.Internal;
using Kashyapas.Calendarific.Client.Models;
using Newtonsoft.Json.Linq;
using Refit;

namespace Kashyapas.Calendarific.Client
{
    public interface ICalendarificClient
    {
        [Get("/countries")]
        public Task<ApiResponse<CalendarificApiResponse<CountriesResponse>>> GetCountries();

        [Get("/holidays")]
        public Task<ApiResponse<CalendarificApiResponse<HolidaysResponse>>> GetHolidays(HolidayParameters holidayParameters);
    }
}
