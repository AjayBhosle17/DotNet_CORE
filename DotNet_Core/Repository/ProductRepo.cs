using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepo : IProductRepo
    {
        ApplicationDbContext _repo;

        public ProductRepo(ApplicationDbContext repo)
        {
            this._repo = repo;
        }

        public List<Product> GetAll()
        {
           return _repo.products.ToList();
        }
        public void Create(Product product)
        {
            _repo.products.Add(product);
            _repo.SaveChanges();
        }

        public void Delete(int? id)
        {
            var product = _repo.products.Find(id);
            _repo.products.Remove(product);
            _repo.SaveChanges();
        }

        public void Edit(Product products)
        {
            var product = _repo.products.Find(products.Id);

            if (product != null) { 
            
                product.Name = products.Name;
                product.Price = products.Price;

                _repo.SaveChanges();
            }
        }

       

        public Product getById(int? id)
        {
            return _repo.products.Find(id);
        }
    }
}
