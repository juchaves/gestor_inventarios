using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestor_inventarios.Models
{
    /// <summary>
    /// Clase que representa la informacion que se maneja en el inventario
    /// </summary>
    public class ProductoEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public string Tipo { get; set; }
        public bool Expirado { get; set; }
    }
}
