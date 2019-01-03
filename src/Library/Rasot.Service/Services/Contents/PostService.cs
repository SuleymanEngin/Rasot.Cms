using Rasot.Core.Domain.Contents;
using Rasot.Core.Infrastructures;
using System.Collections.Generic;
using System.Linq;

namespace Rasot.Service.Services.Contents
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _postRepository;
        public PostService(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }
        public virtual void Delete(Post item)
        {
            _postRepository.Delete(item);
        }

        public virtual void Delete(int Id)
        {
            _postRepository.Delete(Id);
        }

        public virtual Post Find(int Id)
        {
            return _postRepository.Find(Id);
        }

        public virtual IList<Post> FindAll()
        {
            return _postRepository.Table.ToList();
        }

        public virtual void Insert(Post item)
        {
            _postRepository.Insert(item);
        }

        public virtual void Update(Post item)
        {
            _postRepository.Update(item);
        }
    }
}
