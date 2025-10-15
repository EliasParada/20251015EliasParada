using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Api.Entities
{
    [Table("USUARIO")]
    public class Usuario
    {
        [Key]
        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }

        [Required]
        [ForeignKey(nameof(Rol))]
        [Column("ID_ROL")]
        public int IdRol { get; set; }

        [Required]
        [Column("NOMBRE_USUARIO")]
        [MaxLength(100)]
        public string NombreUsuario { get; set; } = null!;

        [Required]
        [Column("CONTRASENA_HASH")]
        public byte[] ContrasenaHash { get; set; } = Array.Empty<byte>();

        [Required]
        [Column("CORREO")]
        [MaxLength(150)]
        public string Correo { get; set; } = null!;

        [Column("ACTIVO")]
        public bool Activo { get; set; } = true;

        [Column("FECHA_CREACION")]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public Rol? Rol { get; set; }
        public ICollection<Pedido>? Pedidos { get; set; }
    }
}
