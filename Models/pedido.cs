using System.ComponentModel.DataAnnotations;

namespace WebAppForm.Models
{
    public class pedido
    {
        public int pedidoId { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime fecha { get; set; } = DateTime.Now;

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El total debe ser un valor positivo.")]
        public decimal total { get; set; }

        [Required, MaxLength(50)]
        public string estado { get; set; }

        [Required]
        public int clienteId { get; set; }

        [Required]
        public int productoId { get; set; }

        [Required, MaxLength(50)]
        public string AdicionadoPor { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime FechaAdicion { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string ModificadoPor { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? FechaModificacion { get; set; }

        // Relaciones
        public cliente cliente { get; set; }
        public producto producto { get; set; }
    }
}
