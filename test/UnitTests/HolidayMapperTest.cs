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
    public class HolidayMapperTest
    {
        [Fact]
        public void HolidayMapper_Maps_Correctly()
        {
            var year = DateTime.Now.Year;
            var mapper = new HolidayMapper();
            var source = new ApiHoliday()
            {
                description = "Foo",
                date = new HolidayDate()
                {
                    datetime = new HolidayDatetime()
                    {
                        year = year,
                        day = 1,
                        month = 1
                    },
                    iso = $"{year}-01-01"
                },
                type = new [] { "National holiday" },
                locations = "All",
                states = "All",
                country = new HolidayCountry()
                {
                    id="IN",
                    name = "India"
                },
                name = "Foo Bar"
            };
            var destination = new Holiday();
            destination = mapper.Convert(source, destination, null);
            destination.ShouldNotBeNull();
            destination.Name.ShouldBe("Foo Bar");
            destination.Description.ShouldBe("Foo");
            destination.Country.Iso3166.ShouldBe("IN");
            destination.Country.CountryName.ShouldBe("India");
            destination.Date.ToString("yyyy-MM-dd").ShouldBe($"{year}-01-01");
            destination.Locations.ShouldBe("All");
            destination.States.ShouldBe("All");
            destination.Type.ShouldHaveSingleItem();
            destination.Type[0].ShouldBe("National holiday");
        }
    }
}
