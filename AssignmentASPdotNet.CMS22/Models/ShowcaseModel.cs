namespace AssignmentASPdotNet.CMS22.Models
{
    public class ShowcaseModel
    {
        public string Title_1 { get; set; } = "";
        public string Title_2 { get; set; } = "";
        public NavlinkModel NavLink { get; set; } = new NavlinkModel();
        public ImageModel Image { get; set; } = new ImageModel();
    }
}
