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
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context) { _context = context; }
        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();        
        }
        public async Task<Book?> GetByIdAsync(Guid Id)
        {
            return await _context.Books.FindAsync(Id);        
        }
        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid Id)
        {
            var book = await _context.Books.FindAsync(Id);
            if (book != null )
            { 
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

    }
}
