using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUDSystem.Models
{
    public class Village
    {
        [Key]
        public int VillageID { get; set; }

        [Required]
        [StringLength(50)]
        public string VillageName { get; set; }

        [Required]
        [ForeignKey("Center")]
        public int CenterID { get; set; }

        public virtual Center Center { get; set; }
    }
}
