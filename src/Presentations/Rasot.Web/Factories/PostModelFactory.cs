using Microsoft.EntityFrameworkCore;
using Rasot.Core.Domain.Categories;
using Rasot.Core.Domain.Contents;
using Rasot.Service.Services.Categories;
using Rasot.Service.Services.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rasot.Web.Factories
{
    public class PostModelFactory : IPostModelFactory
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        public PostModelFactory(IPostService postService,ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }
        public dynamic PreparePostModel(List<string> includes)
        {

            Post post = new Post();
            post.Title = "Merhaba dünya";
            post.Content = "Merhaba Dünya açıklama";
            post.CustomerId = 1;

            Category category = new Category();
            category.Name = "Haberler";
            _categoryService.Insert(category);


            post.PostCategories.Add(new PostCategoryMapping()
            {
                CategoryId = category.Id,
            });

            _postService.Insert(post);

            var query = _postService.Query()
                    .Include(p => p.PostCategories)
                    .ThenInclude(c => c.Category)
                    .Include(p => p.Customer);
                     



           

            return query.ToList();
        }
    }
}
