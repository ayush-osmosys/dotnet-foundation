using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetFoundation.Core.Services.UserService;

namespace DotnetFoundation.Infrastructure.Services
{
    public class UserService : IUserService
    {
        public async Task<Guid> CreateUserAsync(string userName, string email, string password)
        {
            // Implementation of CreateUserAsync method
            throw NotImplementedException();
        }

        private Exception NotImplementedException()
        {
            throw new NotImplementedException();
        }
    }
}