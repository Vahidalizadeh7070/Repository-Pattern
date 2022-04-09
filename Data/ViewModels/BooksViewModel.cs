using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.ViewModels
{
    public class BooksViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public string Text { get; set; }
    }
}
