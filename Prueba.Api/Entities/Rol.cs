using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Api.Entities
{
    [Table("ROL")]
    public class Rol
    {
        [Key]
        [Column("ID_ROL")]
        public int IdRol { get; set; }

        [Required]
        [Column("NOMBRE")]
        [MaxLength(100)]
        public string Nombre { get; set; } = null!;

        [Column("DESCRIPCION")]
        [MaxLength(255)]
        public string? Descripcion { get; set; }

        [Column("ACTIVO")]
        public bool Activo { get; set; } = true;

        public ICollection<Usuario>? Usuarios { get; set; }
    }
}
