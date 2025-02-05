using AutoMapper;
using CORE;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _repo;
        IMapper _mapper;

        public CategoryService(ICategoryRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Create(CategoryModel category)
        {
            var c = _mapper.Map<Category>(category);
            _repo.Create(c);
        }

        public CategoryModel Details(int? id)
        {
            var category = _repo.Details(id);
            var categoryModel = _mapper.Map<CategoryModel>(category);
            return categoryModel;
        }

        public List<CategoryModel> GetAll()
        {
            var category = _repo.GetAll();
            var categoryModel = _mapper.Map<List<CategoryModel>>(category);

            return  categoryModel;
        }
    }
}
