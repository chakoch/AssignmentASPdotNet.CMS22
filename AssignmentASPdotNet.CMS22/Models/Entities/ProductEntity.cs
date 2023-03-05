using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentASPdotNet.CMS22.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public string SKU { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int Descripstion { get; set; }

        public BrandEntity Brand { get; set; } = null!;
        public ProductCategoryEntity Category { get; set; } = null!;
        public ProductDescriptionEntity Description { get; set; } = null!;
        public ProductImageEntity Image { get; set; } = null!;

        public virtual ICollection<ProductCategoryEntity> Products { get;set; } = new HashSet<ProductCategoryEntity>();

    }
}
