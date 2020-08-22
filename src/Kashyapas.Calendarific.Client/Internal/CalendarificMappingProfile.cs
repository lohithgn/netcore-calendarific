using System.Runtime.CompilerServices;
using AutoMapper;
using Kashyapas.Calendarific.Client.Models;

[assembly:InternalsVisibleTo("Kashyapas.Calendarific.Client.UnitTests")]

namespace Kashyapas.Calendarific.Client.Internal
{
    internal class CalendarificMappingProfile : Profile
    {
        public CalendarificMappingProfile()
        {
            CreateMap<ApiCountry,Country>().ConvertUsing<CountryMapper>();
            CreateMap<ApiHoliday,Holiday>().ConvertUsing<HolidayMapper>();
        }
    }
}
