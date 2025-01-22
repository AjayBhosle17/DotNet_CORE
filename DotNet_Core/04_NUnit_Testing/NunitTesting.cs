using _04_Math_Library;
using NUnit.Framework;
using NUnit;
namespace _04_NUnit_Testing
{
    [TestFixture]
    public class NunitTesting
    {
        Calculator obj;

        [SetUp]
        public void setUp()
        {
            obj = new Calculator();
        }


        [Test]
        public void Calculator_Add_Positive()
        {
            // 1.Arrange
          //  Calculator obj  = new Calculator();

            int x = 10; int y = 10;

            int expected_result = 20;
            
            // 2.Act
            
            int actualResult = obj.Add(x, y);

            //3.Assert

            Assert.AreEqual(expected_result, actualResult);
        }

        [Test]

        public void Calculator_Add_MaxValue() { 
        
            //1.Arrange
          //  Calculator obj = new Calculator();

            int x = int.MaxValue; int y = int.MaxValue;

            int expected_result = 0;

            //2.Act
            int actualResult = obj.Add(x, y);


            //3.Assert
            Assert.AreEqual(expected_result, actualResult);
        }
        [Test]
        public void Calculator_Add_Negative()
        {
            // 1.Arrange
        //    Calculator obj = new Calculator();
           

           
            int a = 10;
            int b = 10;
            int expectedresult = 11;
            //2.Act

            int actualresult = obj.Add(a, b);


            //3.Assert

            Assert.AreNotEqual(expectedresult, actualresult);
        }


        [Test]
        public void Calculator_sub_Negative()
        {
            // 1.Arrange
            //Calculator obj = new Calculator();

            int x = 10; int y = 10;

            int expected_result = 0;

            // 2.Act

            int actualResult = obj.Sub(x, y);

            //3.Assert

            Assert.AreEqual(expected_result, actualResult);
        }


    }
}
