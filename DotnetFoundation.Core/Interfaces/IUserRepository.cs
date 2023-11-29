using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetFoundation.Core.Entities;

namespace DotnetFoundation.Core.Interfaces.UserRepo
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetAll();

        Task<User> GetUserById(int UserId);

        Task<User> AddUser(User toCreate);

        Task<User> UpdateUser(int UserId, string name, string email);

        Task DeleteUser(int UserId);
    }
}