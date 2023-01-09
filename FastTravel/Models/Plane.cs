using System.ComponentModel.DataAnnotations;

namespace FastTravel.Models
{
    public class Plane
    {
        [Key]
        public int planeID { get; set; }

        [Required(ErrorMessage = "Number of seats is required.")]
        public int seatsNum { get; set; }

        [Required(ErrorMessage = "Company is required.")]
        public string company { get; set; }
    }
}
