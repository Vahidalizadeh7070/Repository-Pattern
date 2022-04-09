using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryPattern.Data.ViewModels;

namespace RepositoryPattern.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<RepositoryPattern.Data.ViewModels.BookViewModel> CreateEditBookViewModel { get; set; }
        
    }
}
