using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AirportDistance.Api.Models
{
    public class GetAirportsRequest
    {
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }

        private Regex IataRegex => new Regex(@"^[A-Za-z]{3}$");

        public List<string> Validate()
        {
            var errors = new List<string>();

            if (!IataRegex.IsMatch(DepartureAirport))
                errors.Add("Field 'Departure' is invalid.");
            if (!IataRegex.IsMatch(ArrivalAirport))
                errors.Add("Field 'Arrival' is invalid.");

            return errors;
        }
    }
}