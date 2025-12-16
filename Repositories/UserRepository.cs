using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth_API.Models;
using Auth_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Auth_API.Repositories
{
    public class UserRepository // Repository for managing User entities
    {
        private readonly AppDbContext _context; // Database context
        public UserRepository(AppDbContext context)     // Constructor with dependency injection
        {
            _context = context;
        }
        public async Task<User> GetByEmailAsync(string email) // Get user by email
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetByIdAsync(int id)    // Get user by ID
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddAsync(User user)   // Add a new user
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
