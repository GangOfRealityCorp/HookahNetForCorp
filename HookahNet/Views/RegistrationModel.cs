using System.ComponentModel.DataAnnotations;

namespace HookahNet.View.ViewModel
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Incorrect Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Incorrect Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Wrong Password")]
        public string ConfirmPassword { get; set; }
    }
}
