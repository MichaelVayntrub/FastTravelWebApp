using System.ComponentModel.DataAnnotations;

namespace FastTravel.Models
{
    public class Luggage
    {
        [Key]
        public int luggageID { get; set; }
        [Required]
        public string luggageType { get; set; }
        [Required]
        public float maxWeight { get; set; }
        [Required]
        public float price { get; set; }
    }
}
