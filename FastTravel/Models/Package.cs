using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastTravel.Models
{
    public class Package
    {
        [Key]
        public int packageID { get; set; }

        [Required]
        public string image { get; set; }

        [ForeignKey("flightNumber")]
        public Flight flight1 { get; set; }

        [ForeignKey("flightNumber")]
        public Flight flight2 { get; set; }

        [ForeignKey("userID")]
        public string userID { get; set; }

        public bool twoWay { get; set; }
    }
}
