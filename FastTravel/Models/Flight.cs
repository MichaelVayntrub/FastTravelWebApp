using System.ComponentModel.DataAnnotations;

namespace FastTravel.Models
{
    public class Flight
    {
        [Key]
        public int flightNumber { get; set; }
    }
}
