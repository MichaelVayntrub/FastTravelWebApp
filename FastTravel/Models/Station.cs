using Microsoft.OData.Edm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastTravel.Models
{
    [ComplexType]
    public class Station
    {
        [Key]
        public int order { get; set; }

        [Required]
        public Date date { get; set; }

        [Required]
        public TimeOfDay time { get; set; }

        [ForeignKey("portID")]
        public int port { get; set; }
    }
}
