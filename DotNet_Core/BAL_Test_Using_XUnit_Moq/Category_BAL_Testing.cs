using BAL;
using DAL;
using Moq;
using Repository;
using System.Collections.Generic;
using System.Linq;
using Xunit;
namespace BAL_Test_Using_XUnit_Moq
{
    public class Category_BAL_Testing
    {
        Mock<IcategoryRepository> repo = null;
        CategoryService service = null;

        public Category_BAL_Testing()
        {
            repo = new Mock<IcategoryRepository>();
            service = new CategoryService(repo.Object);
        }

        [Fact]
        public void GetAll_ValidResult_returnAllCatgory()
        {
            //1.Arrange
            List<Category> categories = new List<Category>()
                {
                new Category (){ Id=1, Name = "mobiles", Rating = 5},
                new Category(){ Id=2, Name = "category 2", Rating = 4}
                };

            repo.Setup(s=>s.GetAll()).Returns(categories);

            //2.Act

            var result = service.GetAll();


            //3. Assert

            Assert.NotNull(result);
            Assert.Equal(categories.Count(), result.Count());

        }

        [Fact]
        public void GetAll_ValidResult_returnEmptyCategories()
        {
            //1.Arrange
            List<Category> categories = new List<Category>();
               
            repo.Setup(s => s.GetAll()).Returns(categories);

            //2.Act

            var result = service.GetAll();


            //3. Assert

            Assert.NotNull(result);
            Assert.Equal(categories.Count(), result.Count());

        }
    }
}
