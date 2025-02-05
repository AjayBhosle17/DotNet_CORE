using AutoMapper;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        IUserRepository _repo;
        IMapper _mapper;

        public UserService(IUserRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;  
        }

        public void CreateUser(UserModel user)
        {
            var User = _mapper.Map<User>(user);
            _repo.CreateUser(User);
            
        }

        public UserModel Login(string email, string password)
        {
            User user = _repo.Login(email, password);

           return _mapper.Map<UserModel>(user);
        }
    }
}
