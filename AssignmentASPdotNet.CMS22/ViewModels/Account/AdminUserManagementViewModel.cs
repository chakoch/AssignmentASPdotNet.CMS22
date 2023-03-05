using AssignmentASPdotNet.CMS22.Models.Identity;

namespace AssignmentASPdotNet.CMS22.ViewModels.Account
{
    public class AdminUserManagementViewModel
    {
        public ICollection<AppIdentityUserWithRole> Users { get; set; } = new List<AppIdentityUserWithRole>();
    }
}
