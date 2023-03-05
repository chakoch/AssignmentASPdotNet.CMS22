using AssignmentASPdotNet.CMS22.Models;

namespace AssignmentASPdotNet.CMS22.ViewModels.Products
{
    public class IndexViewModel
    {
        public string PageTitle { get; set; } = "Home";
        public ShowcaseModel Showcase { get; set; } = new ShowcaseModel();
        public IEnumerable<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
