using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class PostModel
    {
        public int PostId { get; set; }

        [Required(ErrorMessage ="Please Enter Title")]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required(ErrorMessage ="Please Enter Content Of Post")]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]

        public DateTime? PublishedDate { get; set; } = DateTime.Now;
    }
}
