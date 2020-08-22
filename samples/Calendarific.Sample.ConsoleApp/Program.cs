using System;
using System.IO;
using System.Threading.Tasks;
using Kashyapas.Calendarific.Client;
using Kashyapas.Calendarific.Client.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Calendarific.Samples.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Add Configuration
            var configuration = new ConfigurationBuilder()  
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();
            //Setup DI
            var serviceProvider = new ServiceCollection()
                .AddCalendarific(options => configuration.GetSection("Calendarific").Bind(options))
                .BuildServiceProvider();
            var service = serviceProvider.GetService<ICalendarificService>();
            
            //Get Countries
            var countries = await service.GetCountries();
            Console.WriteLine($"Countries : {countries.Length}");

            //Get Holidays
            Random r = new Random();
            var country = countries[r.Next(countries.Length)];
            var holidays = await service.GetHolidays(new HolidayParameters()
            {
                Country = country.Iso3166,
                Year = DateTime.Now.Year
            });
            Console.WriteLine($"Country: {country.CountryName}, Year:{DateTime.Now.Year}, Holidays : {holidays.Length}");
            
            Console.ReadLine();
        }
    }
}
