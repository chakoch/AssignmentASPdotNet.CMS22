using AssignmentASPdotNet.CMS22.Models.Entities;

namespace AssignmentASPdotNet.CMS22.Models
{
    public class ProductModel
    {
        public string SKU { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = "";
        public string Category { get; set; } = "";
        public string ShortDescripstion { get; set; } = "";
        public string LongDescripstion { get; set; } = "";
        public IEnumerable<ProductReviewModel> Reviews { get; set; } = null!;
        public double Rating()
        {
            if(Reviews != null)
            {
                var rating = 0;
                foreach (var review in Reviews)
                {
                    rating += review.Rating;
                }
                return rating / Reviews.Count();
            }
            return 0;
        }

        public ProductImageModel Image { get; set; } = new ProductImageModel();
    }
}
