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
    }
}
