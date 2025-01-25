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

            mock.Setup(s => s.GetAll()).Returns(products);



            // 2. Act

            var actual = product.Index() as ViewResult;

            var model = actual.Model as List<Product>;

            // 3. 
            Assert.NotNull(actual);
            Assert.IsType<ViewResult>(actual);
            Assert.Equal(products.Count, model.Count());


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

            Product product = new Product() { Id = 1, Name = "Mobile", Price = 8000 };
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

            var actual = obj.Create(product) as ViewResult;


            //3.Assert

            Assert.NotNull(actual);
            Assert.IsType<ViewResult>(actual);
            Assert.Equal(product, actual.Model);

        }

        [Fact]
        public void Details_Zero_Id_RedirectTo_Index()
        {

            //1.Arrange

            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController obj = new ProductController(mock.Object);


            //2.Act

            var actual = obj.Details(0) as RedirectToRouteResult;

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

            Product product = new Product() { Id = 1, Name = "TV", Price = 200 };

            mock.Setup(s => s.GetById(1)).Returns(product);

            //2.Act

            var actual = obj.Details(product.Id) as ViewResult;


            //3.Assert

            Assert.NotNull(actual);
            var model = actual.Model as Product;
            Assert.Equal(product.Name, model.Name);

        }

        [Fact]

        public void Details_Non_Existing_Id_returnHttpNotFound()
        {
            //1.Arrange
            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController obj = new ProductController(mock.Object);


            Product product = null;

            mock.Setup(s => s.GetById(1)).Returns(product);

            // 2.act


            var actual = obj.Details(1) as HttpNotFoundResult;

            //3.Assert

            Assert.NotNull(actual);
            Assert.IsType<HttpNotFoundResult>(actual);

        }


        [Fact]
        public void Edit_Get_zeroId_redirectToIndex()
        {
            // 1.Arrange
            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController obj = new ProductController(mock.Object);


            //2.Act

            var actual = obj.Edit(0) as RedirectToRouteResult;


            // 3.Assert

            Assert.NotNull(actual);
            Assert.IsType<RedirectToRouteResult>(actual);
            Assert.Equal("Index", actual.RouteValues["action"]);

        }


        [Fact]
        public void Edit_Get_ValidId_returnViewProduct()
        {
            // 1.Arrange
            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController obj = new ProductController(mock.Object);

            Product product = new Product() { Id = 1, Name = "TV", Price = 2300 };

            mock.Setup(s => s.GetById(product.Id)).Returns(product);
            // 2.Act

            var actual = obj.Edit(1) as ViewResult;

            // 3.Assert

            var model = actual.Model as Product;

            Assert.NotNull(actual);
            Assert.IsType<ViewResult>(actual);
            Assert.Equal(product, model);
        }

        [Fact]

        public void Edit_Get_NonExitId_return_Http_Not_Found()
        {

            // 1.Arrange
            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController obj = new ProductController(mock.Object);

            Product product = null;

            mock.Setup(s => s.GetById(1)).Returns(product);

            //2.Act

            var actual = obj.Edit(1) as HttpNotFoundResult;


            //3.Assert

            Assert.NotNull(actual);
            Assert.IsType<HttpNotFoundResult>(actual);

        }


        [Fact]

        public void Edit_Post_Valid_Product_ToRedirect_to_Index()
        {
            //1.Arrange
            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController obj = new ProductController(mock.Object);

            Product product = new Product()
            {
                Id = 1,
                Name = "mobile",
                Price = 2000
            };



            //2.Act

            var actual = obj.Edit(product) as RedirectToRouteResult;

            //3.Assert

            Assert.NotNull(actual);
            Assert.IsType<RedirectToRouteResult>(actual);


            //3.Assert

            Assert.Equal("Index", actual.RouteValues["action"]);
        }


        [Fact]

        public void Edit_Post_Invalid_Method_ReturnView()
        {

            //1.Arrange
            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController obj = new ProductController(mock.Object);

            Product product = new Product();
            obj.ModelState.AddModelError("Name", "Name is Required");

            // 2.Act

            var actual = obj.Edit(product) as ViewResult;


            //3.Assert

            Assert.NotNull(actual);

            var model = actual.Model as Product;

            Assert.Equal(product, model);

        }


        [Fact]
        public void Delete_Get_Valid_ZeroId_Return_RedirectToAction()
        {
            //1.Arrange
            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController obj = new ProductController(mock.Object);

            //2.Act

            var actual = obj.Delete(0) as RedirectToRouteResult;

            //3.Assert

            Assert.NotNull(actual);
            Assert.Equal("Index", actual.RouteValues["action"]);


        }


        [Fact]
        public void Delete_Get_Valid_ValidId_ReturnViewProduct()
        {
            //1.Arrange
            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController obj = new ProductController(mock.Object);

            Product product = new Product()
            {
                Id = 1,
                Name = "Books",
                Price = 300
            };

            mock.Setup(s => s.GetById(1)).Returns(product);

            //2.Act

            var actual = obj.Delete(product.Id) as ViewResult;


            //3.Assert

            Assert.NotNull(actual);
            Assert.IsType<ViewResult>(actual);

            var model = actual.Model as Product;

            Assert.Equal(product, model);
        }


        [Fact]
        public void Delete_Get_InValid_NONExitId_ReturnHttpNotFound()
        {
            //1.Arrange
            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController obj = new ProductController(mock.Object);


            Product product = null;
            mock.Setup(s => s.GetById(1)).Returns(product);

            // 2.act

            var actual = obj.Delete(1) as HttpNotFoundResult;

            //3.Assert

            Assert.NotNull(actual);
            Assert.IsType<HttpNotFoundResult>(actual);
        }


        [Fact]

        public void Delete_Post_Method_Valid_Id_ReturnRedirectToIndex()
        {

            //1.Arrange
            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController obj = new ProductController(mock.Object);

            Product product = new Product() { Id = 1, Name = "Laptop", Price=70000 };

            mock.Setup(s => s.Delete(product.Id));

            //2.Act

            var actual = obj.DeleteConfirmed(product.Id) as RedirectToRouteResult;

            //3.Assert

            Assert.NotNull(actual);
            Assert.IsAssignableFrom<RedirectToRouteResult>(actual);
            Assert.IsType<RedirectToRouteResult>(actual);
            Assert.Equal("Index", actual.RouteValues["action"]);

        }

        [Fact]

        public void Delete_Post_Method_NonExitId_ReturnView()
        {

            //1.Arrange
            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController obj = new ProductController(mock.Object);

            var ProductId = 1;

            mock.Setup(s => s.Delete(ProductId)).Throws<Exception>();

            //2.Act

            var actual = obj.DeleteConfirmed(ProductId) as ViewResult;

            //3.Assert

            Assert.NotNull(actual);
            Assert.IsAssignableFrom<ViewResult>(actual);
            Assert.IsType<ViewResult>(actual);
            Assert.Equal("Delete", actual.ViewName);

        }


    }
}
