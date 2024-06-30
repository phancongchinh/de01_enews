using Microsoft.AspNetCore.Mvc;

namespace De01_Enews.Controllers;

public class UserController : Controller
{
    public IActionResult Info()
    {
        return View();
    }
}