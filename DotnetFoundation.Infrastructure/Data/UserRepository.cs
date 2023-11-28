using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetFoundation.Core.Entities;
using DotnetFoundation.Core.Interfaces.UserRepo;
using DotnetFoundation.Infrastructure.Identity;

namespace DotnetFoundation.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddAsync(User user)
        {
            // Assuming Id is a Guid property in your User entity
            _dbContext.Users.Add(user);

            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            // Return the newly created user's Id
            return Guid.Parse(user.Id);
        }
        public async Task<User> GetByIdAsync(string userId)
        {
            return await _dbContext.Users.FindAsync(userId);
        }
        public async Task UpdateAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }

        // Implement other repository methods as needed
    }
}