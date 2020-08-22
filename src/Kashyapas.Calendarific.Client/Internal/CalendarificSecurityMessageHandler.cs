using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Kashyapas.Calendarific.Client
{
    internal class CalendarificSecurityMessageHandler : DelegatingHandler
    {
        private readonly CalendarificOptions _options;

        public CalendarificSecurityMessageHandler(CalendarificOptions options)
        {
            _options = options;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var separator = "&";
            if (request.RequestUri.Query.IndexOf("?",StringComparison.InvariantCultureIgnoreCase) == -1)
            {
                separator = "?";
            }
            request.RequestUri = new Uri($"{request.RequestUri}{separator}api_key={_options.ApiKey}");
            return base.SendAsync(request, cancellationToken);
        }
    }
}
