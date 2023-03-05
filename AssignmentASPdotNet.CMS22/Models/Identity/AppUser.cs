using AssignmentASPdotNet.CMS22.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AssignmentASPdotNet.CMS22.Models.Identity
{
    public class AppUser : IdentityUser
    {
        public Guid ProfileId { get; set; }

        [Required]
        [ProtectedPersonalData]
        [Display(Name = "First name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [ProtectedPersonalData]
        [Display(Name = "First name")]
        public string LastName { get; set; } = string.Empty;
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? ImageName { get; set; }

        public UserProfileEntity Profile { get; set; } = null!;
    }
}
