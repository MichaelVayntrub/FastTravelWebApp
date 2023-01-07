using System.ComponentModel.DataAnnotations;

namespace FastTravel.Models
{
    public class Port
    {
        [Key]
        public int portID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string country { get; set; }

        [Required]
        public string city { get; set; }
    }
}
