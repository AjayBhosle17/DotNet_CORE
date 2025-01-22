using BAL;
using DAL;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WEB_UI.Controllers;
using Xunit;

namespace Web_UI_Test
{
    public class Category_Controller_Test
    {
        [Fact]
        public void Index_Method_Positive()
        {
            // 1.Arrange

            ApplicationDbContext db = new ApplicationDbContext();
            IcategoryRepository repo =new CategoryRepository(db);
            ICategoryService service = new CategoryService(repo);
            CategoryController obj = new CategoryController(service);


            // above code is dependent  thats why mocking framework use for fake object to  run our test easily

            List<Category> expected = new List<Category>() {

                new Category(){Name="Mens Wear",Rating =4 },
                new Category(){Name="Kids Wear",Rating =3}

            };

            //2.Act

            ActionResult actualResult = obj.Index();

            ViewResult result = actualResult as ViewResult;

            List<Category> cats = result.Model as List<Category>;


            // use moq framework for easy

            //3.Assert

            Assert.Equal(expected.Count, cats.Count);
        }
    }
}
