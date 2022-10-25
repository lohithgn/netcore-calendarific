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

        // 2022-10-25 Oleg Rumiancev: changing from string to object as some returned entries
        // from Calendarific API return JSON object array instead of string (try country CA - Canada)
        public object States { get; set; }
    }
}
