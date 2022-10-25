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
                Locations = source.locations
            };

            // 2022-10-25 Oleg Rumiancev: checking is states are string as some returned entries
            // from Calendarific API return JSON object array instead of string (try country CA - Canada)
            // non-string state values are ignored
            if (source.states is string)
            {
                destination.States = source.states as string;
            }
            return destination;
        }
    }
}
