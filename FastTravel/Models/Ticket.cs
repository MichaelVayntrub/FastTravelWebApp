using Microsoft.OData.Edm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string gender { get; set; }

        [Required]
        public Date BirthDate { get; set; }

        [ForeignKey("Order")]
        public int orderID { get; set; }

        [Required]
        public TicketType ticketType { get; set; }
    }
}
