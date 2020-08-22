using System;
using System.Net;

namespace Kashyapas.Calendarific.Client.Internal
{
    internal static class CalendarificExtensions
    {
        internal static void EnsureSuccessStatusCode<T>(this CalendarificApiResponse<T> response)
        {
            if(response.meta.code != (int)HttpStatusCode.OK)
                throw new InvalidOperationException($"{response.meta.code}:{response.meta.error_detail}");
        }
    }
}
