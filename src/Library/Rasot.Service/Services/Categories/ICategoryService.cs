using Rasot.Core.Domain.Categories;
using System.Collections.Generic;

namespace Rasot.Service.Services.Categories
{
    public interface ICategoryService
    {
        void Insert(Category item);
        void Update(Category item);

        void Delete(Category item);
        Category Find(int Id);
        IList<Category> FindAll();
    }
}
