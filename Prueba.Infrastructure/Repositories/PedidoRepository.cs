using Microsoft.EntityFrameworkCore;
using Prueba.Api.Entities;
using Prueba.Api.Interfaces;
using Prueba.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Infrastructure.Repositories
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        private readonly AppDbContext _db;

        public PedidoRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<int> RegistrarPedidoAsync(int idUsuario, string detallesJson)
        {
            var idOutput = await _db.Database
                .ExecuteSqlRawAsync("EXEC dbo.SP_REGISTRAR_PEDIDO @p0, @p1", idUsuario, detallesJson);

            return idOutput;
        }

        public async Task CancelarPedidoAsync(int idPedido)
        {
            await _db.Database.ExecuteSqlRawAsync("EXEC dbo.SP_CANCELAR_PEDIDO @p0", idPedido);
        }
    }
}
