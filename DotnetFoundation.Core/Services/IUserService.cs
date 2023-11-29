using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetFoundation.Core.Entities;

namespace DotnetFoundation.Core.Services.UserService
{
    public interface IUserService
    {
        Task<Guid> CreateUserAsync(string userName, string email, string password);
    }
}