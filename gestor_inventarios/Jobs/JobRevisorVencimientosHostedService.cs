using gestor_inventarios.Controllers;
using gestor_inventarios.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace gestor_inventarios.Jobs
{
    internal class JobRevisorVencimientosHostedService : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;
        private readonly int JobIntervalInSecs = 30;

        public JobRevisorVencimientosHostedService(ILogger<JobRevisorVencimientosHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is starting.");
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(JobIntervalInSecs));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _logger.LogInformation("Timed Background Service is working.");
            List<ProductoEntity> productosExpirados = ProductoController.listaProductos.FindAll(p => !p.Expirado && p.FechaCaducidad <= System.DateTime.Now);
            productosExpirados.ForEach(p => p.Expirado = true);
            int iAux = NotificacionController.listaNotificaciones.Count;
            productosExpirados.ForEach(p => NotificacionController.listaNotificaciones.Add(new NotificacionEntity() { Id = iAux++, Fecha = System.DateTime.Now, Tipo = "EXPIRACION", Descripcion = "Expira el producto [" + p.Id + "]" }));
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is stopping.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
