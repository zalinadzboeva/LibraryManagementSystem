using Library.Db;
using Library.Db.Models;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly BookDbRepository bookRepository;

        public BookController(BookDbRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        // GET: Books/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //// POST: Books/Create
        [HttpPost]
        public IActionResult Create(BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                bookRepository.AddBook(Helpers.Mapping.ToBook(bookViewModel));
                return RedirectToAction(nameof(Index));
            }
            return View(bookViewModel);
        }

        // GET: Books
        public IActionResult Index()
        {
            return View(Helpers.Mapping.ToBookViewModels(bookRepository.GetAllBooks()));
        }
        public IActionResult OpenBook(int id)
        {
            var bookViewModel = bookRepository.TryGetById(id);
            if (bookViewModel == null) {
                return View();
            }
            return View(Helpers.Mapping.ToBookViewModel(bookViewModel));
        }
    }
}
