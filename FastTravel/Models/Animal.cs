using System.ComponentModel.DataAnnotations;

namespace FastTravel.Models
{
    public class Animal
    {
        [Key]
        public int animalID { get; set; }

        [Required(ErrorMessage = "Animal type is required")]
        public string animalType { get; set; }

        [Required(ErrorMessage = "Max weight is required")]
        public float maxWeight { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public float price { get; set; }
    }
}
