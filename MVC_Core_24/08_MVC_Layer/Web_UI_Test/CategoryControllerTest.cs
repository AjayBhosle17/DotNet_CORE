using CORE;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_UI.Controllers;

namespace Web_UI_Test
{
    public class CategoryControllerTest
    {
        CategoryController _categoryController;
        Mock<ICategoryService> _service;

        public CategoryControllerTest()
        {
            _service = new Mock<ICategoryService>();
            _categoryController = new CategoryController(_service.Object);

        }

        [Fact]
        public void Index_ValidResult_ReturnsViewResult()
        {

            //Arrange

            List<CategoryModel> categories = new List<CategoryModel>()
            {
                new CategoryModel(){Id=1,Name="Mens Wear" , Order=4},
                new CategoryModel(){Id=2,Name="Kids Wear" , Order=14}

            };


            //Act

            _service.Setup(s => s.GetAll()).Returns(categories);

            var result = _categoryController.Index() as ViewResult;

            //Assert
           
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            var model = result.Model as List<CategoryModel>;
            Assert.Equal(categories.Count(), model.Count());
        }

        [Fact]
        public void Index_NullCategories_ReturnsViewResult()
        {
            // arrange
            List<CategoryModel> categories = null;

            // act
            _service.Setup(service => service.GetAll()).Returns(categories);

            var result = _categoryController.Index() as ViewResult;

            // assert
            Assert.NotNull(result);

            Assert.IsType<ViewResult>(result);

            var model = result.Model as List<CategoryModel>;

            Assert.Null(model);
        }
    }
}
