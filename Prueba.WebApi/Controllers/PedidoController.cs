using Microsoft.AspNetCore.Mvc;
using Prueba.Api.DTOs;
using Prueba.Api.Services;

namespace Prueba.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedidos = await _pedidoService.GetAllAsync();

            var result = pedidos.Select(p => new PedidoResponseDto
            {
                IdPedido = p.IdPedido,
                IdUsuario = p.IdUsuario,
                Estado = p.Estado,
                Total = p.Total,
                FechaPedido = p.FechaPedido,
                FechaActualizacion = p.FechaActualizacion
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pedido = await _pedidoService.GetByIdAsync(id);
            if (pedido == null)
                return NotFound();

            var result = new PedidoResponseDto
            {
                IdPedido = pedido.IdPedido,
                IdUsuario = pedido.IdUsuario,
                Estado = pedido.Estado,
                Total = pedido.Total,
                FechaPedido = pedido.FechaPedido,
                FechaActualizacion = pedido.FechaActualizacion
            };

            return Ok(result);
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarPedido([FromBody] PedidoCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var detalles = dto.Detalles.Select(d => (d.IdProducto, d.Cantidad));

            var success = await _pedidoService.RegistrarPedidoAsync(dto.IdUsuario, detalles);
            if (!success)
                return BadRequest("No se pudo registrar el pedido.");

            return Ok(new { mensaje = "Pedido registrado exitosamente." });
        }

        [HttpPut("cancelar")]
        public async Task<IActionResult> CancelarPedido([FromBody] PedidoCancelDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _pedidoService.CancelarPedidoAsync(dto.IdPedido);
            if (!success)
                return BadRequest("No se pudo cancelar el pedido.");

            return Ok(new { mensaje = "Pedido cancelado exitosamente." });
        }
    }

}
