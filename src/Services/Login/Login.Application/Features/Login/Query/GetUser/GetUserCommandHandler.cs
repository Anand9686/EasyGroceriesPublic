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

namespace Login.Application.Features.Login.Query.GetUser
{
    public class GetUserCommandHandler : IRequestHandler<GetUserCommand, IEnumerable<GetUserList>>
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserCommandHandler> _logger;

        public GetUserCommandHandler(ILoginRepository loginRepository, IMapper mapper, ILogger<GetUserCommandHandler> logger)
        {
            _loginRepository = loginRepository ?? throw new ArgumentNullException(nameof(loginRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<GetUserList>> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {

            IEnumerable<User> users;
            if (string.IsNullOrEmpty(request.Mobile)){
                users = await _loginRepository.GetUsers();
            }
            else
            {
                users= await _loginRepository.GetUser(request.Mobile);
            }
            var userEntity = _mapper.Map<IEnumerable<GetUserList>>(users);
            _logger.LogInformation($"User {userEntity} is successfully pulled.");

            return userEntity;
        }
    }
}
