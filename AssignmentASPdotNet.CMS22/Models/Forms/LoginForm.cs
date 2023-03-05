using System.ComponentModel.DataAnnotations;

namespace AssignmentASPdotNet.CMS22.Models.Forms
{
    public class LoginForm
    {

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        public bool KeepMeLoggedIn { get; set; }
    }
}
