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

        [Fact]
        public void Create_Method_return_ViewResult()
        {
            //1.Arrange
            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController obj = new ProductController(mock.Object);



            //2.Act

            var actual = obj.Create() as ViewResult;


            //3.Assert

            Assert.NotNull(actual);
            Assert.IsType<ViewResult>(actual);
            Assert.IsAssignableFrom<ViewResult>(actual);
            Assert.Equal("Create", actual.ViewName);


        }

        [Fact]

        public void Create_ValidModel_Method_RedirectToAction()
        {   //1.Arrange

            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController obj = new ProductController(mock.Object);

            Product product = new Product() {Id=1 , Name = "Mobile" , Price=8000 };
            //2.Act

            var actual = obj.Create(product) as RedirectToRouteResult;

            //3.Assert

            Assert.NotNull(actual);
            Assert.IsType<RedirectToRouteResult>(actual);
            Assert.Equal("Index", actual.RouteValues["action"]);
        }


        [Fact]

        public void Create_InValidModel_Method_return_View()
        {
            //1.Arrange
            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController obj = new ProductController(mock.Object);

            Product product = new Product();
            obj.ModelState.AddModelError("Name", "Name is Required");

            //2.Act

            var actual= obj.Create(product) as ViewResult;


            //3.Assert

            Assert.NotNull(actual);
            Assert.IsType<ViewResult>(actual);
            Assert.Equal(product, actual.Model);

        }

        [Fact]
        public void Details_Zero_Id_RedirectTo_Index() { 
        
            //1.Arrange

            Mock<IProductService> mock= new Mock<IProductService>();
            ProductController obj= new ProductController(mock.Object);


            //2.Act

            var actual= obj.Details(0) as RedirectToRouteResult;

            //3.Assert

            Assert.NotNull(actual);
            Assert.Equal("Index", actual.RouteValues["action"]);
        
        }

        [Fact]

        public void Details_ValidId_returnView()
        {
            //1.Arrange
            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController obj = new ProductController(mock.Object);

            Product product= new Product() { Id=1 , Name ="TV" , Price=200};

            mock.Setup(s => s.GetById(1)).Returns(product);

            //2.Act

           var actual= obj.Details(product.Id) as ViewResult;


            //3.Assert

            Assert.NotNull(actual);
            var model = actual.Model as Product;
            Assert.Equal(product.Name, model.Name);

        }
    }


}
