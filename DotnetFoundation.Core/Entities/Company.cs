using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetFoundation.Core.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        // Add other properties as needed

        // Navigation properties if relationships are present
        // public ICollection<SomeOtherEntity> OtherEntities { get; set; }
    }
}