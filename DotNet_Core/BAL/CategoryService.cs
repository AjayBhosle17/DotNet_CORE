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
    }
}
