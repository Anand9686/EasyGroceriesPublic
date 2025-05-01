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

namespace Login.Application.Features.Tokens.Delete
{
   public class DeleteUserRefreshTokenHandler : IRequestHandler<DeleteUserRefreshTokenCommand, int>
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteUserRefreshTokenHandler> _logger;

        public DeleteUserRefreshTokenHandler(ILoginRepository loginRepository, IMapper mapper, ILogger<DeleteUserRefreshTokenHandler> logger)
        {
            _loginRepository = loginRepository ?? throw new ArgumentNullException(nameof(loginRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(DeleteUserRefreshTokenCommand request, CancellationToken cancellationToken)
        {
           // var userRefreshEntity = _mapper.Map<UserRefreshTokens>(request);
            var newVendor = await _loginRepository.DeleteUserRefreshTokens(request.UserName, request.RefreshToken);

            _logger.LogInformation($"Refresh token {newVendor} is successfully deleted.");

            return newVendor;
        }
    }
}
