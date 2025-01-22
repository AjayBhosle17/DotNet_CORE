using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Garabge_Collector
{
    public class Customer:IDisposable
    {
        SqlConnection _connection = new SqlConnection();
        public void print()
        {
            Console.WriteLine("Print Method Called");
        }

        public void Insert()
        {
            /* SqlConnection obj = new SqlConnection();


             obj.Dispose();*/

            // it is a shortcut
          /*  using (SqlConnection obj = new SqlConnection())
            {

            }*/

            // compare to this

           /* SqlConnection conn = null;

            try
            {
                conn = new SqlConnection();
            }
            finally
            {
                if (conn != null) { 
                
                    conn.Dispose();
                }

            }*/
        }



        public void Dispose()
        {
            throw new NotImplementedException();
        }

        // destructor gets called when object is not in use
        ~Customer()
        {
            
            _connection.Dispose();
            
        }
    }

   
}
