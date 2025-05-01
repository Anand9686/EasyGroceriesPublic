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

namespace Login.Application.Features.Login.Query.GetUserRole
{
    public class GetUserRoleCommandHandler : IRequestHandler<GetUserRoleCommand, IEnumerable<GetUserRoleList>>
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserRoleCommandHandler> _logger;

        public GetUserRoleCommandHandler(ILoginRepository loginRepository, IMapper mapper, ILogger<GetUserRoleCommandHandler> logger)
        {
            _loginRepository = loginRepository ?? throw new ArgumentNullException(nameof(loginRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<GetUserRoleList>> Handle(GetUserRoleCommand request, CancellationToken cancellationToken)
        {

            IEnumerable<UserRoleList> userRoles;
            userRoles = await _loginRepository.GetUserRoles(request.Mobile);
            var userRoleEntity = _mapper.Map<IEnumerable<GetUserRoleList>>(userRoles);
            _logger.LogInformation($"User {userRoleEntity} is successfully pulled.");

            return userRoleEntity;
        }
    }
}
