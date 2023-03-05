using Microsoft.AspNetCore.Identity;

namespace AssignmentASPdotNet.CMS22.Models.Entities
{
    public class UserProfileEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? StreetName { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? ImageName { get; set; }



        public virtual ICollection<UserProfileEntity> Users { get;set; } = new List<UserProfileEntity>();
    }
}
