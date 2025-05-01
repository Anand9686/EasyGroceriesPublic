using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Utils.Application.Contracts.Persistance;
using U = Utils.Domain.Entities;

namespace Utils.Application.Features.Query.GetUnitDetailById
{
    public class GetUnitDetailByIdHandler : IRequestHandler<GetUnitDetailByIdQuery, UnitDetailById>
    {
        private readonly IUtilsRepository _utilsRepository;
        private readonly IMapper _mapper;

        public GetUnitDetailByIdHandler(IUtilsRepository utilsRepository, IMapper mapper)
        {
            _utilsRepository = utilsRepository ?? throw new ArgumentNullException(nameof(utilsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UnitDetailById> Handle(GetUnitDetailByIdQuery request, CancellationToken cancellationToken)
        {
            
            var unitLists = await _utilsRepository.GetUnitDetailById(request.UnitDetailId);

            return _mapper.Map<UnitDetailById>(unitLists);
        }
    }
}
