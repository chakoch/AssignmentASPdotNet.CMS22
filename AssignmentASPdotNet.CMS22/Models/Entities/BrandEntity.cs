using Microsoft.EntityFrameworkCore;

namespace AssignmentASPdotNet.CMS22.Models.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class BrandEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
