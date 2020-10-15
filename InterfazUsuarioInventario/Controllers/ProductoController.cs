using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using gestor_inventarios.Models;
using interfaz_usuario_inventario.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace InterfazUsuarioInventario.Controllers
{
    public class ProductoController : Controller
    {
        private IProductoService ObtenerServicio()
        {
            var services = new ServiceCollection();
            services.UseServices();
            var serviceProvider = services.BuildServiceProvider();
            IProductoService servicioProductos = serviceProvider.GetRequiredService<IProductoService>();
            return servicioProductos;
        }


        // GET: ProductoController
        public async Task<ActionResult> Index()
        {
            IProductoService servicioProductos = ObtenerServicio();
            List<ProductoEntity> productosAsync = await servicioProductos.GetProductosAsync();
            return View(productosAsync);
        }

        // GET: ProductoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            IProductoService servicioProductos = ObtenerServicio();
            ProductoEntity productoAsync = await servicioProductos.GetProductoAsync(id);
            return View(productoAsync);
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                IProductoService servicioProductos = ObtenerServicio();
                string strAux = DateTime.Now.ToString();
                ProductoEntity pe = new ProductoEntity()
                {
                    Id = int.Parse(collection["Id"].ToString()),
                    Nombre = collection["Nombre"].ToString(),
                    FechaCaducidad = DateTime.Parse(collection["FechaCaducidad"].ToString()),
                    Tipo = collection["Tipo"].ToString(),
                    Expirado = collection["Expirado"].ToString(),
                };
                
                
                ProductoEntity pc = await servicioProductos.CreateProductoAsync(pe);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            IProductoService servicioProductos = ObtenerServicio();
            ProductoEntity productoAsync = await servicioProductos.GetProductoAsync(id);
            return View(productoAsync);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                IProductoService servicioProductos = ObtenerServicio();
                string strAux = DateTime.Now.ToString();
                ProductoEntity pe = new ProductoEntity()
                {
                    Id = int.Parse(collection["Id"].ToString()),
                    Nombre = collection["Nombre"].ToString(),
                    FechaCaducidad = DateTime.Parse(collection["FechaCaducidad"].ToString()),
                    Tipo = collection["Tipo"].ToString(),
                    Expirado = collection["Expirado"].ToString(),
                };

                ProductoEntity pm = await servicioProductos.UpdateProductoAsync(pe);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            IProductoService servicioProductos = ObtenerServicio();
            ProductoEntity productoAsync = await servicioProductos.GetProductoAsync(id);
            return View(productoAsync);
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                IProductoService servicioProductos = ObtenerServicio();
                await servicioProductos.DeleteProductoAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
