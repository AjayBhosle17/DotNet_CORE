using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _06_EF_Core_CodeFirstApproch.Models.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="varchar(20)")]
        public string Name { get; set; }

        [Required]
        [Range(0,400000)]
        public decimal? Price { get; set; }

        public int? Stock { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        public Category  category { get; set; }
    }
}
