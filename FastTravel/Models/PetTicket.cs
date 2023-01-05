using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastTravel.Models
{
    public class PetTicket
    {
        [Key]
        public int petTicketID { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z]+", ErrorMessage = "Not a valid name")]
        public string name { get; set; }

        [RegularExpression(@"[0-9]+"+@"(\.[0-9]+)*", ErrorMessage = "Not a valid weight")]
        public float weight { get; set; }

        [ForeignKey("animalId")]
        public int animalID { get; set; }
    }
}
