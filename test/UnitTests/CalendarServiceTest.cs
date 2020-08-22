using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Kashyapas.Calendarific.Client.Internal;
using Kashyapas.Calendarific.Client.Models;
using NSubstitute;
using Refit;
using Shouldly;
using Xunit;

namespace Kashyapas.Calendarific.Client.UnitTests
{
    public class CalendarServiceTest
    {
        private readonly IMapper _mapper;
        private ICalendarificService _subjectUnderTest;
        private readonly ICalendarificClient _calendarificClient;
        public CalendarServiceTest()
        {
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile<CalendarificMappingProfile>();
            });

            _mapper = config.CreateMapper();
            _calendarificClient = Substitute.For<ICalendarificClient>();
        }

        [Fact]
        public async Task GetCountries_Returns_ValidData()
        {
            var content = new CalendarificApiResponse<CountriesResponse>()
            {
                meta = new Meta() {code = 200},
                response = new CountriesResponse()
                {
                    countries = new[]
                    {
                        new ApiCountry()
                        {
                            country_name = "India",
                            iso3166 = "IN",
                            supported_languages = 2,
                            total_holidays = 33,
                            uuid = "foo"
                        }
                    }
                }
            };
            _calendarificClient.GetCountries()
                .Returns(new ApiResponse<CalendarificApiResponse<CountriesResponse>>(Substitute.For<HttpResponseMessage>(), content));
            _subjectUnderTest = new CalendarificService(_mapper, _calendarificClient);
            var countries = await _subjectUnderTest.GetCountries();
            countries.Length.ShouldBe(1);
            countries.ElementAt(0).CountryName.ShouldBe("India");
            countries.ElementAt(0).Iso3166.ShouldBe("IN");
            countries.ElementAt(0).SupportedLanguages.ShouldBe(2);
            countries.ElementAt(0).TotalHolidays.ShouldBe(33);
            countries.ElementAt(0).Uuid.ShouldBe("foo");
        }

        [Fact]
        public async Task GetHolidays_Throws_Exception_When_InValidData()
        {
            var content = new CalendarificApiResponse<HolidaysResponse>()
            {
                meta = new Meta()
                {
                    code = 404, 
                    error_type = "call failed", 
                    error_detail = @"Missing required call parameters. See https:\/\/calendarific.com\/ for details."
                },
                response = null
            };
            _calendarificClient.GetHolidays(Arg.Any<HolidayParameters>())
                .Returns(new ApiResponse<CalendarificApiResponse<HolidaysResponse>>(Substitute.For<HttpResponseMessage>(), content));
            _subjectUnderTest = new CalendarificService(_mapper, _calendarificClient);
            await Should.ThrowAsync<InvalidOperationException>(async () => await _subjectUnderTest.GetHolidays(new HolidayParameters()));
        }

        [Fact]
        public async Task GetHolidays_Returns_ValidData()
        {
            var content = new CalendarificApiResponse<HolidaysResponse>()
            {
                meta = new Meta(){code = 200},
                response = new HolidaysResponse()
                {
                    holidays = new []
                    {
                        new ApiHoliday()
                        {
                            country = new HolidayCountry(){id = "IN", name = "India"},
                            name = "New Year's Day",
                            date = new HolidayDate(){
                                datetime = new HolidayDatetime
                                {
                                    day=1,
                                    month=1,
                                    year=DateTime.Now.Year
                                },
                                iso=$"{DateTime.Now.Year}-01-01"
                            },
                            description = "New Year's Day",
                            locations = "All",
                            states = "All",
                            type = new [] {"National holiday"}
                        }
                    }
                }
            };
            _calendarificClient.GetHolidays(Arg.Any<HolidayParameters>())
                .Returns(new ApiResponse<CalendarificApiResponse<HolidaysResponse>>(Substitute.For<HttpResponseMessage>(), content));
            _subjectUnderTest = new CalendarificService(_mapper, _calendarificClient);
            var holidays = await _subjectUnderTest.GetHolidays(new HolidayParameters());
            holidays.Length.ShouldBe(1);
            var holiday = holidays.ElementAt(0);
            holiday.Country.CountryName.ShouldBe("India");
            holiday.Country.Iso3166.ShouldBe("IN");
            holiday.Name.ShouldBe("New Year's Day");
            holiday.Description.ShouldBe("New Year's Day");
            holiday.Locations.ShouldBe("All");
            holiday.States.ShouldBe("All");
            holiday.Date.ToString("yyyy-MM-dd").ShouldBe($"{DateTime.Now.Year}-01-01");
        }
    }
}
