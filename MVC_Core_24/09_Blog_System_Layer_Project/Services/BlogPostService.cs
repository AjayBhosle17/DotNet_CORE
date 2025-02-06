using AutoMapper;
using CORE;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BlogPostService : IBlogPostService
    {
        IBlogPostRepository _repo;
        IMapper _mapper;

        public BlogPostService(IBlogPostRepository repo ,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Create(PostModel model)
        {
             var post = _mapper.Map<Post>(model);
             _repo.Create(post);
        }

        public void Edit(PostModel model)
        {
            var post = _mapper.Map<Post>(model);
            _repo.Edit(post);
        }

        public List<PostModel> GetAll()
        {

           var post = _repo.GetAll();
           return _mapper.Map<List<PostModel>>(post);
        }

        public PostModel GetById(int? id)
        {
            var model = _repo.GetById(id);
            return _mapper.Map<PostModel>(model);
        }

        public void Delete(int? id) {

            _repo.Delete(id);
        }
    }
}
