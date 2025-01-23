using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : IcategoryRepository
    {
        ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }

       

        public IEnumerable<Category> GetAll()
        {
            return _context.categories.ToList();
        }


        public void Create(Category category)
        {
            _context.categories.Add(category);
            _context.SaveChanges();
            
        }
        public Category GetById(int? id)
        {
           return _context.categories.Find(id);
            
        }

        public void Edit(Category category)
        {
            var category1 = _context.categories.Find(category.Id);

            if (category1 != null)
            {
                category1.Name = category.Name;
                category1.Rating = category.Rating;

                _context.SaveChanges();
            }
        }

        public void Delete(int? id)
        {
            var category = _context.categories.Find(id);
            if (category != null)
            {
                _context.categories.Remove(category);
                _context.SaveChanges();
            }
        }

       
    }
}
