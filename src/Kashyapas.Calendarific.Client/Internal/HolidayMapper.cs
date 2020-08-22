using System;
using AutoMapper;
using Kashyapas.Calendarific.Client.Models;

namespace Kashyapas.Calendarific.Client.Internal
{
    internal class HolidayMapper : ITypeConverter<ApiHoliday, Holiday>
    {
        public Holiday Convert(ApiHoliday source, Holiday destination, ResolutionContext context)
        {
            var year = source.date.datetime.year;
            var month = source.date.datetime.month;
            var day = source.date.datetime.day;
            
            destination = new Holiday()
            {
                Name = source.name,
                Description = source.description,
                Country = new Country()
                {
                    CountryName = source.country.name,
                    Iso3166 = source.country.id
                },
                Date = new DateTime(year,month,day),
                Type = source.type,
                Locations = source.locations,
                States = source.states,
            };
            return destination;
        }
    }
}
