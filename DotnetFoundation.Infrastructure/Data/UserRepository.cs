using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetFoundation.Core.Entities;
using DotnetFoundation.Core.Interfaces.UserRepo;
using DotnetFoundation.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace DotnetFoundation.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _dbContext;

        public UserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> AddUser(User toCreate)
        {
            _dbContext.Users.Add(toCreate);

            await _dbContext.SaveChangesAsync();

            return toCreate;
        }

        public async Task DeleteUser(int UserId)
        {
            var User = _dbContext.Users
                .FirstOrDefault(p => p.Id == UserId);

            if (User is null) return;

            _dbContext.Users.Remove(User);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<User>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int UserId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(p => p.Id == UserId);
        }

        public async Task<User> UpdateUser(int UserId, string name, string email)
        {
            var User = await _dbContext.Users.FirstOrDefaultAsync(p => p.Id == UserId);

            if (User == null) return null; // Handle the case where the person is not found

            User.Name = name;
            User.Email = email;

            await _dbContext.SaveChangesAsync();

            return User;
        }

        // Implement other repository methods as needed
    }
}