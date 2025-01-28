using _01_MVC_Core_Introduction.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01_MVC_Core_Introduction.ViewComponents
{
    public class firstViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke(int? id)
        {
            // any logic to retrive data either from database or from Api

            List<Category> categories = new List<Category>() {
                new Category(){
                    Id = 1,
                    Name = "Mens Wear",
                    Rating = 4
                },
                new Category(){
                    Id = 2,
                    Name = "kids Wear",
                    Rating = 5
                },
                new Category(){
                    Id = 3,
                    Name = "Womens Wear",
                    Rating = 3
                }
            };



            return View("First", categories.FirstOrDefault(s => s.Id == id));
        }
    }
}
