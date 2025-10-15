using Prueba.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Api.Services
{
    public interface IPedidoService
    {
        Task<IEnumerable<Pedido>> GetAllAsync();
        Task<Pedido?> GetByIdAsync(int id);
        Task<bool> RegistrarPedidoAsync(int idUsuario, IEnumerable<(int IdProducto, int Cantidad)> detalles);
        Task<bool> CancelarPedidoAsync(int idPedido);
    }
}
