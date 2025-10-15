using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Api.DTOs
{
    public class PedidoCreateDto
    {
        public int IdUsuario { get; set; } 
        public List<PedidoDetalleCreateDto> Detalles { get; set; } = new();
    }

    public class PedidoDetalleCreateDto
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }
}
