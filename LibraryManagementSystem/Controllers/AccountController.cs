using Library.Db;
using Library.Db.Models;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private UserDbRepository userRepository;

        public AccountController(UserDbRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View("Autorization");
        }

        [HttpPost]
        public IActionResult Login(AutorizationViewModel autorizationData)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Login");
            var user = userRepository
                .GetAll()
                .FirstOrDefault(u => u.UserName == autorizationData.UserName);
            if (user is null)
            {
                ModelState.AddModelError("", "Пользователя с таким логином не существует!");
                return View("Autorization");
            }
            if (autorizationData.Password != user.Password)
            {
                ModelState.AddModelError("", "Введен неверный пароль!");
                return View("Autorization");
            }
            var cookieOptions = new CookieOptions();
            if (autorizationData.LockoutEnabled)
                cookieOptions.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Append("userLogin", autorizationData.UserName, cookieOptions);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            var cookieOptions = new CookieOptions()
            {
                Expires = DateTime.Now.AddMonths(-1)
            };
            Response.Cookies.Append("userLogin", string.Empty, cookieOptions);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View("Registration");
        }

        [HttpPost]
        public IActionResult Register(RegistrationViewModel registrationData)
        {
            if (!ModelState.IsValid)
                return View("Registration");
            userRepository.Add(new User()
            {
                UserName = registrationData.UserName,
                Password = registrationData.Password,
                Name = registrationData.Name,
                Address = registrationData.Address,
                PhoneNumber = registrationData.PhoneNumber
            });
            return RedirectToAction("Login");
        }
    }
}
