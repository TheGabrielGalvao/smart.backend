using System.ComponentModel.DataAnnotations.Schema;
using Util.Enumerator;

namespace Domain.Entities.Product
{
    [Table("Products", Schema = "product")]
    public class ProductEntity : DefaultEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } = 0.00M;
        public ERegisterStatus? Status { get; set; } = ERegisterStatus.ACTIVE;

        public long ProductCategoryId { get; set; }

        [ForeignKey(nameof(ProductCategoryId))]
        public ProductCategory ProductCategory { get; set; }

        
    }
}
