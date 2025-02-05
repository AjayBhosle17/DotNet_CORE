using CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICategoryService 
    {
        List<Category> GetAll();
        void Create(Category category);

        Category Details(int? id);

        void Edit(Category category);

        void Delete(int? id);
    }
}
