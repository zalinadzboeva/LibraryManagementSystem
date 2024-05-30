using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Views.Shared.Components.Account
{
	public class AccountViewComponent : ViewComponent
	{
        public IViewComponentResult Invoke()
        {
            var userLogin = HttpContext.Request.Cookies["userLogin"];
            return View("Account", userLogin);
        }
    }
}
