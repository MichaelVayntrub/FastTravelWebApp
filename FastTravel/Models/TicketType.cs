using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastTravel.Models
{
    [ComplexType]
    public class TicketType
    {
        [Required]
        public string name { get; set; }
        
        [Required]
        public float price { get; set; }

        [ForeignKey("Flight")]
        public int flightNumber { get; set; }
    }
}
