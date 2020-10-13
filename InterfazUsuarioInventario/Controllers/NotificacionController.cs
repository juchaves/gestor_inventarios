using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using gestor_inventarios.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InterfazUsuarioInventario.Controllers
{
    public class NotificacionController : Controller
    {
        const string URL_BASE_PERSISTENCIA = "http://localhost:6543/api/producto";

        // GET: NotificacionController
        public async Task<ActionResult> Index()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(URL_BASE_PERSISTENCIA);
            List<NotificacionEntity> productos = JsonConvert.DeserializeObject<List<NotificacionEntity>>(json);
            return View(productos);
        }

        // GET: NotificacionController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(URL_BASE_PERSISTENCIA + "/" + id);
            NotificacionEntity notificacion = JsonConvert.DeserializeObject<NotificacionEntity>(json);
            return View(notificacion);
        }

        // GET: NotificacionController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: NotificacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NotificacionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NotificacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NotificacionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NotificacionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
