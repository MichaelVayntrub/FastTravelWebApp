using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastTravel.Models
{
    public class PetTicket
    {
        [Key]
        public int petTicketID { get; set; }

        public string name { get; set; } = "unknown";

        public float weight { get; set; }

        [ForeignKey("animalId")]
        public int animalID { get; set; }
    }
}
