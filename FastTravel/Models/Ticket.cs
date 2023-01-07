using Microsoft.OData.Edm;
using System.ComponentModel.DataAnnotations;

namespace FastTravel.Models
{
    public class Ticket
    {
        [Key]
        public int ticketID { get; set; }

        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public int ID { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string gender { get; set; }

        [Required]
        public Date BirthDate { get; set; }
    }
}
