using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Api.Entities
{
    [Table("DETALLE_PEDIDO")]
    public class DetallePedido
    {
        [Key]
        [Column("ID_DETALLE_PEDIDO")]
        public int IdDetallePedido { get; set; }

        [Required]
        [ForeignKey(nameof(Pedido))]
        [Column("ID_PEDIDO")]
        public int IdPedido { get; set; }

        [Required]
        [ForeignKey(nameof(Producto))]
        [Column("ID_PRODUCTO")]
        public int IdProducto { get; set; }

        [Required]
        [Column("CANTIDAD")]
        public int Cantidad { get; set; }

        [Required]
        [Column("PRECIO_UNITARIO")]
        public decimal PrecioUnitario { get; set; }

        // Computado en SQL (no se actualiza por EF)
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("SUBTOTAL")]
        public decimal Subtotal { get; private set; }

        public Pedido? Pedido { get; set; }
        public Producto? Producto { get; set; }
    }
}
