using System.ComponentModel.DataAnnotations;

namespace HookahNet.View.ViewModel
{
    public class LoginModel
    {
            
        [Required(ErrorMessage = "Incorrect Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Incorrect Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

