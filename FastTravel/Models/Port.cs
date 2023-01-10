using System.ComponentModel.DataAnnotations;

namespace FastTravel.Models
{
    public class Port
    {
        [Key]
        public int portID { get; set; }

        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Country must contain letters only.")]
        [Required(ErrorMessage = "Country is required.")]
        public string country { get; set; }

        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "City must contain letters only.")]
        [Required(ErrorMessage = "City is required.")]
        public string city { get; set; }

        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Name must contain letters only.")]
        [Required(ErrorMessage = "Name is required.")]
        public string name { get; set; }
    }
}
