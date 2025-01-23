using DAL;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class CategoryService : ICategoryService
    {
        IcategoryRepository _repo;

        public CategoryService(IcategoryRepository repo)
        {
            _repo= repo;
        }

       

        public IEnumerable<Category> GetAll()
        {
            return _repo.GetAll();
        }

        public void Create(Category category)
        {
            _repo.Create(category); 
        }

        public Category GetById(int? id)
        {
           return _repo.GetById(id);
        }

        public void Edit(Category category)
        {
            _repo.Edit(category);
        }

        public void Delete(int? id)
        {
            _repo.Delete(id);
        }
    }
}
