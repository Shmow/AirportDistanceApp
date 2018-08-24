using GeoCoordinatePortable;

namespace AirportDistance.Api
{
    public class CalculationService : ICalculationService
    {
        public double CalculateGeoDistance(Location location1, Location location2)
        {
            var coordinate1 = new GeoCoordinate(location1.Lat, location1.Lon);
            var coordinate2 = new GeoCoordinate(location2.Lat, location2.Lon);

            return coordinate1.GetDistanceTo(coordinate2);
        }
    }
}