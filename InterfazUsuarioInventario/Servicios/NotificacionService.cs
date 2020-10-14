using gestor_inventarios.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace interfaz_usuario_inventario.Servicios
{
    public class NotificacionService : INotificacionService
    {
        const string BaseUrl = "http://localhost:61471/api/notificacion";
        private readonly HttpClient _client;

        public NotificacionService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<NotificacionEntity>> GetNotificacionesAsync()
        {
            var httpResponse = await _client.GetAsync($"{BaseUrl}/");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve notificaciones");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var notificacions = JsonConvert.DeserializeObject<List<NotificacionEntity>>(content);

            return notificacions;
        }

        public async Task<NotificacionEntity> GetNotificacionAsync(int id)
        {
            var httpResponse = await _client.GetAsync($"{BaseUrl}/{id}/");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve notificacion");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var notificacion = JsonConvert.DeserializeObject<NotificacionEntity>(content);

            return notificacion;
        }

        public async Task<NotificacionEntity> CreateNotificacionAsync(NotificacionEntity notificacion)
        {
            var content = JsonConvert.SerializeObject(notificacion);
            var httpResponse = await _client.PostAsync($"{BaseUrl}/", new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot add a notificacion");
            }

            var notificacionCreado = JsonConvert.DeserializeObject<NotificacionEntity>(await httpResponse.Content.ReadAsStringAsync());
            return notificacionCreado;
        }

        public async Task<NotificacionEntity> UpdateNotificacionAsync(NotificacionEntity notificacion)
        {
            var content = JsonConvert.SerializeObject(notificacion);
            var httpResponse = await _client.PutAsync($"{BaseUrl}/{notificacion.Id}/", new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot update notificacion");
            }

            var notificacionCreado = JsonConvert.DeserializeObject<NotificacionEntity>(await httpResponse.Content.ReadAsStringAsync());
            return notificacionCreado;
        }


        public async Task DeleteNotificacionAsync(int id)
        {
            var httpResponse = await _client.DeleteAsync($"{BaseUrl}/{id}/");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot delete the notificacion");
            }
        }
    }
}
