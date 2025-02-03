using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _06_EF_Core_CodeFirstApproch.Models.Entities
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="varchar(20)")]
        public string Name { get; set; }

        public int? Order { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
