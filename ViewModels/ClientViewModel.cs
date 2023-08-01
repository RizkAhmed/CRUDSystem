using CRUDSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUDSystem.ViewModels
{
    public class ClientViewModel
    {
        public int? ClientID { get; set; }

        [Required(ErrorMessage = "من فضلك أدخل الأسم الأول")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "من فضلك أدخل الأسم الأخير")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "من فضلك أدخل الرقم القومى")]
        [StringLength(14, ErrorMessage = "برجاء إدخال الرقم القومى المكون من 14 رقم")]
        public string NationalID { get; set; }

        [Required(ErrorMessage = "من فضلك أختار النوع")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "من فضلك أختار المحافظة")]
        [ForeignKey("Governorate")]
        public int GovernorateID { get; set; }

        public  Governorate? Governorate { get; set; }

        [Required(ErrorMessage = "من فضلك أختار المركز")]
        [ForeignKey("Center")]
        public int CenterID { get; set; }
        public  Center? Center { get; set; }

        [Required(ErrorMessage = "من فضلك أختار القرية")]
        [ForeignKey("Village")]
        public int VillageID { get; set; }
        public  Village? Village { get; set; }


        //list will used in view
        public List<Governorate>? Governorates { get; set; }
        public List<Center>? Centers { get; set; }
        public List<Village>? Villages { get; set; }
    }
}
