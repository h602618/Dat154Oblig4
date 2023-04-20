using Lib.Context;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebApp.Controllers;

public class HomeController : Controller
{
    readonly MyDbContext ctx = new();

    public IActionResult Index()
    {
        if (LoginUtil.isLoggedIn(HttpContext.Session))
        {
            ViewData["User"] = LoginUtil.getUser(HttpContext.Session);
        }

        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        if (LoginUtil.isValid(username, password))
        {
            var user = ctx.customer.FirstOrDefault(c => c.name == username);
            if (user != null)
            {
                if (LoginUtil.validateUser(username, password, user.name, user.password))
                {
                    LoginUtil.logIn(HttpContext.Session, username);
                    return RedirectToAction("Index", "Customer");
                }
            }
        }

        return RedirectToAction("Index");
    }
}
