using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetFoundation.Core.Entities;
using DotnetFoundation.Core.Interfaces;
using DotnetFoundation.Infrastructure.Identity;

namespace DotnetFoundation.Infrastructure.Data
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddAsync(Company company)
        {
            // Assuming Id is a Guid property in your Company entity
            _dbContext.Companies.Add(company);

            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            // Return the newly created company's Id
            return company.Id;
        }

        // Implement other repository methods as needed
    }
}