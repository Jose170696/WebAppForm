using Microsoft.AspNetCore.Mvc;

namespace WebAppForm.Controllers
{
    public class productoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
