namespace _02_ViewToController.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Discount { get; set; }

        public IFormFile formFile { get; set; }
    }
}
