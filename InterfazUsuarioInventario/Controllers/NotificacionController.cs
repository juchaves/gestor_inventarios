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
    public class NotificacionController : Controller
    {
        private INotificacionService ObtenerServicio()
        {
            var services = new ServiceCollection();
            services.UseServices();
            var serviceProvider = services.BuildServiceProvider();
            INotificacionService servicioProductos = serviceProvider.GetRequiredService<INotificacionService>();
            return servicioProductos;
        }

        // GET: NotificacionController
        public async Task<ActionResult> Index()
        {
            INotificacionService servicioNotificaciones = ObtenerServicio();
            List<NotificacionEntity> notificacionesAsync = await servicioNotificaciones.GetNotificacionesAsync();
            return View(notificacionesAsync);
        }

        // GET: NotificacionController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            INotificacionService servicioNotificaciones = ObtenerServicio();
            NotificacionEntity notificacionAsync = await servicioNotificaciones.GetNotificacionAsync(id);
            return View(notificacionAsync);
        }

        // GET: NotificacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NotificacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                INotificacionService servicioNotificaciones = ObtenerServicio();
                string strAux = DateTime.Now.ToString();
                NotificacionEntity pe = new NotificacionEntity()
                {
                    Id = int.Parse(collection["Id"].ToString()),
                    Descripcion = collection["Descripcion"],
                    Fecha = DateTime.Parse(collection["Fecha"].ToString()),
                    Tipo = collection["Id"].ToString(),
                };


                NotificacionEntity pc = await servicioNotificaciones.CreateNotificacionAsync(pe);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NotificacionController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            INotificacionService servicioNotificaciones = ObtenerServicio();
            NotificacionEntity notificacionAsync = await servicioNotificaciones.GetNotificacionAsync(id);
            return View(notificacionAsync);
        }

        // POST: NotificacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                INotificacionService servicioNotificaciones = ObtenerServicio();
                string strAux = DateTime.Now.ToString();
                NotificacionEntity pe = new NotificacionEntity()
                {
                    Id = int.Parse(collection["Id"].ToString()),
                    Descripcion = collection["Descripcion"],
                    Fecha = DateTime.Parse(collection["Fecha"].ToString()),
                    Tipo = collection["Id"].ToString(),
                };

                NotificacionEntity pm = await servicioNotificaciones.UpdateNotificacionAsync(pe);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NotificacionController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            INotificacionService servicioNotificaciones = ObtenerServicio();
            NotificacionEntity notificacionAsync = await servicioNotificaciones.GetNotificacionAsync(id);
            return View(notificacionAsync);
        }

        // POST: NotificacionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                INotificacionService servicioNotificaciones = ObtenerServicio();
                await servicioNotificaciones.DeleteNotificacionAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
