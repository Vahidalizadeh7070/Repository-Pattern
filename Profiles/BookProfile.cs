using AutoMapper;
using RepositoryPattern.Data.ViewModels;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            // Source --> Target
            CreateMap<BookViewModel, Book>();
            CreateMap<Book, BookViewModel>();
        }
    }
}
