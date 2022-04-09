using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data.Interfaces;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.Repositories
{
    public class BookRepository : IBook
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Book> Add(Book book)
        {
            if(book!=null)
            {
                await _context.AddAsync(book);
                await _context.SaveChangesAsync();
            }
            return book;
        }

        public async Task<Book> Delete(string id)
        {
            if(id.Trim() != null || !id.Trim().StartsWith(" ") || id!="")
            {
                var row = _context.Books.Find(id);
                if (row != null)
                {
                    _context.Books.Remove(row);
                    await _context.SaveChangesAsync();
                    return row;
                }
            }
            return null;
        }

        public async Task<Book> Details(string id)
        {
            if (id.Trim() != null || !id.Trim().StartsWith(" ") || id != "")
            {
                var row = await _context.Books.SingleOrDefaultAsync(book => book.Id==id);
                return row;
            }
            return null;
        }

        public async Task<Book> Edit(Book book)
        {
            var model = await _context.Books.FirstOrDefaultAsync(x => x.Id == book.Id);
            if (model != null)
            {
                // We can use AutoMapper instead of this way
                model.Id = book.Id;
                model.Name= book.Name;
                model.ReleaseDate= book.ReleaseDate;
                model.Subject = book.Subject;
                model.Author = book.Author;
                _context.Books.Update(model);
                await _context.SaveChangesAsync();
                return book;
            }

            // Return null
            return null;
        }

        public IEnumerable<Book> List()
        {
            return  _context.Books.ToList();
        }
    }
}
