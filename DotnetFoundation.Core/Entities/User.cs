using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetFoundation.Core.Entities
{
    public class User
    {
        public string Id { get; set; } // Assuming you're using string as the primary key type
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        // Add other properties as needed

        // Navigation properties if relationships are present
        // public ICollection<SomeOtherEntity> OtherEntities { get; set; }
    }
}