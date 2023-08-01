using System.ComponentModel.DataAnnotations;

namespace CRUDSystem.Models
{
    public class Account
    {
        [Key]
        [Required(ErrorMessage ="من فضلك ادخل اسم المستخدم")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل كلمة المرور")]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; }
    }
}
