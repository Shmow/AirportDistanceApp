using System.Collections.Generic;

namespace AirportDistance.Api.Models
{
    public class RequestModel
    {
        public IDictionary<string, object> Query { get; set; }
        public IList<string> Errors { get; set; }
        public bool ContainsData { get; set; }

        public RequestModel()
        {
            Query = new Dictionary<string, object>();
            Errors = new List<string>();
            ContainsData = false;
        }
    }
}