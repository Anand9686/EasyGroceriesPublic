using AutoMapper;
using Login.Application.Persistance;
using Login.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Login.Application.Features.Tokens.Add
{
    public class CreateUserRefreshTokenHandler : IRequestHandler<CreateUserRefreshTokenCommand, int>
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateUserRefreshTokenHandler> _logger;

        public CreateUserRefreshTokenHandler(ILoginRepository loginRepository, IMapper mapper, ILogger<CreateUserRefreshTokenHandler> logger)
        {
            _loginRepository = loginRepository ?? throw new ArgumentNullException(nameof(loginRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CreateUserRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var userRefreshEntity = _mapper.Map<UserRefreshTokens>(request);
            var newVendor = await _loginRepository.AddUserRefreshTokens(userRefreshEntity);

            _logger.LogInformation($"Order {newVendor} is successfully created.");

            return newVendor;
        }
    }
}
