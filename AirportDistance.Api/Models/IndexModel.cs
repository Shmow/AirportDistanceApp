using System;
using System.Collections.Generic;
using System.Linq;
using Nancy;

namespace AirportDistance.Api.Models
{
    public class IndexModel : RequestModel
    {
        public string DepartureAirport => GetQuery("departureAirport");
        public string ArrivalAirport => GetQuery("arrivalAirport");
        public AirportResponse[] Airports { get; internal set; }
        public double Distance { get; internal set; }
        public string GoogleMapsUrl { get; internal set; }

        public IndexModel() : base() { } 

        public IndexModel(DynamicDictionary query) : base()
        {
            Query = query.ToDictionary();
        }

        public void Fill(AirportResponse airport1, AirportResponse airport2, double distanceInMeters)
        {
            ContainsData = true;
            Airports = new[]
                       {
                           airport1,
                           airport2
                       };

            Distance = Math.Round(distanceInMeters / 1000);
        }

        public string GetQuery(string key)
        {
            return Query.ContainsKey(key)
                       ? Query[key].ToString()
                       : string.Empty;
        }
    }
}