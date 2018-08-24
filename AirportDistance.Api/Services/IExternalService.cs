using System.Threading.Tasks;

namespace AirportDistance.Api
{
    public interface IExternalService
    {
        AirportResponse GetAirportData(string iataCode);
        Task<AirportResponse[]> GetAirportsData(string[] iataCodes);
    }
}