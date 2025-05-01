using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Application.Contracts.Persistance;
using Utils.Domain.Entities;
using Utils.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Utils.Infrastructure.Repository
{
    public class UtilsRepository : RepositoryBase<Unit>, IUtilsRepository
    {
        public UtilsRepository(UtilsContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Unit>> GetUnits()
        {
            var unitList = await _dbContext.Unit
                    .Where(q => q.Flag == true)
                    .ToListAsync();
            return unitList;
        }

        public async Task<IEnumerable<UnitDetail>> GetUnitDetail(int unitId)
        {
            var unitList = await _dbContext.UnitDetail
                    .Where(q => q.Flag == true && q.UnitId == unitId)
                    .ToListAsync();
            return unitList;
        }

        public async Task<UnitDetail> GetUnitDetailById(int unitDetailId)
        {
            var unitList = await _dbContext.UnitDetail
                    .Where(q => q.Flag == true && q.Id == unitDetailId).FirstOrDefaultAsync<UnitDetail>();
                    //.FirstOrDefault<UnitDetail>();
            return unitList;
        }

    }
}
