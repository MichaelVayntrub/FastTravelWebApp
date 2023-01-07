using System.ComponentModel.DataAnnotations;

namespace FastTravel.Models
{
    public class Plane
    {
        [Key]
        public int planeID { get; set; }

        [Required]
        public int seatsNum { get; set; }

        [Required]
        public string company { get; set; }
    }
}
