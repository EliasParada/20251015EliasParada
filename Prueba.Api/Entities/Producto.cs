using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Api.Entities
{
    [Table("PRODUCTO")]
    public class Producto
    {
        [Key]
        [Column("ID_PRODUCTO")]
        public int IdProducto { get; set; }

        [Required]
        [Column("CODIGO")]
        [MaxLength(50)]
        public string Codigo { get; set; } = null!;

        [Required]
        [Column("NOMBRE")]
        [MaxLength(150)]
        public string Nombre { get; set; } = null!;

        [Column("DESCRIPCION")]
        [MaxLength(500)]
        public string? Descripcion { get; set; }

        [Required]
        [Column("PRECIO")]
        public decimal Precio { get; set; }

        [Required]
        [Column("STOCK")]
        public int Stock { get; set; }

        [Column("ACTIVO")]
        public bool Activo { get; set; } = true;

        [Column("FECHA_CREACION")]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        [Column("FECHA_ACTUALIZACION")]
        public DateTime? FechaActualizacion { get; set; }

        public ICollection<DetallePedido>? DetallesPedido { get; set; }
        public ICollection<BitacoraInventario>? BitacorasInventario { get; set; }
    }
}
