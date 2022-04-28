using Microsoft.AspNetCore.Mvc;

namespace MyIT.API.Controllers;

public class Authentication : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}