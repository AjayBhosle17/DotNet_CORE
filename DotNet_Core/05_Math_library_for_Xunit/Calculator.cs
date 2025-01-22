using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Math_library_for_Xunit
{
    public class Calculator
    {

        public int add(int x, int y) {

            if(x==int.MaxValue && y == int.MaxValue)
            {
                return 0;
            }

            return x + y;
        }

        public int sub(int x, int y) { 
        
            return x - y;
        }
    }
}
