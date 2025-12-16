using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth_API.Models;
using Microsoft.EntityFrameworkCore;// Importing Entity Framework Core

namespace Auth_API.Data
{
    public class AppDbContext : DbContext // Application database context
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } // Constructor with options

        public DbSet<User> Users { get; set; } // DbSet for User entities

    }
}
