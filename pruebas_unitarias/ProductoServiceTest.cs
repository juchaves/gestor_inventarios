using gestor_inventarios.Models;
using interfaz_usuario_inventario.Servicios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace pruebas_unitarias
{
    public class ProductoServiceTest
    {
        [Fact]
        public async Task Create_Producto()
        {
            var services = new ServiceCollection();
            services.UseServices();
            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<IProductoService>();
            var createdTask = await service.CreateProductoAsync(new ProductoEntity
            {
                Id = 1,
                Nombre = "MANZANAS",
                FechaCaducidad = DateTime.Parse( "2021-07-26T00:00:00" ),
                Tipo = "PRUEBAS DE CREATE 1",
                Expirado = false
            }); ;
            Assert.Equal(201, createdTask.Id);
        }

        [Fact]
        public async Task Delete_Producto()
        {
            var services = new ServiceCollection();
            services.UseServices();
            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<IProductoService>();

            await service.DeleteProductoAsync(1);
        }

        [Fact]
        public async Task Get_All_Productos()
        {
            var services = new ServiceCollection();
            services.UseServices();
            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<IProductoService>();

            var tasks = await service.GetProductosAsync();

            Assert.NotEmpty(tasks);
        }

        [Fact]
        public async Task Get_Existing_Producto()
        {
            var services = new ServiceCollection();
            services.UseServices();
            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<IProductoService>();

            var task = await service.GetProductoAsync(1);

            Assert.NotNull(task);
        }

        [Fact]
        public async Task Update_Todo()
        {
            var services = new ServiceCollection();
            services.UseServices();
            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<IProductoService>();

            var updatedProducto = await service.UpdateProductoAsync(new ProductoEntity
            {
                Id = 1,
                Nombre = "PERAS",
                FechaCaducidad = DateTime.Parse("2021-07-26T00:00:00"),
                Tipo = "PRUEBAS DE UPDATE 1",
                Expirado = false
            }); ;

            Assert.True(!updatedProducto.Expirado);
        }
    }
}
