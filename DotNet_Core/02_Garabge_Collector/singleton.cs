using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_Garabge_Collector
{
    public class singleton
    {

       static int count = 1;
       private singleton() {

            
            
        }

        private static singleton instance=null;

        public static singleton getObject()
        {

            if (count <= 5)
            {
                instance = new singleton();
                Console.WriteLine($"object {count} created");
                
               
            }
            else
            {
                Console.WriteLine("we can create only 5 object");

            }
            count++;
            return instance;
        }


    }
}
