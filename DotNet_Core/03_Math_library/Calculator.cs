using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Math_library
{
    public class Calculator
    {
        public int Add(int x, int y) {

            if (x == int.MaxValue && y == int.MaxValue)
            {
                return 0;
            }


            return x + y;
        }


        public int Sub(int x , int y)
        {

            return x-y;

        }
    }
}
