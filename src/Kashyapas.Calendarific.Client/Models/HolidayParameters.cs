using System;
using System.Collections.Generic;
using System.Text;
using Refit;

namespace Kashyapas.Calendarific.Client.Models
{
    public class HolidayParameters
    {
        /// <summary>
        /// The country parameter must be in the iso-3166 format as specified in the document here.
        /// To view a list of countries and regions supported, visit Calendarific list of supported countries.
        /// </summary>
        [AliasAs("country")]
        public string Country { get; set; }

        /// <summary>
        /// The year you want to return the holidays. Currently supports both historical and future years until 2049.
        /// The year must be specified as a number eg, 2019
        /// </summary>
        [AliasAs("year")]
        public int Year { get; set; } = DateTime.Now.Year;

        /// <summary>
        /// Limits the number of holidays to a particular day. Must be passed as the numeric value of the day [1..31].
        /// </summary>
        [AliasAs("day")]
        public int? Day { get; set; }

        /// <summary>
        /// Limits the number of holidays to a particular month. Must be passed as the numeric value of the month [1..12].
        /// </summary>
        [AliasAs("month")]
        public string Month { get; set; } = null;

        /// <summary>
        /// Calendarific supports multiple counties, states and regions for all the countries they support.
        /// This optional parameter allows you to limit the holidays to a particular state or region.
        /// <para>The value of field is iso-3166 format of the state.
        /// View a list of supported countries and states on Calendarific site.</para>
        /// <para>An example is, for New York state in the United States, it would be us-ny</para>
        /// </summary>
        [AliasAs("location")]
        public string Location { get; set; } = null;

        /// <summary>
        /// <para>We support multiple types of holidays and observances. This parameter allows users to return only a particular type of holiday or event.</para>
        /// <para>By default, the API returns all holidays. Below is the list of holiday types supported by the API and this is how to reference them.</para>
        /// <list type="bullet">
        /// <item>
        /// <description>national - Returns public, federal and bank holidays</description>
        /// </item>
        /// <item>
        /// <description>local - Returns local, regional and state holidays</description>
        /// </item>
        /// <item>
        /// <description>religious - Return religious holidays: buddhism, christian, hinduism, muslim, etc</description>
        /// </item>
        /// <item>
        /// <description>observance - Observance, Seasons, Times</description>
        /// </item>
        /// </list>
        /// </summary>
        [AliasAs("type")]
        public string Type { get; set; } = null;
    }
}
