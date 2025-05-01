using AutoMapper;
using Login.Application.Persistance;
using Login.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Login.Application.Features.Commands.CreateUser
{
    public class UserCommandHandler : IRequestHandler<UserCommand, int>
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserCommandHandler> _logger;

        public UserCommandHandler(ILoginRepository loginRepository, IMapper mapper, ILogger<UserCommandHandler> logger)
        {
            _loginRepository = loginRepository ?? throw new ArgumentNullException(nameof(loginRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(UserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = _mapper.Map<User>(request);
            var newProduct = await _loginRepository.AddAsync(userEntity);
            
            _logger.LogInformation($"User {newProduct.Id} is successfully created.");
            
            return newProduct.Id;
        }
    }
}
