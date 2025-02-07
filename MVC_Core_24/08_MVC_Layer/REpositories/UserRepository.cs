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
           /*var user = _Context.Users.FirstOrDefault(s=>s.Email==email &&  s.Password==password);

            if (user != null) { 
            
                return user;

            }*/


            // to find all details of users with RoleName

            var user = (from u in _Context.Users 
                       join ur in _Context.UserRoles
                       on u.Id equals ur.UserId
                       join r in _Context.Roles
                       on ur.RoleId equals r.Id
                       where u.Email == email && u.Password == password
                       select new User()
                       {
                           Id = u.Id,
                           FirstName=u.FirstName,
                           LastName=u.LastName,
                           Email=u.Email,
                           Age=u.Age,
                           Password=u.Password,
                           FacebookUrl=u.FacebookUrl,
                           DateOfBirth=u.DateOfBirth,
                           RoleName=r.RoleName
                       })?.FirstOrDefault();

            if (user != null) { 
            
                return user;
            }

            return null;
        }
    }
}
