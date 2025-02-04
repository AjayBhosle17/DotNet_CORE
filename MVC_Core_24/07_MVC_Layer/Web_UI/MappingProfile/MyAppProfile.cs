using AutoMapper;
using CORE;
using Web_UI.Models;

namespace Web_UI.MappingProfile
{
    public class MyAppProfile: Profile
    {
        public MyAppProfile()
        {
            CreateMap<Category, CategoryModel>().ReverseMap();
        }
    }
}
