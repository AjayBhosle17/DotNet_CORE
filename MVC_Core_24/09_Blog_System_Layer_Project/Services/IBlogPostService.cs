using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBlogPostService
    {
        List<PostModel> GetAll();

        void Create(PostModel model);

        PostModel GetById(int? id);

        void Edit(PostModel model);

        void Delete(int? id);
    }
}
