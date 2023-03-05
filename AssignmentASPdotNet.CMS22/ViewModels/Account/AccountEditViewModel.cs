using AssignmentASPdotNet.CMS22.Models.Forms;

namespace AssignmentASPdotNet.CMS22.ViewModels.Account
{
    public class AccountEditViewModel
    {
        public string UserId { get; set; } = null!;
        public ProfileEditForm Form { get; set; } = new ProfileEditForm();
    }
}
