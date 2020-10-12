using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestor_inventarios.Models
{
    /// <summary>
    /// Clase que representa la informacion de una notificacion
    /// </summary>
    public class NotificacionEntity
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
    }
}
