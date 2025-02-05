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
        List<CategoryModel> GetAll();
        void Create(CategoryModel category);

        CategoryModel Details(int? id);
    }
}
