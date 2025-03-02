using Microsoft.AspNetCore.Mvc;
using WebAppForm.Models;

namespace WebAppForm.Controllers
{
    public class ProductoController : Controller
    {
        private readonly AccesoDatos _acceso;

        public ProductoController(AccesoDatos acceso)
        {
            _acceso = acceso;
        }

        public IActionResult Index()
        {
            var productos = _acceso.ObtenerProductos(); // Método para obtener lista de productos
            return View(productos);
        }

        // Acción para mostrar la vista de creación
        public IActionResult Create()
        {
            return View();
        }

        // Acción para procesar el formulario de creación
        [HttpPost]
        public IActionResult Create(producto modelo)
        {
            if (ModelState.IsValid)
            {
                return View(modelo);
            }

            try
            {
                _acceso.InsertarProducto(modelo);
                TempData["SuccessMessage"] = "El producto se guardó con éxito.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al guardar el producto: " + ex.Message;
                return View(modelo);
            }
        }
    }
}