using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetFoundation.Core.Entities;

namespace DotnetFoundation.Core.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Guid> AddAsync(Company company);
        // Add other repository methods as needed
    }
}