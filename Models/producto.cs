using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppForm.Models
{
    public class producto
    {
        [Key] public int pedidoId { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime fecha { get; set; } = DateTime.Now;

        [Required]
        public decimal total { get; set; }

        [Required, MaxLength(50)] public string estado { get; set; }

        [Required] public int clienteId { get; set; }
        [Required] public int productoId { get; set; }

        public string AdicionadoPor { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime FechaAdicion { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string ModificadoPor { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? FechaModificacion { get; set; }

        public producto()
        {
            
        }

        public producto(int pedidoId, decimal total, string estado, int clienteId, int productoId, string adicionadoPor, string modificadoPor, DateTime? fechaModificacion)
        {
            this.pedidoId = pedidoId;
            this.total = total;
            this.estado = estado;
            this.clienteId = clienteId;
            this.productoId = productoId;
            AdicionadoPor = adicionadoPor;
            ModificadoPor = modificadoPor;
            FechaModificacion = fechaModificacion;  
        }
    }


}
