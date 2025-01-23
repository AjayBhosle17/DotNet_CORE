using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Web_Ui_Test_For_Product;
using WEB_UI.Controllers;
using Moq;
using BAL;
using DAL;
using System.Web.Mvc;

namespace Web_Ui_Test_For_Product
{
    public class TestingFor_Product
    {
        [Fact]
        public void Index_Method_return_viewListOfProduct()
        {
            //1.Arrange
            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController product = new ProductController(mock.Object);


            List<Product> products = new List<Product>()
            {
                new Product(){Id=1 ,Name="Mobiles",Price=2000},
                new Product(){Id=2 ,Name="Laptop",Price=3000}

            };

            mock.Setup(s=>s.GetAll()).Returns(products);



            // 2. Act

            var actual = product.Index() as ViewResult;

            var model = actual.Model as List<Product>;

            // 3. 
            Assert.NotNull(actual);
            Assert.IsType<ViewResult>(actual);
            Assert.Equal(products.Count,model.Count());
            
            
        }
    }
}
