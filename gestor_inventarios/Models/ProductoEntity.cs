using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gestor_inventarios.Models
{
    /// <summary>
    /// Clase que representa la informacion que se maneja en el inventario
    /// </summary>
    public class ProductoEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public string Tipo { get; set; }
        public string Expirado { get; set; }
    }
}
