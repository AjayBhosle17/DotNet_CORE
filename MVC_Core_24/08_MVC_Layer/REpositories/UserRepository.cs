using CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {

        CoreDbContext _Context;

        public UserRepository(CoreDbContext context)
        {
            _Context = context;
        }
        public void CreateUser(User user)
        {
            _Context.Users.Add(user);
            _Context.SaveChanges();

            _Context.UserRoles.Add(new UserRole() { UserId = user.Id, RoleId=2 });
            _Context.SaveChanges();
        }

        public User Login(string email, string password)
        {
           var user = _Context.Users.FirstOrDefault(s=>s.Email==email &&  s.Password==password);

            if (user != null) { 
            
                return user;

            }
            return null;
        }
    }
}
