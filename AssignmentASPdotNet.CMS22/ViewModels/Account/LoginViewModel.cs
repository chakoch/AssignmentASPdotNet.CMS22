using AssignmentASPdotNet.CMS22.Models.Forms;
using System.ComponentModel.DataAnnotations;

namespace AssignmentASPdotNet.CMS22.ViewModels.Account
{
    public class LoginViewModel
    {
        public string ReturnUrl { get; set; } = null!;

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;
        public LoginForm Form { get; set; } = new LoginForm();
    }
}
