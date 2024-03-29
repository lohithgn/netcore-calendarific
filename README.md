![Build status](https://github.com/lohithgn/netcore-calendarific/workflows/Continuous%20Integration/badge.svg)

# netcore-calendarific
.NET Core Client for Calendarific API. You can know more about Calendarific API [here](https://calendarific.com/api-documentation).


# Usage
1. Install the nuget package
    ```
    dotnet add package Kashyapas.Calendarific.Client
    ```

2. Create Calendarific section in your configuration as below:
    ```
    "Calendarific": {
        "ApiKey": "<Calendarific Api Key>",
        "ApiUri": "https://calendarific.com/api",
        "ApiVersion": "v2"
    } 
    ```
3. In your Startup, add AddCalendarific() to your services collection as below:
   ```
   AddCalendarific(options => configuration.GetSection("Calendarific").Bind(options))
   ```

4. Inject ICalendarificService where needed. ICalendarificService exposes following methods:
   ```
   - Task<Country[]> GetCountries()
   - Task<Holiday[]> GetHolidays(HolidatParameters parameters)
   ```
   
   # Samples
   You will find a .net core console app in the samples folder. Here is the code snippet of using Calendarific Client in a .net core console app
   ```
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
   ```

# License
MIT