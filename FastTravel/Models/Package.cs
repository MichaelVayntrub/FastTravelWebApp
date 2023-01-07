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
        public int flightNumber { get; set; }

        [ForeignKey("userID")]
        public int userID { get; set; }
    }
}
