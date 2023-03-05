namespace AssignmentASPdotNet.CMS22.Models.Entities
{
    public class ShowcaseEntity
    {
        public int Id { get; set; }
        public string Title_1 { get; set; } = "";
        public string Title_2 { get; set; } = "";

        public int ImageId { get; set; }
        public int NavLinkId { get; set; }

        public ImageEntity Image { get; set; } = null!;
        public NavLinkEntity NavLink { get; set; } = null!;
    }
}
