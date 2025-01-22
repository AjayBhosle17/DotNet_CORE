using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Garabge_Collector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Customer customer = new Customer();
             customer.print();*/

            Console.WriteLine("max generation is " + $"{GC.MaxGeneration}");
       
            Customer customer = new Customer();

            int generation = GC.GetGeneration(customer);

            Console.WriteLine($"customer is allocated in {generation} generation");

            GC.Collect(0);  // collection genartion 0

            generation = GC.GetGeneration(customer);

            Console.WriteLine($"customer is allocated in {generation} generation");

            GC.Collect(1);  // collection genartion 1

            generation = GC.GetGeneration(customer);

            Console.WriteLine($"customer is allocated in {generation} generation");

            GC.SuppressFinalize(customer);
            generation = GC.GetGeneration(customer);

            Console.WriteLine($"customer is allocated in {generation} generation");


        }
    }
}
