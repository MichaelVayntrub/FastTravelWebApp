using System.ComponentModel.DataAnnotations;

namespace FastTravel.Models
{
    public class Animal
    {
        [Key]
        public int animalID { get; set; }
        public string animalType { get; set; }
        public float maxWeight { get; set; }
        public float price { get; set; }
    }
}
