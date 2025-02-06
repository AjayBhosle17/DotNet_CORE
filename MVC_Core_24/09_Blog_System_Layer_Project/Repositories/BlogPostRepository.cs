using CORE;

namespace Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        PostDBContext _context;

        public BlogPostRepository(PostDBContext context)
        {
            _context = context;
        }

        public void Create(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var post = _context.Posts.Find(id);

            if (post != null) { 
            
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }
        }

        public void Edit(Post post)
        {
            var model = _context.Posts.Find(post.PostId);
            if (model != null) { 
            
                model.Title = post.Title;
                model.Content = post.Content;
                model.PublishedDate=post.PublishedDate;

                _context.SaveChanges();
            }

        }

        public List<Post> GetAll()
        {
            return _context.Posts.ToList();
        }

        public Post GetById(int? id)
        {
            var post = _context.Posts.Find(id);

            if (post != null)
            {
                return post;
            }

            return null;
        }
    }
}
