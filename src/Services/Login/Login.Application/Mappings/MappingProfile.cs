using AutoMapper;
using Login.Application.Features.Commands.CreateUser;
using Login.Application.Features.Login.Query.GetUser;
using Login.Application.Features.Login.Query.GetUserRole;
using Login.Application.Features.Tokens.Add;
using Login.Application.Features.Tokens.Get;
using Login.Domain.Entities;

namespace Login.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserCommand>().ReverseMap();
            CreateMap<User, GetUserList>().ReverseMap();
            //  CreateMap<IEnumerable<User>, IEnumerable<GetUserList>>().ReverseMap();
            CreateMap<UserRefreshTokens, CreateUserRefreshTokenCommand>().ReverseMap();
            CreateMap<UserRoleList, GetUserRoleList>().ReverseMap(); 
            CreateMap<UserRefreshTokens, GetUserRefreshToken>().ReverseMap();

        }
    }
}
