using Microsoft.AspNetCore.Mvc;

namespace LanchesJC.Controllers;

public class ContatoController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}