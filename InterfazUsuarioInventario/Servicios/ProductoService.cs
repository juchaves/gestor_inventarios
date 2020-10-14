using gestor_inventarios.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace interfaz_usuario_inventario.Servicios
{
    public class ProductoService : IProductoService
    {
        const string BaseUrl = "http://localhost:61471/api/producto";
        private readonly HttpClient _client;

        public ProductoService( HttpClient client )
        {
            _client = client;
        }

        public async Task<List<ProductoEntity>> GetProductosAsync()
        {
            var httpResponse = await _client.GetAsync($"{BaseUrl}/");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve productos");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var productos = JsonConvert.DeserializeObject<List<ProductoEntity>>(content);

            return productos;
        }

        public async Task<ProductoEntity> GetProductoAsync(int id)
        {
            var httpResponse = await _client.GetAsync($"{BaseUrl}/{id}/");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve producto");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var producto = JsonConvert.DeserializeObject<ProductoEntity>(content);

            return producto;
        }

        public async Task<ProductoEntity> CreateProductoAsync(ProductoEntity producto)
        {
            var content = JsonConvert.SerializeObject(producto);
            var httpResponse = await _client.PostAsync($"{BaseUrl}/", new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot add a producto");
            }

            var productoCreado = JsonConvert.DeserializeObject<ProductoEntity>(await httpResponse.Content.ReadAsStringAsync());
            return productoCreado;
        }

        public async Task<ProductoEntity> UpdateProductoAsync(ProductoEntity producto)
        {
            var content = JsonConvert.SerializeObject(producto);
            var httpResponse = await _client.PutAsync($"{BaseUrl}/{producto.Id}/", new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot update producto");
            }

            var productoCreado = JsonConvert.DeserializeObject<ProductoEntity>(await httpResponse.Content.ReadAsStringAsync());
            return productoCreado;
        }


        public async Task DeleteProductoAsync(int id)
        {
            var httpResponse = await _client.DeleteAsync($"{BaseUrl}/{id}/");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot delete the producto");
            }
        }
    }
}
