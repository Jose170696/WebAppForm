using Microsoft.AspNetCore.Mvc;

namespace WebAppForm.Controllers
{
    public class clienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
