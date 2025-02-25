using System.ComponentModel.DataAnnotations;

namespace WebAppForm.Models
{
    public class cliente
    {
        public int clienteId { get; set; }
        [Required, MaxLength(150)]
        public string nombre { get; set; }
        [Required, EmailAddress, MaxLength(150)]
        public string email { get; set; }
        [Required, Phone, MaxLength(150)]
        public string telefono { get; set; }
        [Required, MaxLength(200)]
        public string direccion { get; set; }
        [Required, MaxLength(50)]
        public string AdicionadoPor { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime FechaAdicion { get; set; } = DateTime.Now;
        [MaxLength(50)]
        public string ModificadoPor { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? FechaModificacion { get; set; }

        public cliente()
        {

        }


     
    }
}
