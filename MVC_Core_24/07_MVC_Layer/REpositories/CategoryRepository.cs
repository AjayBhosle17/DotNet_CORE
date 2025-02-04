using CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        CoreDbContext _Context;

        public CategoryRepository(CoreDbContext context)
        {
            _Context = context;
        }

        public void Create(Category category)
        {
            _Context.Categories.Add(category);
            _Context.SaveChanges();
        }

        public Category Details(int? id)
        {
            var category = _Context.Categories.Find(id);
            return category;
        }

        public List<Category> GetAll()
        {
           return _Context.Categories.ToList();
        }

    }
}
