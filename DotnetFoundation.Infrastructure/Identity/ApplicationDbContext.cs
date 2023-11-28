using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetFoundation.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotnetFoundation.Infrastructure.Identity
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        // Other DbSet properties for additional entities

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API or data annotations for entity configurations

            // For example, configuring the User entity primary key
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Company>().HasKey(c => c.Id);

            // Add other configurations as needed
        }
    }
}