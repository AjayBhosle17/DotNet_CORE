using CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();

        void Create(Category category);

        Category Details(int? id);
    }
}
