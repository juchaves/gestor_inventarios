using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interfaz_usuario_inventario.Servicios
{
    public static class Bootstrapper
    {
        public static void UseServices( this IServiceCollection services )
        {
            services.AddHttpClient<IProductoService, ProductoService>();
            services.AddHttpClient<INotificacionService, NotificacionService>();
        }
    }
}
