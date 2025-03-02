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

        // GET: CambiarEstado - Mostrar formulario para cambiar el estado
        public IActionResult CambiarEstado(int id)
        {
            Console.WriteLine($"ID recibido: {id}"); // Mensaje de depuración

            if (id == 0)
            {
                TempData["ErrorMessage"] = "El ID del pedido no puede ser 0.";
                return RedirectToAction("Index");
            }

            var pedido = _acceso.ObtenerPedidoPorId(id); // Obtener el pedido por su ID
            if (pedido == null)
            {
                TempData["ErrorMessage"] = $"El pedido con ID {id} no existe.";
                return RedirectToAction("Index");
            }

            return View(pedido); // Pasar el pedido a la vista
        }

        // POST: CambiarEstado - Procesar la actualización del estado
        [HttpPost]
        public IActionResult CambiarEstado(int id, string nuevoEstado)
        {
            try
            {
                // Usar el procedimiento almacenado para actualizar el estado
                _acceso.ActualizarEstadoPedido(id, nuevoEstado);

                TempData["SuccessMessage"] = "El estado del pedido se actualizó correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al actualizar el estado del pedido: " + ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}