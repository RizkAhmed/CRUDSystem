using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CRUDSystem.Models
{
    public class Governorate
    {
        [Key]
        public int GovernorateID { get; set; }

        [Required]
        [StringLength(50)]
        public string GovernorateName { get; set; }
    }
}
