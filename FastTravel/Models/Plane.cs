using System.ComponentModel.DataAnnotations;

namespace FastTravel.Models
{
    public class Plane
    {
        [Key]
        public int planeID { get; set; }

        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Company must contain letters only.")]
        [Required(ErrorMessage = "Company is required.")]
        public string company { get; set; }

        
        [RegularExpression(@"[1-9]"+@"[0-9]*", ErrorMessage = "Number of seats must contain numbers only.")]
        [Required(ErrorMessage = "Number of seats is required.")]
        public int seatsNum { get; set; }

    }
}
