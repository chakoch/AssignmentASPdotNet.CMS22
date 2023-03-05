using System.ComponentModel.DataAnnotations;

namespace AssignmentASPdotNet.CMS22.Models.Form
{
    public class RegisterForm
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Display(Name = "Street Name")]
        public string? StreetName { get; set; }

        [Display(Name = "Postal Code")]
        public string? PostalCode { get; set; }

        [Display(Name = "City")]
        public string? City { get; set; }
        public IFormFile? ProfileImage { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
