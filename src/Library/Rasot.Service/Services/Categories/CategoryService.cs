using Rasot.Core.Domain.Categories;
using Rasot.Core.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rasot.Service.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public virtual void Delete(Category item)
        {
            _categoryRepository.Delete(item);
        }

        public virtual Category Find(int Id)
        {
            return _categoryRepository.Find(Id);
        }

        public virtual IList<Category> FindAll()
        {
            return _categoryRepository.Table.ToList();
        }

        public virtual void Insert(Category item)
        {
            _categoryRepository.Insert(item);
        }

        public virtual void Update(Category item)
        {
            _categoryRepository.Update(item);
        }
    }
}
