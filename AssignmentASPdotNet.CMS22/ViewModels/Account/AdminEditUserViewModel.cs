using AssignmentASPdotNet.CMS22.Models.Identity;

namespace AssignmentASPdotNet.CMS22.ViewModels.Account
{
    public class AdminEditUserViewModel
    {
        public AppIdentityUserWithRole User { get; set; } = null!;
        public string CurrentRoleName { get; set; } = null!;
        public string UserId { get; set; } = null!;
    }
}
