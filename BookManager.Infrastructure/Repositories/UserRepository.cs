using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManager.Application.Interfaces;
using BookManager.Domain.Entities;
using BookManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;



namespace BookManager.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) { _context = context; }

        public async Task<User?> GetByEmailAsync(String Email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email==Email);        
        }
        public async Task AddAsync(User user)
        { 
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        
    }
}
