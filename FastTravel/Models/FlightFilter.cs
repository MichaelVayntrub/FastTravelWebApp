using Microsoft.OData.Edm;

namespace FastTravel.Models
{
    public class FlightFilter
    {
        public Port? destination { get; set; }
        public Date? dateFrom { get; set; }
        public Date? dateTo { get; set; }
    }
}
