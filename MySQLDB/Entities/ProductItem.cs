using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySQLDB.Entities
{
    public abstract class ProductItemBase : CodeEntity
    {
        public string Title { get; set; }

        public string? Description { get; set; }

        public string? VideoUrl { get; set; }

        public string? PdfUrl { get; set; }

        public string? ImageUrl { get; set; }

        public string? DocUrl { get; set; }
    }

    [Table("ProductItem")]
    public class ProductItem : ProductItemBase
    {
        public string? PathUrl { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }

    [Table("EsProductItem")]
    public class EsProductItem : ProductItemBase
    {
        [Required]
        public int ProductItemId { get; set; }

        public ProductItem ProductItem { get; set; }
    }
}