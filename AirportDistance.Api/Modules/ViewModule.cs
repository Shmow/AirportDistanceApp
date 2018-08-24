using System.Collections.Generic;
using AirportDistance.Api.Models;
using AirportDistance.Api.Services;
using Microsoft.Extensions.Options;
using Nancy;
using Nancy.ModelBinding;
using System.Linq;
using System.Threading.Tasks;

namespace AirportDistance.Api.Modules
{
    public sealed class ViewModule : NancyModule
    {
        private readonly AppConfig _config;
        private readonly IExternalService _externalService;
        private readonly ICalculationService _calculationService;

        public ViewModule(IOptions<AppConfig> config,
                          IExternalService externalService,
                          ICalculationService calculationService)
        {
            _config = config.Value;
            _externalService = externalService;
            _calculationService = calculationService;

            Get("/", args => View["Index", new IndexModel()]);
            Get("/getAirports", async (x, ct) =>
                                {
                                    var indexModel = new IndexModel(Request.Query as DynamicDictionary);
                                    var request = this.Bind<GetAirportsRequest>();

                                    var errors = request.Validate();

                                    if (errors.Any())
                                        indexModel.Errors = errors;
                                    else
                                        await BuildIndexModel(indexModel, request);

                                    return View["Index", indexModel];
                                });
        }

        private async Task<IndexModel> BuildIndexModel(IndexModel model, GetAirportsRequest req)
        {
            var extResult = await _externalService.GetAirportsData(new[] { req.DepartureAirport, req.ArrivalAirport });

            if (extResult.Length == 2)
            {
                var calcResult = _calculationService.CalculateGeoDistance(extResult[0].Location, extResult[1].Location);

                model.Fill(extResult[0], extResult[1], calcResult);
                model.GoogleMapsUrl = $"{_config.GoogleMapsDirectionsEmbedUrl}?origin={extResult[0].Location.LatLonFormatted}&destination={extResult[1].Location.LatLonFormatted}&mode=flying&key={_config.GoogleMapsApiKey}";
            }
            else
            {
                model.Errors.Add("External service return invalid result.");
            }

            return model;
        }
    }
}
