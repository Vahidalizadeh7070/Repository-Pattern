using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Data.Interfaces;
using RepositoryPattern.Data.ViewModels;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Controllers
{
    public class BookController : Controller
    {
        
        private readonly IBook book;
        private readonly IMapper mapper;

        // Constructor
        // We have an access to the IBook interface methods through the BookController constructor
        public BookController(IBook book, IMapper mapper)
        {
            this.book = book;
            this.mapper = mapper;
        }
        
        // List of Books
        public IActionResult List()
        {
            var books = book.List();
            var bookModel = new BooksViewModel
            {
                Books = books,
                Text = books.Count()== 0 ? "It is empty. Please add a new book"  : books.Count().ToString()
            };
            return View(bookModel);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public async Task<IActionResult> Create(BookViewModel model)
        {
            if(ModelState.IsValid)
            {
                Book books = new Book();
                model.Id = Guid.NewGuid().ToString();
                var AddIsSuccessfull = await book.Add(mapper.Map(model, books));
                if(AddIsSuccessfull != null)
                {
                    return RedirectToAction("List");
                }
            }
            return View(model);
        }

        // GET: Edit
        public async Task<IActionResult> Edit(string id)
        {
            BookViewModel model = new BookViewModel();
            var bookDetails = await book.Details(id);

            return View(mapper.Map(bookDetails, model));
        }

        // POST: Edit
        [HttpPost]
        public async Task<IActionResult> Edit(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                Book books = new Book();
                var AddIsSuccessfull = await book.Edit(mapper.Map(model, books));
                if (AddIsSuccessfull != null)
                {
                    return RedirectToAction("List");
                }
            }
            return View(model);
        }

        // GET: Delete 
        public async Task<IActionResult> Delete(string id)
        {
            BookViewModel model = new BookViewModel();
            var bookDetails = await book.Details(id);
            if(bookDetails == null)
            {
                ViewBag.Message = "There is no book with id " + id;
            }
            return View(mapper.Map(bookDetails, model));
        }

        // POST: Delete
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(string id)
        {
            var model = await book.Details(id);
            if (model == null)
            {
                return RedirectToAction("List");
            }
            await book.Delete(model.Id);
            return RedirectToAction("List");
        }

        // GET: Details 
        public async Task<IActionResult> Details(string id)
        {
            BookViewModel model = new BookViewModel();
            var bookDetails = await book.Details(id);
            if (bookDetails == null)
            {
                ViewBag.Message = "There is no book with id " + id;
            }
            return View(mapper.Map(bookDetails, model));
        }
    }
}
 