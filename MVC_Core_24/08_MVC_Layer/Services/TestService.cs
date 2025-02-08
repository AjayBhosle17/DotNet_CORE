using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TestService
    {
        int instance;
        public TestService() {
        
            instance = 1;

        }

       public int SameInstance()
        {
            return instance++;
        }
    }
}
