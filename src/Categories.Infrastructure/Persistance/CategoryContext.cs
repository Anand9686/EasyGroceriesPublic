using Microsoft.EntityFrameworkCore;
using Categories.Domain.Common;
using Categories.Domain.Entites;
using System;
using System.Threading;
using System.Threading.Tasks;
using Categories.Domain.Entities;

namespace Categories.Infrastructure.Persistance
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryProductsInfo> ProductsCategory { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "self";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "self";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
