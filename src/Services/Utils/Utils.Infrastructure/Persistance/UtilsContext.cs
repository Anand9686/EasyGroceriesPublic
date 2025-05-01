using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Threading;
using System.Threading.Tasks;
using Utils.Domain.Common;
using Utils.Domain.Entities;

namespace Utils.Infrastructure.Persistance
{
    public class UtilsContext : DbContext
    {
        public UtilsContext(DbContextOptions<UtilsContext> options) : base(options)
        {
        }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<UnitDetail> UnitDetail { get; set; }

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

