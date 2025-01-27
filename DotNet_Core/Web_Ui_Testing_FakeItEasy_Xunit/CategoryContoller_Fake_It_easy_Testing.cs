using BAL;
using DAL;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WEB_UI.Controllers;
using Xunit;

namespace Web_Ui_Testing_FakeItEasy_Xunit
{
    public class CategoryContoller_Fake_It_easy_Testing
    {
        [Fact]
        public void Index_ReturnsViewResult_WithCategories()
        {
            ICategoryService fakeService = A.Fake<ICategoryService>();
            CategoryController controller = new CategoryController(fakeService);

            // Arrange
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "mens wear", Rating = 5 },
                new Category { Id = 2, Name = "kids wear", Rating = 4 }
            };
            A.CallTo(() => fakeService.GetAll()).Returns(categories);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Category>>(result.Model);
            Assert.Equal(2, ((List<Category>)result.Model).Count);
        }

        [Fact]
        public void Create_Get_ReturnsView()
        {
            ICategoryService fakeService = A.Fake<ICategoryService>();
            CategoryController controller = new CategoryController(fakeService);

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Create_Post_ValidModel_RedirectsToIndex()
        {
            // Arrange
            ICategoryService fakeService = A.Fake<ICategoryService>();
            CategoryController controller = new CategoryController(fakeService);
            var category = new Category { Id = 1, Name = "mens wear", Rating = 5 };

            // Act
            var result = controller.Create(category) as RedirectToRouteResult;

            // Assert
            A.CallTo(() => fakeService.Create(category)).
                MustHaveHappenedOnceExactly();

            Assert.NotNull(result);
            Assert.Equal("Index", result.RouteValues["action"]);
        }

        [Fact]
        public void Create_Post_InvalidModel_ReturnsView()
        {
            // Arrange
            ICategoryService fakeService = A.Fake<ICategoryService>();
            CategoryController controller = new CategoryController(fakeService);

            controller.ModelState.AddModelError("Name", "Required");
            var category = new Category();

            // Act
            var result = controller.Create(category) as ViewResult;

            // Assert
            A.CallTo(() => fakeService.Create(A<Category>.Ignored))
                .MustNotHaveHappened();

            Assert.NotNull(result);
            Assert.Equal(category, result.Model);
        }
    }
}
