using System.ComponentModel.DataAnnotations;

namespace FastTravel.Models
{
    public class Credit
    {
        [Key]
        public int creditID { get; set; }

        [Required]
        public string fullName { get; set; }

        [Required]
        public int creditNum { get; set; }

        [Required]
        public string expiredDate { get; set; }

        [Required]
        public int expiredYear { get; set; }

        [Required]
        public int securityCode { get; set; }

        [Required]
        public string userID { get; set; }   
    }
}
