using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastTravel.Models
{
    public class Flight
    {
        [Key]
        public int flightNumber { get; set; }

        [Required]
        public int portSource { get; set; }

        [Required]
        public int portDestination { get; set; }

        [Required]
        [ForeignKey("planeID")]
        public int plane { get; set; }
    }
}
