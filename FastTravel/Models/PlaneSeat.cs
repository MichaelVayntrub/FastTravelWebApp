using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastTravel.Models
{
    [ComplexType]
    public class PlaneSeat
    {
        [Required]
        public int number { get; set; }

        [Required]
        public bool available { get; set; } = true;
    }
}
