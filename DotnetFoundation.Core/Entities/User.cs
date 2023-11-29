using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetFoundation.Core.Entities
{
    public class User
    {
        public int Id { get; set; } // Assuming you're using string as the primary key type
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        // Add other properties as needed

        // Navigation properties if relationships are present
        // public ICollection<SomeOtherEntity> OtherEntities { get; set; }
    }
}