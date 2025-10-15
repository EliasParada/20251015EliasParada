using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Api.Entities
{
    [Table("BITACORA_INVENTARIO")]
    public class BitacoraInventario
    {
        [Key]
        [Column("ID_BITACORA")]
        public int IdBitacora { get; set; }

        [Required]
        [ForeignKey(nameof(Producto))]
        [Column("ID_PRODUCTO")]
        public int IdProducto { get; set; }

        [ForeignKey(nameof(Usuario))]
        [Column("ID_USUARIO")]
        public int? IdUsuario { get; set; }

        [Required]
        [Column("ACCION")]
        [MaxLength(50)]
        public string Accion { get; set; } = null!;

        [Required]
        [Column("CANTIDAD")]
        public int Cantidad { get; set; }

        [Column("FECHA")]
        public DateTime Fecha { get; set; } = DateTime.UtcNow;

        public Producto? Producto { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
