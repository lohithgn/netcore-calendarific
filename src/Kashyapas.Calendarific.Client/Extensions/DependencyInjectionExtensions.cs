using System;
using AutoMapper;
using Kashyapas.Calendarific.Client.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Kashyapas.Calendarific.Client
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddCalendarific(this IServiceCollection services,
            Action<CalendarificOptions> configureCalendarificOptions)
        {
            var calendarificOptions = new CalendarificOptions();
            configureCalendarificOptions(calendarificOptions);
            services.AddSingleton(calendarificOptions);
            services.AddSingleton<CalendarificSecurityMessageHandler>();
            services.AddHttpClient("calendarific",c =>
                {
                    c.BaseAddress = new Uri($"{calendarificOptions.ApiUri}/{calendarificOptions.ApiVersion}");
                })
                .AddTypedClient(Refit.RestService.For<ICalendarificClient>)
                .AddHttpMessageHandler<CalendarificSecurityMessageHandler>();
            services.AddSingleton<ICalendarificService, CalendarificService>();
            services.AddAutoMapper(typeof(CalendarificMappingProfile));
            return services;
        }
    }
}
