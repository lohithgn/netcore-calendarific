using System.Runtime.CompilerServices;
using AutoMapper;
using Kashyapas.Calendarific.Client.Models;

[assembly:InternalsVisibleTo("Kashyapas.Calendarific.Client.UnitTests")]

namespace Kashyapas.Calendarific.Client.Internal
{
    internal class CountryMapper : ITypeConverter<ApiCountry, Country>
    {
        public Country Convert(ApiCountry source, Country destination, ResolutionContext context)
        {
            destination = new Country()
            {
                CountryName = source.country_name,
                Iso3166 = source.iso3166,
                TotalHolidays = source.total_holidays,
                SupportedLanguages = source.supported_languages,
                Uuid = source.uuid
            };
            return destination;
        }
    }
}
