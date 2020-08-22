using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Kashyapas.Calendarific.Client.Internal;
using Kashyapas.Calendarific.Client.Models;
using Newtonsoft.Json.Linq;

namespace Kashyapas.Calendarific.Client
{
    public class CalendarificService : ICalendarificService
    {
        private readonly IMapper _mapper;
        private readonly ICalendarificClient _calendarificClient;

        public CalendarificService(IMapper mapper, ICalendarificClient calendarificClient)
        {
            _mapper = mapper;
            _calendarificClient = calendarificClient;
        }

        public async Task<Country[]> GetCountries()
        {
            var data = await _calendarificClient.GetCountries();
            await data.EnsureSuccessStatusCodeAsync();
            data.Content.EnsureSuccessStatusCode();
            var countries = _mapper.Map<ApiCountry[],Country[]>(data.Content.response.countries);
            return countries;
        }

        public async Task<Holiday[]> GetHolidays(HolidayParameters holidayParameters)
        {
            var data = await _calendarificClient.GetHolidays(holidayParameters);
            await data.EnsureSuccessStatusCodeAsync();
            data.Content.EnsureSuccessStatusCode();
            var holidays = _mapper.Map<ApiHoliday[],Holiday[]>(data.Content.response.holidays);
            return holidays;
        }
    }
}
