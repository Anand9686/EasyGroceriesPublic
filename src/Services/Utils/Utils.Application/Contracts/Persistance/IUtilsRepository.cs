using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Domain.Entities;

namespace Utils.Application.Contracts.Persistance
{
    public interface IUtilsRepository : IAsyncRepository<Unit>
    {
        Task<IEnumerable<Unit>> GetUnits();
        Task<IEnumerable<UnitDetail>> GetUnitDetail(int unitId);
        Task<UnitDetail> GetUnitDetailById(int unitDetailId);

    }
}
