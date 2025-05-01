using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utils.Application.Contracts.Persistance;
using U = Utils.Domain.Entities;

namespace Utils.Application.Features.Query.GetUnitList
{
    public class GetUnitListHandler : IRequestHandler<GetUnitListQuery, List<UnitLists>>
    {
        private readonly IUtilsRepository _utilsRepository;
        private readonly IMapper _mapper;

        public GetUnitListHandler(IUtilsRepository utilsRepository, IMapper mapper)
        {
            _utilsRepository = utilsRepository ?? throw new ArgumentNullException(nameof(utilsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<UnitLists>> Handle(GetUnitListQuery request, CancellationToken cancellationToken)
        {
            
            var unitLists = await _utilsRepository.GetUnits();

            return _mapper.Map<List<UnitLists>>(unitLists);
        }
    }
}
