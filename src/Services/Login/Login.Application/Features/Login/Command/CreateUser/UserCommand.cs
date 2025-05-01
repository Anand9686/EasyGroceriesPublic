using MediatR;
using System;

namespace Login.Application.Features.Commands.CreateUser
{
    public class UserCommand : IRequest<int>
    {
        public string Mobile { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
    }
}
