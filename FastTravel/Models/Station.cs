using Microsoft.OData.Edm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastTravel.Models
{
    public class Station
    {
        [Key]
        public int stationID { get; set; }

        [Key]
        public int order { get; set; }

        [Required]
        public Date data { get; set; }

        [Required]
        public TimeOfDay time { get; set; }

        [ForeignKey("portID")]
        public int portID { get; set; }
    }
}
