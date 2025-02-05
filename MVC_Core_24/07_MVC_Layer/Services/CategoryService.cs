using CORE;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public void Create(Category category)
        {
            _repo.Create(category);
        }

        public void Delete(int? id)
        {
            _repo.Delete(id);
        }

        public Category Details(int? id)
        {
            return _repo.Details(id);
        }

        public void Edit(Category category)
        {
            _repo.Edit(category);
        }

        public List<Category> GetAll()
        {
            return  _repo.GetAll();
        }
    }
}
