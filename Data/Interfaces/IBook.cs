using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.Interfaces
{
    public interface IBook
    {
        // Add method : add a new book
        Task<Book> Add(Book book);

        // Edit method : update a specific book
        Task<Book> Edit(Book book);

        // Details method : demonstrate the details of a book
        Task<Book> Details(string id);
        
        // List method : demonstrate list of books
        IEnumerable<Book> List();

        // Delete method : delete a specific book
        Task<Book> Delete(string id);
    }
}
