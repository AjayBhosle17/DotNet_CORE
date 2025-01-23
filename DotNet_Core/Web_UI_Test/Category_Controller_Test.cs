using BAL;
using DAL;
using Moq;
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
       /* [Fact]
        *//*public void Index_Method_Positive()
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
        }*/



        //here use mocking framework as well as xUnit Testing framework

        [Fact]

        public void Index_Method_Return_ViewResultformOfListof_Category()
        {
            //1.Arrange

            Mock<ICategoryService> mock = new Mock<ICategoryService>();

            CategoryController obj = new CategoryController(mock.Object);

            var categories = new List<Category>()
            {
                new Category(){Id=1 , Name="Mens Wear" , Rating=4 },
                new Category(){Id=2 , Name="kids Wear" , Rating=5 }

            };

            mock.Setup(s=>s.GetAll()).Returns(categories);

            //2.Act

            var result = obj.Index() as ViewResult;


            //3.Assert

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<IEnumerable<Category>>(result.Model);

            var model = result.Model as IEnumerable<Category>;

            Assert.Equal(categories.Count, model.Count());
        }


        [Fact]
        public void Create_GetMethod_Return_ViewResult()
        {

            Mock<ICategoryService> mock = new Mock<ICategoryService>();
            CategoryController obj = new CategoryController(mock.Object);


            var result = obj.Create() as ViewResult;


            // Assert

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);

            Assert.Equal("Create",result.ViewName);

           
        }



        [Fact]
        public void Create_ValidModel_RedirectsToIndex()
        {

            Mock<ICategoryService> mock = new Mock<ICategoryService>();
            CategoryController categoryController = new CategoryController(mock.Object);

            Category category = new Category()
            {
                Id=1 , Name="Kids Wear" , Rating =5
            };

            var result = categoryController.Create(category) as RedirectToRouteResult;

            Assert.NotNull(result);
            Assert.IsType<RedirectToRouteResult>(result);

            Assert.Equal("Index", result.RouteValues["action"]);

        }

        [Fact]
        public void Create_InValidModel_ReturnsViewResultWithModel()
        {
            // arrange
            Mock<ICategoryService> mockService =
                new Mock<ICategoryService>();

            CategoryController controller = new CategoryController(mockService.Object);

            Category category = new Category();

            controller.ModelState.AddModelError("Name", "Name is required");

            // act
            var result = controller.Create(category) as ViewResult;

            // assert
            Assert.NotNull(result);

            Assert.Equal(category, result.Model);
        }

        [Fact]
        public void Details_ZeroId_RedirectsToIndex()
        {
            // arrange

            Mock<ICategoryService> mockService = new Mock<ICategoryService>();
            CategoryController controller = new CategoryController(mockService.Object);

            // act

            var result = controller.Details(0) as RedirectToRouteResult;

            // assert
            Assert.NotNull(result);

            Assert.Equal("Index", result.RouteValues["action"]);
        }

        [Fact]
        public void Details_ValidExistingId_ReturnsViewWithModel()
        {
            // arrange

            Mock<ICategoryService> mockService = new Mock<ICategoryService>();
            CategoryController controller = new CategoryController(mockService.Object);

            Category category = new Category() { Id = 1, Name = "Kids Wear", Rating = 5 };

            mockService.Setup(s => s.GetById(1)).Returns(category);

            // act

            var result = controller.Details(1) as ViewResult;

            // assert
            Assert.NotNull(result);

            var model = result.Model as Category;
            Assert.Equal("Kids Wear", model.Name);
        }

        [Fact]
        public void Details_NonExistingId_ReturnsHttpNotFound()
        {
            // arrange

            Mock<ICategoryService> mockService = new Mock<ICategoryService>();
            CategoryController controller = new CategoryController(mockService.Object);

            Category category = null;

            mockService.Setup(s => s.GetById(1)).Returns(category);

            // act

            var result = controller.Details(1) as HttpNotFoundResult;

            // assert
            Assert.NotNull(result);

            Assert.IsType<HttpNotFoundResult>(result);
        }

        [Fact]
        public void Edit_GetMethod_ValidId_ReturnsViewWithModel()
        {
            // Arrange
            Mock<ICategoryService> mockService = new Mock<ICategoryService>();
            CategoryController controller = new CategoryController(mockService.Object);

            Category category = new Category() { Id = 1, Name = "Kids Wear", Rating = 5 };

            mockService.Setup(s => s.GetById(1)).Returns(category);

            // Act
            var result = controller.Edit(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            var model = result.Model as Category;
            Assert.Equal(category, model);
        }


        [Fact]
        public void Edit_GetMethod_InvalidId_RedirectsToIndex()
        {
            // Arrange
            Mock<ICategoryService> mockService = new Mock<ICategoryService>();
            CategoryController controller = new CategoryController(mockService.Object);

            // Act
            var result = controller.Edit(0) as RedirectToRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.RouteValues["action"]);
        }


        [Fact]
        public void Edit_PostMethod_ValidModel_RedirectsToIndex()
        {
            // Arrange
            Mock<ICategoryService> mockService = new Mock<ICategoryService>();
            CategoryController controller = new CategoryController(mockService.Object);

            Category category = new Category() { Id = 1, Name = "Kids Wear", Rating = 5 };

            // Act
            var result = controller.Edit(category) as RedirectToRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.RouteValues["action"]);
        }

        [Fact]
        public void Edit_PostMethod_InvalidModel_ReturnsViewWithModel()
        {
            // Arrange
            Mock<ICategoryService> mockService = new Mock<ICategoryService>();
            CategoryController controller = new CategoryController(mockService.Object);

            Category category = new Category();
            controller.ModelState.AddModelError("Name", "Name is required");

            // Act
            var result = controller.Edit(category) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(category, result.Model);
        }


        [Fact]
        public void Delete_GetMethod_ValidId_ReturnsViewWithModel()
        {
            // Arrange
            Mock<ICategoryService> mockService = new Mock<ICategoryService>();
            CategoryController controller = new CategoryController(mockService.Object);

            Category category = new Category() { Id = 1, Name = "Kids Wear", Rating = 5 };

            mockService.Setup(s => s.GetById(1)).Returns(category);

            // Act
            var result = controller.Delete(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            var model = result.Model as Category;
            Assert.Equal(category, model);
        }

        [Fact]
        public void Delete_GetMethod_InvalidId_RedirectsToIndex()
        {
            // Arrange
            Mock<ICategoryService> mockService = new Mock<ICategoryService>();
            CategoryController controller = new CategoryController(mockService.Object);

            // Act
            var result = controller.Delete(0) as RedirectToRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.RouteValues["action"]);
        }

        [Fact]
        public void Delete_PostMethod_ValidId_RedirectsToIndex()
        {
            // Arrange
            Mock<ICategoryService> mockService = new Mock<ICategoryService>();
            CategoryController controller = new CategoryController(mockService.Object);

            // Act
            var result = controller.DeleteConfirmed(1) as RedirectToRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.RouteValues["action"]);
        }

        [Fact]
        public void Delete_PostMethod_Exception_ReturnsDeleteView()
        {
            // Arrange
            Mock<ICategoryService> mockService = new Mock<ICategoryService>();
            CategoryController controller = new CategoryController(mockService.Object);

            mockService.Setup(s => s.Delete(It.IsAny<int>())).Throws(new Exception());

            // Act
            var result = controller.DeleteConfirmed(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Delete", result.ViewName);
        }

    }
}
