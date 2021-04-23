using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class LoginModel
    {
        #region Properties

        [Required(ErrorMessage = "User Name Required")]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; } 

        #endregion
    }
}
