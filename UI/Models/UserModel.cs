using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class UserModel
    {

        #region Properties
        public int Id { get; set; }

        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and Cofirm Password dosen't match")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Phone Number Required")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; } 
        #endregion

    }
}
