using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppForm.Models
{
    public class pedido
    {
        [Key]
        public int productoId { get; set; }

        [Required, MaxLength(150)]
        public string nombre { get; set; }

        [Required, MaxLength(150)]
        public string descripcion { get; set; }

        [Required]
        public decimal precio { get; set; }

        [Required, MaxLength(50)]
        public string AdicionadoPor { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime FechaAdicion { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string ModificadoPor { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime? FechaModificacion { get; set; }

        public pedido()
        {
            
        }
   
        public pedido(int productoId, string nombre, string descripcion, decimal precio, string adicionadoPor, string modificadoPor, DateTime? fechaModificacion)
        {
            this.productoId = productoId;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            AdicionadoPor = adicionadoPor;
            ModificadoPor = modificadoPor;
            FechaModificacion = fechaModificacion;  
        }

    }
}

