using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface IProductService
    {

        List<Product> GetAll();

        void Create(Product product);

        Product GetById(int? id);

        void Edit(Product product);

        void Delete(int? id);   
    }
}
