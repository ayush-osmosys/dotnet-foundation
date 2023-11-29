using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetFoundation.Core.Entities;
using DotnetFoundation.Core.Interfaces.UserRepo;
using DotnetFoundation.Core.Services.UserService;
using MediatR;

namespace DotnetFoundation.Application.UserUseCase.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            // You can add validation, logging, error handling, etc., as needed
            return await _userRepository.GetUserById(request.UserId);
        }
    }
}