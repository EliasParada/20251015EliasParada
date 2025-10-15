using Newtonsoft.Json;
using Prueba.Api.Entities;
using Prueba.Api.Interfaces;
using Prueba.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Infrastructure.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<IEnumerable<Pedido>> GetAllAsync()
        {
            return await _pedidoRepository.GetAllAsync();
        }

        public async Task<Pedido?> GetByIdAsync(int id)
        {
            return await _pedidoRepository.GetByIdAsync(id);
        }

        public async Task<bool> RegistrarPedidoAsync(int idUsuario, IEnumerable<(int IdProducto, int Cantidad)> detalles)
        {
            if (detalles == null || !detalles.Any())
                throw new ArgumentException("Debe proporcionar al menos un producto en el pedido.");

            var detallesJson = JsonConvert.SerializeObject(detalles.Select(d => new
            {
                id_producto = d.IdProducto,
                cantidad = d.Cantidad
            }));

            try
            {
                var result = await _pedidoRepository.RegistrarPedidoAsync(idUsuario, detallesJson);
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar pedido: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> CancelarPedidoAsync(int idPedido)
        {
            try
            {
                await _pedidoRepository.CancelarPedidoAsync(idPedido);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cancelar pedido: {ex.Message}");
                return false;
            }
        }
    }

}
