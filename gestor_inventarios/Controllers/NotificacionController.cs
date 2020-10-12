using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestor_inventarios.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gestor_inventarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionController : ControllerBase
    {
        public static List<NotificacionEntity> listaNotificaciones = new List<NotificacionEntity>();

        // GET: api/<NotificacionController>
        [HttpGet]
        public IEnumerable<NotificacionEntity> Get()
        {
            return listaNotificaciones;
        }

        // GET api/<NotificacionController>/5
        [HttpGet("{id}")]
        public NotificacionEntity Get(int id)
        {
            return listaNotificaciones.Find( n => n.Id == id ) ;
        }

        // POST api/<NotificacionController>
        [HttpPost]
        public void Post([FromBody] NotificacionEntity value)
        {
            listaNotificaciones.Add(value);
        }

        // PUT api/<NotificacionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] NotificacionEntity value)
        {
            listaNotificaciones.RemoveAll(n => n.Id == id );
            listaNotificaciones.Add(value);
        }

        // DELETE api/<NotificacionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            listaNotificaciones.RemoveAll(n => n.Id == id);
        }
    }
}
