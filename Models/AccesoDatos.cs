using System.Data.SqlClient;

namespace WebAppForm.Models
{
    public class AccesoDatos
    {
        //almacenar la cadena de conexion a la base de datos
        private readonly string _conexion;

        public AccesoDatos(IConfiguration configuracion)
        {
            _conexion = configuracion.GetConnectionString("Conexion");
        }

        // Insertar Cliente
        public void InsertarCliente(cliente nuevoCliente)
        {
            using (SqlConnection con = new SqlConnection(_conexion))
            {
                try
                {
                    string query = "Exec spInsertarCliente @pNombre, @pEmail, @pTelefono, @pDireccion, @pAdicionadoPor";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@pNombre", nuevoCliente.nombre);
                        cmd.Parameters.AddWithValue("@pEmail", nuevoCliente.email);
                        cmd.Parameters.AddWithValue("@pTelefono", nuevoCliente.telefono);
                        cmd.Parameters.AddWithValue("@pDireccion", nuevoCliente.direccion);
                        cmd.Parameters.AddWithValue("@pAdicionadoPor", nuevoCliente.AdicionadoPor);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al registrar el cliente" + ex.Message);
                }
            }
        }

        // Obtener Lista de Clientes
        public List<cliente> ObtenerClientes()
        {
            List<cliente> clientes = new List<cliente>();

            using (SqlConnection con = new SqlConnection(_conexion))
            {
                string query = "Exec spObtenerClientes";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            clientes.Add(new cliente
                            {
                                nombre = dr["Nombre"].ToString(),
                                email = dr["Email"].ToString(),
                                telefono = dr["Telefono"].ToString(),
                                direccion = dr["Direccion"].ToString(),
                                AdicionadoPor = dr["AdicionadoPor"].ToString()
                            });
                        }
                    }
                }
            }
            return clientes;
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
                    throw new Exception("Error al registrar el producto: " + ex.Message);
                }
            }
        }

        // Obtener Lista de Productos
        public List<producto> ObtenerProductos()
        {
            List<producto> productos = new List<producto>();

            using (SqlConnection con = new SqlConnection(_conexion))
            {
                string query = "Exec spObtenerProductos";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            productos.Add(new producto
                            {
                                nombre = dr["Nombre"].ToString(),
                                descripcion = dr["Descripcion"].ToString(),
                                precio = Convert.ToDecimal(dr["Precio"]),
                                AdicionadoPor = dr["AdicionadoPor"].ToString()
                            });
                        }
                    }
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
                    string query = "EXEC spInsertarPedido @ClienteId, @ProductoId, @Total, @Estado, @AdicionadoPor";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ClienteId", nuevoPedido.clienteId);
                        cmd.Parameters.AddWithValue("@ProductoId", nuevoPedido.productoId);
                        cmd.Parameters.AddWithValue("@Total", nuevoPedido.total);
                        cmd.Parameters.AddWithValue("@Estado", nuevoPedido.estado);
                        cmd.Parameters.AddWithValue("@AdicionadoPor", nuevoPedido.AdicionadoPor);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al registrar el pedido: " + ex.Message);
                }
            }
        }

        // Obtener Lista de Pedidos
        public List<pedido> ObtenerPedidos()
        {
            List<pedido> pedidos = new List<pedido>();

            using (SqlConnection con = new SqlConnection(_conexion))
            {
                string query = "Exec spObtenerPedidos";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            pedidos.Add(new pedido
                            {
                                fecha = Convert.ToDateTime(dr["Fecha"]),
                                total = Convert.ToDecimal(dr["Total"]),
                                estado = dr["Estado"].ToString(),
                                clienteId = Convert.ToInt32(dr["ClienteId"]),
                                productoId = Convert.ToInt32(dr["ProductoId"]),
                                AdicionadoPor = dr["AdicionadoPor"].ToString()
                            });
                        }
                    }
                }
            }
            return pedidos;
        }
    }
}
