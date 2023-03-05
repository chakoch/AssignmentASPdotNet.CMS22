namespace AssignmentASPdotNet.CMS22.Models.Entities
{
    public class NavLinkEntity
    {
        public int Id { get; set; }
        public string ControllerName { get; set; } = null!;
        public string ActionName { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
