using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();

        void Create(Category category);

        Category GetById(int? id);

        void Edit(Category category);

        void Delete(int? id);
    }
}
