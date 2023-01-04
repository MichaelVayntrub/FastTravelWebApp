using System.ComponentModel.DataAnnotations;

namespace FastTravel.Models
{
    public class Luggage
    {
        [Key]
        public int luggageID { get; set; }
        public string luggageType { get; set; } = "Small";
        public float maxWeight { get; set; }
        public float price { get; set; }
    }
}
