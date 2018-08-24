namespace AirportDistance.Api
{
    public interface ICalculationService
    {
        double CalculateGeoDistance(Location location1, Location location2);
    }
}