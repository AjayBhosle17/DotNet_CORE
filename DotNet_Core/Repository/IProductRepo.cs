using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProductRepo
    {
        List<Product> GetAll();

        Product getById(int? id);

        void Create(Product product);

        void Edit(Product product);

        void Delete(int? id);

    }
}
