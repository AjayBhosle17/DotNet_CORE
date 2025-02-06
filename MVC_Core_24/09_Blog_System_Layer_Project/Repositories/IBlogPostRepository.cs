using CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBlogPostRepository
    {

        List<Post> GetAll();

        void Create(Post post);

        Post GetById(int? id);

        void Edit(Post post);

        void Delete(int? id);
    }
}
