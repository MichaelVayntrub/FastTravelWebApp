using Microsoft.OData.Edm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastTravel.Models
{
    public class Flight
    {
        [Key]
        public int flightNumber { get; set; }

        [Required]
        public Port source { get; set; }

        [Required]
        public Port destination { get; set; }

        public Port? stop1 { get; set; }

        public Port? stop2 { get; set; }

        public Date dateFrom { get; set; }
        public Date dateTo { get; set; }

        [Required]
        [ForeignKey("planeID")]
        public int plane { get; set; }
    }
}
