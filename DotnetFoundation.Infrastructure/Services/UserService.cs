using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetFoundation.Core.Entities;
using DotnetFoundation.Core.Interfaces.UserRepo;
using DotnetFoundation.Core.Services.UserService;

namespace DotnetFoundation.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Guid> CreateUserAsync(string userName, string email, string password)
        {
            // Implementation of CreateUserAsync method

            var newUser = new User
            {
                Name = userName,
                Email = email,
                // Set other properties as needed
            };

            // Add the user using the UserRepository
            var user = await _userRepository.AddUser(newUser);

            return Guid.NewGuid(); // Assuming Id is a Guid property in the User class
        }

        private Exception NotImplementedException()
        {
            throw new NotImplementedException();
        }
    }
}