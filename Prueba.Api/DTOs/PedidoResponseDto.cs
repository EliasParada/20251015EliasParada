using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Api.DTOs
{
    public class PedidoResponseDto
    {
        public int IdPedido { get; set; }
        public int IdUsuario { get; set; }
        public string Estado { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public List<PedidoDetalleResponseDto>? Detalles { get; set; }
    }

    public class PedidoDetalleResponseDto
    {
        public int IdProducto { get; set; }
        public string? NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}
