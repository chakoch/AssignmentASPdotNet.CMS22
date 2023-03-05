using AssignmentASPdotNet.CMS22.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssignmentASPdotNet.CMS22.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<NavLinkEntity> NavLinks { get; set; } = null!;
        public DbSet<ImageEntity> Images { get; set; }
        public DbSet<ShowcaseEntity> Showcases { get; set; }
        public DbSet<ProductDescriptionEntity> ProductDescriptions { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
        public DbSet<BrandEntity> Brands { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductReviewEntity> ProductReviews { get; set; }
        public DbSet<ProductImageEntity> ProductImages { get; set; }
    }


}
