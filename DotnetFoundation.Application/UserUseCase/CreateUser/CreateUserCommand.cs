using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace DotnetFoundation.Application.UserUseCase.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Additional properties for creating a user, if needed

        // You might also include validation logic or other business rules here
    }
}