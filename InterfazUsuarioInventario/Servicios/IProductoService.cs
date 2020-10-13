using gestor_inventarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interfaz_usuario_inventario.Servicios
{
    public interface IProductoService
    {
        Task<List<ProductoEntity>> GetProductosAsync();
        Task<ProductoEntity> GetProductoAsync(int id);
        Task<ProductoEntity> CreateProductoAsync( ProductoEntity p );
        Task<ProductoEntity> UpdateProductoAsync(ProductoEntity p);
        Task DeleteProductoAsync(int id);
    }
}
