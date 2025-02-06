using AutoMapper;
using CORE;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfile
{
    public class MyAppProfile :Profile
    {
        public MyAppProfile()
        {
            CreateMap<Post,PostModel>().ReverseMap();
        }
    }
}
