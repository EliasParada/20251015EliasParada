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
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _productoRepository.GetAllUsingStoredProcedureAsync();
        }

        public async Task<Producto?> GetByIdAsync(int id)
            => await _productoRepository.GetByIdAsync(id);

        public async Task<Producto> CreateAsync(Producto producto)
        {
            if (producto.Precio < 0) throw new ArgumentException("El precio debe ser mayor a 0.");
            if (producto.Stock < 0) throw new ArgumentException("La existencia debe ser mayor a 0.");

            await _productoRepository.AddAsync(producto);
            await _productoRepository.SaveChangesAsync();
            return producto;
        }

        public async Task<bool> UpdateAsync(Producto producto)
        {
            var isExisting = await _productoRepository.GetByIdAsync(producto.IdProducto);
            if (isExisting == null) return false;

            isExisting.Nombre = producto.Nombre;
            isExisting.Descripcion = producto.Descripcion;
            isExisting.Precio = producto.Precio;
            isExisting.Stock = producto.Stock;
            isExisting.Activo = producto.Activo;
            isExisting.FechaActualizacion = DateTime.Now;

            _productoRepository.Update(isExisting);
            return await _productoRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var producto = await _productoRepository.GetByIdAsync(id);
            if (producto == null) return false;

            _productoRepository.Delete(producto);
            return await _productoRepository.SaveChangesAsync();
        }
    }
}
