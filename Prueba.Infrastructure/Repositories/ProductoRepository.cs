using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prueba.Api.Entities;
using Prueba.Api.Interfaces;
using Prueba.Infrastructure.Data;

namespace Prueba.Infrastructure.Repositories
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        private readonly AppDbContext _db;

        public ProductoRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Producto>> GetAllUsingStoredProcedureAsync()
        {
            return await _db.Productos
                .FromSqlRaw("EXEC dbo.SP_GET_ALL_PRODUCTS")
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
