using Microsoft.EntityFrameworkCore;
using Products.Domain;
using Products.Domain.Common;
using Products.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Products.Infrastructure.Persistance
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductsCategory> ProductsCategory { get; set; }
        public DbSet<ProductDetail> ProductDetail { get; set; }
        public DbSet<ProductDetailHistory> ProductDetailHistory { get; set; }
        public DbSet<ProductStockDetail> ProductStockDetail { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //modelBuilder.Entity<Product>(entity =>
            //{
            //    entity.HasKey(e => e.Id).HasName("PK_Products"); ;
            //    entity.Property(e => e.Name).IsRequired().IsUnique().HasDatabaseName("Idx_Name");
            //    entity.Property(e => e.).IsRequired();
            //});


        }
    }
}
