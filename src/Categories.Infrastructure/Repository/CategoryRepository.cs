using Microsoft.EntityFrameworkCore;
using Categories.Application.Persistance;
using Categories.Domain.Entites;
using Categories.Infrastructure.Persistance;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Categories.Domain.Entities;

namespace Categories.Infrastructure.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(CategoryContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categoryList = await _dbContext.Category
                    .Where(q => q.Flag == true)
                    .ToListAsync();
            return categoryList;
        }

        public async Task CreateCategoryProducts(List<CategoryProductsInfo> categoryProducts)
        {
            var transaction = _dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            try
            {
                var categoryProductList = await _dbContext.ProductsCategory
                   .Where(q => q.CategoryId == categoryProducts[0].CategoryId)
                   .ToListAsync();
                _dbContext.Set<CategoryProductsInfo>().RemoveRange(categoryProductList);
                _dbContext.Set<CategoryProductsInfo>().AddRange(categoryProducts);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
