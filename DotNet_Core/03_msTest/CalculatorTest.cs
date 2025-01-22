using _03_Math_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_msTest
{
    [TestClass]
    public class CalculatorTest
    {

        Calculator calculator;

        [TestInitialize]
        public void setUp()
        {
            calculator = new Calculator();
        }

        [TestMethod]

        public void Calculator_Add_Positive()
        {

            //1. arrange

           // Calculator calculator = new Calculator();
            int a = 10;
            int b = 10;

            int expectedresult = 20;


            //2.act

            int actualresult = calculator.Add(a, b);

            //3.assert

            Assert.AreEqual(expectedresult, actualresult);

        }

        [TestMethod]
        public void Calculator_Add_Negative() { 
        
            // 1.Arrange

           // Calculator calculator = new Calculator();
            int a = 10;
            int b = 10;
            int expectedresult = 11;
            //2.Act

            int actualresult = calculator.Add(a, b);
            

            //3.Assert

            Assert.AreNotEqual(expectedresult, actualresult);
        }

        [TestMethod]
        public void Calculator_Add_MaxValue()
        {

            // 1.Assert

         //   Calculator calculator = new Calculator();
            int a=int.MaxValue;
            int b=int.MaxValue;

            int expectedresult = 0;

            //2.Act

            int actualresult = calculator.Add(a, b);

            //3.assert

            Assert.AreEqual(expectedresult, actualresult);
        }



        [TestMethod]

        public void Calculator_sub_Positive()
        {
            int a = 10;
            int b = 10;

            int expectedresult = 0;
            int acutalResult = calculator.Sub(a, b);
        }



        [TestCleanup]

        public void cleanUp()
        {
            // dispose all object
        }
    }
}
