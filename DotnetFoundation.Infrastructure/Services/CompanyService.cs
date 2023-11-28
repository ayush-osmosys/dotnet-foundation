using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetFoundation.Core.Entities;
using DotnetFoundation.Core.Interfaces;
using DotnetFoundation.Core.Services;

namespace DotnetFoundation.Infrastructure.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Guid> CreateCompanyAsync(string companyName, string description)
        {
            // Validate inputs if necessary

            // Create a new company entity
            var newCompany = new Company
            {
                CompanyName = companyName,
                Description = description
                // Add other properties as needed
            };

            // Add the company to the repository
            await _companyRepository.AddAsync(newCompany);

            // You might perform additional actions here, such as logging, etc.

            // Return the company's unique identifier
            return newCompany.Id;
        }
    }
}