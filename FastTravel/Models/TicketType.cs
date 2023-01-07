using System.ComponentModel.DataAnnotations;

namespace FastTravel.Models
{
    public class TicketType
    {
        [Key]
        public int ticketTypeID { get; set; }

        [Required]
        public string name { get; set; }
        
        [Required]
        public float price { get; set; }
    }
}
