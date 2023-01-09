using System.ComponentModel.DataAnnotations;

namespace FastTravel.Models
{
    public class Port
    {
        [Key]
        public int portID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string country { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string city { get; set; }
    }
}
