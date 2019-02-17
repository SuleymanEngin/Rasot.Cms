using Rasot.Core.Domain.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rasot.Service.Services.Contents
{
    public interface IPostService
    {
        void Insert(Post item);
        void Update(Post item);
        void Delete(Post item);
        void Delete(int Id);
        Post Find(int Id);
        IList<Post> FindAll();
        IQueryable<Post> Query();
    }
}
