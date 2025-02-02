using System.ComponentModel.DataAnnotations;

namespace _04_Ado.Net_Crud_Database_Connectivity.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
    }
}
