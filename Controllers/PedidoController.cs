using Microsoft.AspNetCore.Mvc;
using WebAppForm.Models;

namespace WebAppForm.Controllers
{
    public class PedidoController : Controller
    {
        private readonly AccesoDatos _acceso;

        public PedidoController(AccesoDatos acceso)
        {
            _acceso = acceso;
        }

        public IActionResult Index()
        {
            var pedidos = _acceso.ObtenerPedidos(); // Método para obtener lista de pedidos
            return View(pedidos);
        }
        // Acción para mostrar la vista de creación
        public IActionResult Create()
        {
            return View();
        }

        // Acción para procesar el formulario de creación
        [HttpPost]
        public IActionResult Create(pedido modelo)
        {
            if (ModelState.IsValid)
            {
                return View(modelo);
            }

            try
            {
                _acceso.InsertarPedido(modelo);
                TempData["SuccessMessage"] = "El pedido se guardó con éxito.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al guardar el pedido: " + ex.Message;
                var pedidos = _acceso.ObtenerPedidos(); // Obtener la lista de pedidos antes de devolver Index
                return View("Index", pedidos);
            }
        }
    }
}