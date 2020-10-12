using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using gestor_inventarios.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gestor_inventarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        public static List<ProductoEntity> listaProductos = new List<ProductoEntity>();

        // GET: api/<ProductoController>
        [HttpGet]
        public IEnumerable<ProductoEntity> Get()
        {
            return listaProductos;
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public ProductoEntity Get(int id)
        {
            return listaProductos.Find( p => p.Id == id );
        }

        // POST api/<ProductoController>
        [HttpPost]
        public void Post([FromBody] ProductoEntity value)
        {
            listaProductos.Add(value);
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductoEntity value)
        {
            listaProductos.RemoveAll(p => p.Id == id);
            listaProductos.Add(value);
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            listaProductos.RemoveAll(p => p.Id == id);
            int Idx = NotificacionController.listaNotificaciones.Count() + 1;
            NotificacionController.listaNotificaciones.Add( new NotificacionEntity() { Id = Idx, Tipo = "ELIMINACION", Descripcion = "Se elimina el registro[" + id + "]",  } );
        }
    }
}
