using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySQLDB.Entities
{
    public class ProductBase : CodeEntity
    {
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Type { get; set; }

        [MaxLength(200)]
        public string Category { get; set; }

        public DateTime? ValidTo { get; set; }

        public string? Description { get; set; }
    }

    [Table("Product")]
    public class Product : ProductBase
    {
        [Required]
        public string PathUrl { get; set; }
    }

    [Table("EsProduct")]
    public class EsProduct : ProductBase
    {
        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}