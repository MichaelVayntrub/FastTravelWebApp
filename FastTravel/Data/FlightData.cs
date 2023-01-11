using FastTravel.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastTravel.Data
{
    public class FlightData
    {
        public int flightNumber { get; set; }
        public int source { get; set; }
        public int destination { get; set; }
        public int stop1 { get; set; }
        public int stop2 { get; set; }
        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }
        public int plane { get; set; }
        public float child { get; set; }
        public float adult { get; set; }
        public float elder { get; set; }
    }
}
