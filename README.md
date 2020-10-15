# GESTOR DE INVENTARIOS

_Se trata de un manejador de inventario con interfaz a traves de servicios rest (API) implementado en C# en la plataforma .NET CORE, que puede ser utilizado de forma directa desde el aplicativo Postman (con proposito de prueba), sin embargo se ofrecen clases de prueba para que pueda validar el funcionamiento desde el entorno de desarrollo. Se ofrecen las operaciones CRUD para la entidad Producto que representa el inventario y para la entidad Notificacion que representa eventos especiales de interes sobre el inventario. En el futuro se puede ir a un repositorio de base de datos, de momento no se implementa por simplicidad. A cada entidad se le pone un campo Id, ya que es muy util para operaciones de repositorio y hace mas óptimo el manejo de entidades de datos. Las notificaciones se escriben cuando suceden los eventos que se describieron en la prueba solicitada_

No se incluyo protocolo seguro ni autenticación, estas características son propias de cada entorno de ejecución y requieren trabajo adicional que de momento no interesa abordar. El protocolo seguro por ejemplo, puede ser deseable para un servicio abierto a Internet, pero inconveniente si el servicio se ejecuta en una red privada y asegurada. No se hacen validaciones sobre los datos ni se hizo manejo de incremento de la clave de la entidad ya que son detalles que se precisan con la base de dattos y dependen de un diseño más elaborado.

## Comenzando 🚀

_Puedes descargar los fuentes en el zip del proyecto y descomprimir el contenido en una carpeta de tu maquina o hacer el correspondiente pull desde git en tu maquina al respositorio actual_

Mira **Deployment** para conocer como desplegar el proyecto. Aunque realmente se hicieron las pruebas unicamente en ambiente de desarrollo con el IIS incluido con Visual Studio por simplicidad.


### Pre-requisitos 📋

_Para validar el proyecto debes contar con el Visual Studio 2019 instalado, en el deberas abrir la solución y ejecutar el aplicativo. Tambien deberías tener instalado POSTMAN, para poder hacer pruebas simples de ejcucion directa al servicio como desarrollo principal instalado_

```
La idea es que mediante POSTMAN puedas proveer a cada operacion de servicio los datos con los que quieres probar la funcionalidad en el mismo. O puedes usar desde el entorno de visual studio la aplicacion de prueba para validar el funcionamiento.
```

### Instalación 🔧

_Dependiendo del entorno destino de despliegue el procedimiento será distinto, por simplicidad no se hace aqui profundidad en ello. Se puede ya sea crear paquete de despliegue o desplegar directamente a un contenedor._

## Ejecutando las pruebas ⚙️

_Se entregan tres proyectos en la solucion, el proyecto gestor_inventarios debe lanzarse con boton de ejecucion ya que se deja como proyecto por defecto de la solición. Una vez hecho esto, se puede pasar al POSTMAN y ejecutar la invocacion con una estructura JSON adecuada para la prueba al siguiente URL:_

http://localhost:61471/api/producto

_Los ejemplos de dato para probar la creacion de un producto es uno como el siguiente, a partir del mismo se puede variar la informacion y agregar más registros:_

POST para crear:

{
    "id": 2,
    "nombre": "Pera",
    "fechaCaducidad": "2020-10-16T22:07:00",
    "tipo": "NORMAL",
    "expirado": "NO"
}

Ejemplo de obtencion de Lista por GET:

[
    {
        "id": 1,
        "nombre": "Manzana",
        "fechaCaducidad": "2020-10-16T22:07:00",
        "tipo": "ESPECIAL",
        "expirado": "NO"
    }
]


Una vez desplegado se puede acceder al servicio consultando para ello su interfaz en el siguiente URL:
url descripcion servicio


## Despliegue 📦

_La solucion se entrega para que pueda ser validada dentro del entorno, al dar play a la solicion arranca el proyecto base que es el servicio, una vez arriba se puede arrancar el sitio en el mismo proceso con la opcion Depurar/Ir a nueva instancia sobre la carpeta del proyecto interfaz_usuario_inventario_

## Construido con 🛠️

_Menciona las herramientas que utilizaste para crear tu proyecto_

* [VisualStudio](https://visualstudio.microsoft.com/es/vs/community/) - El entorno de desarrollo
* [Postman](https://www.postman.com/) - Programa de prueba de servicios
* [git](https://git-scm.com/) - Manejador de versiones
* [materializecss](https://materializecss.com/) - Framework grafico para GUI en web

## Versionado 📌

Solo interesa la versión reciente publicada en la que se pudo satisfacer el requerimiento técnico de la prueba.

## Agradecimientos 🎁

* Espero que los que se detengan a ver el proyecto saquen algo bueno de ello y agradezco su tiempo en la revisión 📢
* Espero que la prueba sea suficientemente satisfactoria 🤓.



---

