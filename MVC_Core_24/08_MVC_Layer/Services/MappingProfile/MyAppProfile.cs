using AutoMapper;
using CORE;
using Models;

namespace Services.MappingProfile
{
    public class MyAppProfile :Profile
    {
        public MyAppProfile()
        {
            CreateMap<Category,CategoryModel>().ReverseMap();
            CreateMap<User,UserModel>().ReverseMap();
        }

    }
}
