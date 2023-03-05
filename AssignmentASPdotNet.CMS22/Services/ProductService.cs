using AssignmentASPdotNet.CMS22.Contexts;
using AssignmentASPdotNet.CMS22.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentASPdotNet.CMS22.Services
{
    public class ProductService
    {
        private readonly DataContext _context;
        private readonly ProductReviewService _productReviewService;

        public ProductService(ProductReviewService reviewService, DataContext context)
        {
            _productReviewService = reviewService;
            _context = context;
        }

        public async Task<IEnumerable<ProductModel>> GetProducts()
        {
            var _products = await _context.Products
                .Include(x => x.Brand)
                .Include(x => x.Category)
                .Include(x => x.Description)
                .ToListAsync();

            var products = new List<ProductModel>();
            foreach (var product in _products)
            {
                products.Add(new ProductModel
                {
                    Name = product.Name,
                    ShortDescripstion = product.Description.Short,
                    LongDescripstion = product.Description.Long,
                    Category = product.Category.Category,
                    Brand = product.Brand.Name,
                    Reviews = await _productReviewService.GetReviewsAsync(product.SKU)
                });
            }
            return products;
        }
    }
}
