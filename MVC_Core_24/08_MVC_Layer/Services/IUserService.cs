using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        void CreateUser(UserModel user);

        UserModel Login(string email , string password);
    }
}
