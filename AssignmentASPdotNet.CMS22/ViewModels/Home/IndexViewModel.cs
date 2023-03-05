using AssignmentASPdotNet.CMS22.Models;
using AssignmentASPdotNet.CMS22.Models.Entities;

namespace AssignmentASPdotNet.CMS22.ViewModels.Home
{
    public class IndexViewModel
    {
        public string PageTitle { get; set; } = "Home";
        public ShowcaseModel Showcase { get; set; } = new ShowcaseModel();
        public IEnumerable<ProductModel> Products { get; set; } = new List<ProductModel>();
        public IEnumerable<ProductCategoryEntity> ProductCategories { get; set; } = new List<ProductCategoryEntity>();
    }
}
