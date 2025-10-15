using Prueba.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Api.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<int> RegistrarPedidoAsync(int idUsuario, string detallesJson);
        Task CancelarPedidoAsync(int idPedido);
    }
}
