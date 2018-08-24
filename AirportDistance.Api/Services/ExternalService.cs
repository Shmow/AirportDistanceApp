using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using AirportDistance.Api.Services;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace AirportDistance.Api
{
    public class ExternalService : IExternalService
    {
        private readonly AppConfig _config;

        public ExternalService(IOptions<AppConfig> config)
        {
            _config = config.Value;
        }

        public AirportResponse GetAirportData(string iataCode)
        {
            return GetAirportsData(new[] { iataCode }).Result[0];
        }

        public async Task<AirportResponse[]> GetAirportsData(string[] iataCodes)
        {
            var result = new List<AirportResponse>();

            using (var client = new HttpClient())
            {
                foreach (var iataCode in iataCodes)
                {
                    try
                    {
                        var dRes = await client.GetAsync($"{_config.ExternalAirportApiUrl}{iataCode}");
                        var dContent = await dRes.Content.ReadAsStringAsync();
                        result.Add(JsonConvert.DeserializeObject<AirportResponse>(dContent));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"[ERR] Error getting data for {iataCode}: {ex.Message}");
                    }
                }
            }

            return result.ToArray();
        }
    }
}