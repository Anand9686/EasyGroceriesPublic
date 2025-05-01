using Categories.Domain.Entites;
using Categories.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Categories.Application.Persistance
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<IEnumerable<Category>> GetCategories();
        Task CreateCategoryProducts(List<CategoryProductsInfo> categoryProducts);
    }
}
