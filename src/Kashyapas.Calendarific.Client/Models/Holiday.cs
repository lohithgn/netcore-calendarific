using System;

namespace Kashyapas.Calendarific.Client.Models
{
    public class Holiday
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Country Country { get; set; }
        public DateTime Date { get; set; }
        public string[] Type { get; set; }
        public string Locations { get; set; }
        public string States { get; set; }
    }
}
