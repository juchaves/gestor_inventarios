using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gestor_inventarios.Models
{
    /// <summary>
    /// Clase que representa la informacion de una notificacion
    /// </summary>
    public class NotificacionEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
    }
}
