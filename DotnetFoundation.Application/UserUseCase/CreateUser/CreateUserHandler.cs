using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetFoundation.Core.Services.UserService;
using MediatR;

namespace DotnetFoundation.Application.UserUseCase.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Validate the command if necessary

            // Create a new user using the provided information
            var userId = await _userService.CreateUserAsync(request.UserName, request.Email, request.Password);

            // You might perform additional actions here, such as sending notifications, logging, etc.

            return userId;
        }
    }
}