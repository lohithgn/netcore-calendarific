using System.Threading.Tasks;
using Kashyapas.Calendarific.Client.Models;

namespace Kashyapas.Calendarific.Client
{
    public interface ICalendarificService
    {
        /// <summary>
        /// This endpoint provides a list of countries and languages that we support. This is useful for getting an index of all countries and the ISO codes programmatically.
        /// </summary>
        /// <returns></returns>
        public Task<Country[]> GetCountries();
        
        /// <summary>
        /// This provides a list of holidays based on the parameters passed to it.
        /// </summary>
        /// <param name="holidayParameters">Parameters to search holidays</param>
        /// <returns>List of <see cref="Holiday"/>Holiday</returns>
        public Task<Holiday[]> GetHolidays(HolidayParameters holidayParameters);
    }
}
