using _05_Math_library_for_Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _05_XUnitTesting
{
    public class XUnitTesting
    {
        Calculator calculator;
        public XUnitTesting() {
        
            calculator = new Calculator();
        }

        [Fact]
        public void Calculator_Add_Method_Positive() { 
        
            //1. Arrange

           // Calculator calculator = new Calculator();

            int a = 10; int b = 20;

            int expectedResult = 30;

            //2.Act

            int actualResult = calculator.add(a, b);


            //3.Assert

             Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Calculator_Add_MaxValue()
        {

            //1.Arrange
          //  Calculator calculator = new Calculator();

            int x = int.MaxValue; int y = int.MaxValue;

            int expected_result = 0;

            //2.Act
            int actualResult = calculator.add(x, y);


            //3.Assert
            Assert.Equal(expected_result, actualResult);
        }


        [Fact]
        public void Calculator_Add_Negative()
        {
            // 1.Arrange
         //   Calculator calculator = new Calculator();



            int a = 10;
            int b = 10;
            int expectedresult = 11;
            //2.Act

            int actualresult = calculator.add(a, b);


            //3.Assert

            Assert.NotEqual(expectedresult, actualresult);
        }


        [Fact]
        public void Calculator_sub_Negative()
        {
            // 1.Arrange
          //  Calculator calculator = new Calculator();

            int x = 10; int y = 10;

            int expected_result = 0;

            // 2.Act

            int actualResult = calculator.sub(x, y);

            //3.Assert

            Assert.Equal(expected_result, actualResult);
        }

    }
}
