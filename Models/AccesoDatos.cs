using System.Data.SqlClient;

namespace WebAppForm.Models
{
    public class AccesoDatos
    {
        private readonly string _conexion;

        public AccesoDatos(IConfiguration configuracion)
        {
            _conexion = configuracion.GetConnectionString("Conexion");
        }

        // Insertar Producto
        public void InsertarProducto(producto nuevoProducto)
        {
            using (SqlConnection con = new SqlConnection(_conexion))
            {
                try
                {
                    string query = "Exec spInsertarProducto @pNombre, @pDescripcion, @pPrecio, @pAdicionadoPor";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@pNombre", nuevoProducto.nombre);
                        cmd.Parameters.AddWithValue("@pDescripcion", nuevoProducto.descripcion);
                        cmd.Parameters.AddWithValue("@pPrecio", nuevoProducto.precio);
                        cmd.Parameters.AddWithValue("@pAdicionadoPor", nuevoProducto.AdicionadoPor);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar el producto: " + ex.Message);
                }
            }
        }

        // Actualizar Producto
        public void ActualizarProducto(producto productoActualizado)
        {
            using (SqlConnection con = new SqlConnection(_conexion))
            {
                try
                {
                    string query = "Exec spActualizarProducto @pProductoId, @pNombre, @pDescripcion, @pPrecio, @pModificadoPor";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@pProductoId", productoActualizado.productoId);
                        cmd.Parameters.AddWithValue("@pNombre", productoActualizado.nombre);
                        cmd.Parameters.AddWithValue("@pDescripcion", productoActualizado.descripcion);
                        cmd.Parameters.AddWithValue("@pPrecio", productoActualizado.precio);
                        cmd.Parameters.AddWithValue("@pModificadoPor", productoActualizado.ModificadoPor);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el producto: " + ex.Message);
                }
            }
        }

        // Eliminar Producto
        public void EliminarProducto(int productoId)
        {
            using (SqlConnection con = new SqlConnection(_conexion))
            {
                try
                {
                    string query = "Exec spEliminarProducto @pProductoId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@pProductoId", productoId);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el producto: " + ex.Message);
                }
            }
        }

        // Consultar Productos
        public List<producto> ConsultarProductos()
        {
            List<producto> productos = new List<producto>();

            using (SqlConnection con = new SqlConnection(_conexion))
            {
                try
                {
                    string query = "Exec spConsultarProductos";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                productos.Add(new producto
                                {
                                    productoId = (int)reader["productoId"],
                                    nombre = reader["nombre"].ToString(),
                                    descripcion = reader["descripcion"].ToString(),
                                    precio = (decimal)reader["precio"],
                                    AdicionadoPor = reader["AdicionadoPor"].ToString(),
                                    FechaAdicion = (DateTime)reader["FechaAdicion"],
                                    ModificadoPor = reader["ModificadoPor"]?.ToString(),
                                    FechaModificacion = reader["FechaModificacion"] as DateTime?
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al consultar los productos: " + ex.Message);
                }
            }
            return productos;
        }

        // Insertar Pedido
        public void InsertarPedido(pedido nuevoPedido)
        {
            using (SqlConnection con = new SqlConnection(_conexion))
            {
                try
                {
                    string query = "Exec spInsertarPedido @pClienteId, @pProductoId, @pTotal, @pEstado, @pAdicionadoPor";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@pClienteId", nuevoPedido.clienteId);
                        cmd.Parameters.AddWithValue("@pProductoId", nuevoPedido.productoId);
                        cmd.Parameters.AddWithValue("@pTotal", nuevoPedido.total);
                        cmd.Parameters.AddWithValue("@pEstado", nuevoPedido.estado);
                        cmd.Parameters.AddWithValue("@pAdicionadoPor", nuevoPedido.AdicionadoPor);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar el pedido: " + ex.Message);
                }
            }
        }

        // Actualizar Pedido
        public void ActualizarPedido(pedido pedidoActualizado)
        {
            using (SqlConnection con = new SqlConnection(_conexion))
            {
                try
                {
                    string query = "Exec spActualizarPedido @pPedidoId, @pTotal, @pEstado, @pModificadoPor";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@pPedidoId", pedidoActualizado.pedidoId);
                        cmd.Parameters.AddWithValue("@pTotal", pedidoActualizado.total);
                        cmd.Parameters.AddWithValue("@pEstado", pedidoActualizado.estado);
                        cmd.Parameters.AddWithValue("@pModificadoPor", pedidoActualizado.ModificadoPor);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el pedido: " + ex.Message);
                }
            }
        }

        // Eliminar Pedido
        public void EliminarPedido(int pedidoId)
        {
            using (SqlConnection con = new SqlConnection(_conexion))
            {
                try
                {
                    string query = "Exec spEliminarPedido @pPedidoId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@pPedidoId", pedidoId);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el pedido: " + ex.Message);
                }
            }
        }

        // Consultar Pedidos
        public List<pedido> ConsultarPedidos()
        {
            List<pedido> pedidos = new List<pedido>();

            using (SqlConnection con = new SqlConnection(_conexion))
            {
                try
                {
                    string query = "Exec spConsultarPedidos";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pedidos.Add(new pedido
                                {
                                    pedidoId = (int)reader["pedidoId"],
                                    fecha = (DateTime)reader["fecha"],
                                    total = (decimal)reader["total"],
                                    estado = reader["estado"].ToString(),
                                    clienteId = (int)reader["clienteId"],
                                    productoId = (int)reader["productoId"]
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al consultar los pedidos: " + ex.Message);
                }
            }
            return pedidos;
        }
    }
}
