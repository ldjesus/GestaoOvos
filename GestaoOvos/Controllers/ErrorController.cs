using Microsoft.AspNetCore.Mvc;

namespace GestaoOvos.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
