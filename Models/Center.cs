using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUDSystem.Models
{
    public class Center
    {
        [Key]
        public int CenterID { get; set; }

        [Required]
        [StringLength(50)]
        public string CenterName { get; set; }

        [Required]
        [ForeignKey("Governorate")]
        public int GovernorateID { get; set; }

        public virtual Governorate Governorate { get; set; }
    }
}
