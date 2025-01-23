using DAL;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class ProductService : IProductService
    {
        IProductRepo _service;
        public ProductService(IProductRepo service)
        {
            _service = service;
            
        }

        public List<Product> GetAll()
        {
            return _service.GetAll();
        }

        public void Create(Product product)
        {
            _service.Create(product);
        }

        public void Delete(int? id)
        {
            _service.Delete(id);
        }

        public void Edit(Product product)
        {
            _service.Edit(product);
        }

       
        public Product GetById(int? id)
        {
            return _service.getById(id);
        }
    }
}
