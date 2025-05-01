using AutoMapper;
using Vendor.Application.Persistance;
using Vendor.Domain.Entites;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Vendor.Application.Features.Commands.CreateVendor
{
    public class CreateVendorCommandHandler : IRequestHandler<CreateVendorCommand, int>
    {
        private readonly IVendorRepository _VendorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateVendorCommandHandler> _logger;

        public CreateVendorCommandHandler(IVendorRepository VendorRepository, IMapper mapper, ILogger<CreateVendorCommandHandler> logger)
        {
            _VendorRepository = VendorRepository ?? throw new ArgumentNullException(nameof(VendorRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CreateVendorCommand request, CancellationToken cancellationToken)
        {
            var VendorEntity = _mapper.Map<VendorInfo>(request);
            var newVendor = await _VendorRepository.AddAsync(VendorEntity);
            
            _logger.LogInformation($"Order {newVendor.Id} is successfully created.");
            
            return newVendor.Id;
        }
    }
}
