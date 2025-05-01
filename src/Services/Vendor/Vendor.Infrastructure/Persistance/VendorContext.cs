using Microsoft.EntityFrameworkCore;
using Vendor.Domain.Common;
using Vendor.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vendor.Domain.Entities;

namespace Vendor.Infrastructure.Persistance
{
    public class VendorContext : DbContext
    {
        public VendorContext(DbContextOptions<VendorContext> options) : base(options)
        {
        }

        public DbSet<VendorInfo> Vendor { get; set; }
        public DbSet<VendorProductsInfo> VendorProducts { get; set; }

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
