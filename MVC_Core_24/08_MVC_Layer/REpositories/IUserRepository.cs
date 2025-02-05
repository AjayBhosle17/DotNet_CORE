using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IUserRepository
    {
        void CreateUser(User user);

        User Login(string email, string password);
    }
}
