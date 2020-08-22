using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Kashyapas.Calendarific.Client.Internal;
using Kashyapas.Calendarific.Client.Models;
using NSubstitute;
using Shouldly;
using Xunit;

namespace Kashyapas.Calendarific.Client.UnitTests
{
    public class CountryMapperTest
    {
        [Fact]
        public void CountryMapper_Maps_Correctly()
        {
            var mapper = new CountryMapper();
            var source = new ApiCountry()
            {
                iso3166 = "IN",
                total_holidays = 22,
                supported_languages = 2,
                uuid = "foo",
                country_name = "India"
            };
            var destination = new Country();
            destination = mapper.Convert(source, destination, null);
            destination.ShouldNotBeNull();
            destination.CountryName.ShouldBe("India");
            destination.Iso3166.ShouldBe("IN");
            destination.TotalHolidays.ShouldBe(22);
            destination.Uuid.ShouldBe("foo");
            destination.SupportedLanguages.ShouldBe(2);
        }
    }
}
