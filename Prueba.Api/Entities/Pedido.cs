using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Api.Entities
{
    [Table("PEDIDO")]
    public class Pedido
    {
        [Key]
        [Column("ID_PEDIDO")]
        public int IdPedido { get; set; }

        [Required]
        [ForeignKey(nameof(Usuario))]
        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }

        [Required]
        [Column("ESTADO")]
        [MaxLength(20)]
        public string Estado { get; set; } = "PENDIENTE";

        [Required]
        [Column("TOTAL")]
        public decimal Total { get; set; }

        [Column("FECHA_PEDIDO")]
        public DateTime FechaPedido { get; set; } = DateTime.UtcNow;

        [Column("FECHA_ACTUALIZACION")]
        public DateTime? FechaActualizacion { get; set; }

        public Usuario? Usuario { get; set; }
        public ICollection<DetallePedido>? DetallesPedido { get; set; }
    }
}