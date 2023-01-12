using Microsoft.OData.Edm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastTravel.Models
{
    public class Flight
    {
        [Required]
        public int flightNumber { get; set; }

        [Required]
        public Port source { get; set; }

        public DateTime dateFrom { get; set; }

        [Required]
        public Port destination { get; set; }

        public DateTime dateTo { get; set; }

        public Port? stop1 { get; set; }

        public DateTime? date1 { get; set; }

        public Port? stop2 { get; set; }

        public DateTime? date2 { get; set; }

        public Plane plane { get; set; }

        public float child { get; set; } = 0;
        public float adult { get; set; } = 0;
        public float elder { get; set; } = 0;
    }
}
