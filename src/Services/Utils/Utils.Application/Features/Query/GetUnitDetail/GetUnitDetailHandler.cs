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

namespace Utils.Application.Features.Query.GetUnitDetail
{
    public class GetUnitDetailHandler : IRequestHandler<GetUnitDetailQuery, List<UnitDetail>>
    {
        private readonly IUtilsRepository _utilsRepository;
        private readonly IMapper _mapper;

        public GetUnitDetailHandler(IUtilsRepository utilsRepository, IMapper mapper)
        {
            _utilsRepository = utilsRepository ?? throw new ArgumentNullException(nameof(utilsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<UnitDetail>> Handle(GetUnitDetailQuery request, CancellationToken cancellationToken)
        {
            
            var unitLists = await _utilsRepository.GetUnitDetail(request.UnitId);

            return _mapper.Map<List<UnitDetail>>(unitLists);
        }
    }
}
