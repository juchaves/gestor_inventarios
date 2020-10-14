using gestor_inventarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interfaz_usuario_inventario.Servicios
{
    public interface INotificacionService
    {
        Task<List<NotificacionEntity>> GetNotificacionesAsync();
        Task<NotificacionEntity> GetNotificacionAsync(int id);
        Task<NotificacionEntity> CreateNotificacionAsync(NotificacionEntity p);
        Task<NotificacionEntity> UpdateNotificacionAsync(NotificacionEntity p);
        Task DeleteNotificacionAsync(int id);
    }
}
