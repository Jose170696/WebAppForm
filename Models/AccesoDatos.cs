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
    }
}
