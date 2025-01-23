using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IcategoryRepository
    {
        IEnumerable<Category> GetAll();
        void Create(Category category);

        

        Category GetById(int? id);
     
        void Edit(Category category );

        void Delete(int? id);
    }
}
