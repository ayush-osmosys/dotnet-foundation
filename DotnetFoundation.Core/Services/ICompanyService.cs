using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetFoundation.Core.Services
{
    public interface ICompanyService
    {
        Task<Guid> CreateCompanyAsync(string companyName, string description);
        // Add other company-related methods as needed
    }
}