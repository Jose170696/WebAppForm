using System.ComponentModel.DataAnnotations;

namespace WebAppForm.Models
{
    public class producto
    {
        public int productoId { get; set; }
        [Required, MaxLength(150)]
        public string nombre { get; set; }
        [Required, MaxLength(150)]
        public string descripcion { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un valor positivo.")]
        public decimal precio { get; set; }
        [Required, MaxLength(50)]
        public string AdicionadoPor { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime FechaAdicion { get; set; } = DateTime.Now;
        [MaxLength(50)]
        public string ModificadoPor { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? FechaModificacion { get; set; }
    }
}
