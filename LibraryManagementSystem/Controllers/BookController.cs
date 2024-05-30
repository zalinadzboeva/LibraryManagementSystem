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
        private readonly UserDbRepository userRepository;

        public BookController(BookDbRepository bookRepository,
            UserDbRepository userRepository)
        {
            this.bookRepository = bookRepository;   
            this.userRepository = userRepository;
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
                var newBook = Helpers.Mapping.ToBook(bookViewModel);
                var userName = Request.Cookies["userLogin"];
                bookRepository.AddBook(userName, newBook);
                return RedirectToAction(nameof(Index));
            }
            return View(bookViewModel);
        }

        // GET: Books
        public IActionResult Index()
        {
            var userName = Request.Cookies["userLogin"];
            ViewData["userLogin"] = userName;
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
