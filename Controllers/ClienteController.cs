using Microsoft.AspNetCore.Mvc;
using WebAppForm.Models;

namespace WebAppForm.Controllers
{
    public class ClienteController : Controller
    {
        private readonly AccesoDatos _acceso;

        public ClienteController(AccesoDatos acceso)
        {
            _acceso = acceso;
        }

        public IActionResult Index()
        {
            var clientes = _acceso.ObtenerClientes(); // Método para obtener lista de clientes
            return View(clientes);
        }


        // Acción para mostrar la vista de creación
        public IActionResult Create()
        {
            return View();
        }

        // Acción para procesar el formulario de creación
        [HttpPost]
        public IActionResult Create(cliente modelo)
        {
            if (ModelState.IsValid)
            {
                return View(modelo);
            }

            try
            {
                _acceso.InsertarCliente(modelo);
                TempData["SuccessMessage"] = "El cliente se guardó con éxito.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al guardar el cliente: " + ex.Message;
                return View("Index", modelo);
            }
        }
    }
}