using FastTravel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastTravel.Data
{
    public class FlightData
    {
        [Key]
        public int flightNumber { get; set; }

        [Required]
        public int source { get; set; }

        [Required]
        public DateTime dateFrom { get; set; }

        [Required]
        public int destination { get; set; }

        [Required]
        public DateTime dateTo { get; set; }

        public int? stop1 { get; set; }
        public DateTime? date1 { get; set; }
        public int? stop2 { get; set; }
        public DateTime? date2 { get; set; }

        [Required]
        public int plane { get; set; }

        [Required]
        public float child { get; set; }

        [Required]
        public float adult { get; set; }

        [Required]
        public float elder { get; set; }

        [Required]
        public int stops { get; set; }
        [Required]
        public int seatsRemain { get; set; }
        [Required]
        public int seatsUsed { get; set; }
    }
}
