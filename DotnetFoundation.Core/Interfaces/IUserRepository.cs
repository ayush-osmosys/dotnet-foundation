using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetFoundation.Core.Entities;

namespace DotnetFoundation.Core.Interfaces.UserRepo
{
    public interface IUserRepository
    {
        // Method signatures for interacting with user data
        Task<User> GetByIdAsync(string userId);
        Task<Guid> AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(string userId);
    }
}