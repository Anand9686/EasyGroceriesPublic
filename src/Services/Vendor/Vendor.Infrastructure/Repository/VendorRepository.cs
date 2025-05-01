using Microsoft.EntityFrameworkCore;
using Vendor.Application.Persistance;
using Vendor.Domain.Entites;
using Vendor.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendor.Domain.Entities;

namespace Vendor.Infrastructure.Repository
{
    public class VendorRepository: RepositoryBase<VendorInfo>, IVendorRepository
    {
        public VendorRepository(VendorContext dbContext) : base(dbContext)
        {
        }

    public async Task<IEnumerable<VendorInfo>> GetVendors()
    {
            var vendorList = await _dbContext.Vendor
                    .Where(q=>q.Flag==true)
                    .ToListAsync();
        return vendorList;
    }

        public async Task<IEnumerable<VendorInfo>> GetVendor(int vendorid)
        {
            var vendorList = await _dbContext.Vendor
                    .Where(q => q.Flag == true && q.Id == vendorid)
                    .ToListAsync();
            return vendorList;
        }

        public async Task AddVendorProducts(List<VendorProductsInfo> vendorProducts)
        {
            var transaction = _dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            try
            {
                var vendorList = await _dbContext.VendorProducts
                   .Where(v => v.VendorId == vendorProducts[0].VendorId && v.CategoryId == vendorProducts[0].CategoryId)
                   .ToListAsync();
                _dbContext.Set<VendorProductsInfo>().RemoveRange(vendorList);
                _dbContext.Set<VendorProductsInfo>().AddRange(vendorProducts);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<IEnumerable<VendorProductsInfo>> GetVendorProducts(int vendorId, int categoryId)
        {
            var vendorProdList = await _dbContext.VendorProducts
                   .Where(v => v.VendorId == vendorId && v.CategoryId == categoryId)
                   .ToListAsync();

            return vendorProdList;
        }
    }
}
