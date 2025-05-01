using AutoMapper;
using Login.Application.Persistance;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Login.Application.Features.Tokens.Get
{
    public class GetUserRefreshTokenHandler : IRequestHandler<GetUserRefreshTokenCommand, GetUserRefreshToken>
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserRefreshTokenHandler> _logger;

        public GetUserRefreshTokenHandler(ILoginRepository loginRepository, IMapper mapper, ILogger<GetUserRefreshTokenHandler> logger)
        {
            _loginRepository = loginRepository ?? throw new ArgumentNullException(nameof(loginRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<GetUserRefreshToken> Handle(GetUserRefreshTokenCommand request, CancellationToken cancellationToken)
        {
             var   refreshToken = await _loginRepository.GetSavedRefreshTokens(request.UserName,request.RefreshToken);
            var userSavedRefreshToken = _mapper.Map<GetUserRefreshToken>(refreshToken);
            _logger.LogInformation($"Refreshtoken {userSavedRefreshToken} is successfully pulled.");

            return userSavedRefreshToken;
        }
    }
}
