# ApiRoblox

API REST desarrollada con ASP.NET Web API y Entity Framework para gestionar jugadores y experiencias de Roblox. Permite registrar, consultar, actualizar y eliminar información, almacenándola en SQL Server LocalDB y ofreciendo respuestas en JSON o XML.

## Tecnologías

- C# y .NET Framework 4.8.
- ASP.NET Web API 2.
- Entity Framework 6 (Code First).
- SQL Server LocalDB.

## Ejecutar el proyecto

1. Instala Visual Studio con la carga de trabajo **ASP.NET y desarrollo web**, el paquete de destino de **.NET Framework 4.8** y **SQL Server Express LocalDB**.
2. Abre `ApiRoblox.slnx`. Si tu versión de Visual Studio no admite ese formato, abre `ApiRoblox/ApiRoblox.csproj`.
3. Restaura los paquetes NuGet desde Visual Studio antes de compilar.
4. Revisa la conexión `RobloxConnection` en `ApiRoblox/Web.config`. Actualmente utiliza la instancia `(localdb)\RobloxLocal` y la base `RobloxDB`. Si tu instancia es la predeterminada, cambia únicamente el servidor a `(localdb)\MSSQLLocalDB`.
5. Ejecuta con **F5** y visita `/api/jugadores` o `/api/experiencias` en el puerto que muestre Visual Studio. La dirección HTTPS configurada en el proyecto es `https://localhost:44300`.

Entity Framework crea la base de datos en la primera consulta. Las listas estarán vacías hasta que registres datos con una solicitud POST.

## Recursos

- **Jugadores:** `JugadorId`, `Nombre` y `Edad`.
- **Experiencias:** `ExperienciaId`, `Nombre` y `Genero`.

En las siguientes rutas, reemplaza `{recurso}` por `jugadores` o `experiencias` y `{id}` por un identificador existente.

| Método | Ruta | Operación |
| --- | --- | --- |
| GET | `/api/{recurso}` | Listar registros |
| GET | `/api/{recurso}/{id}` | Consultar un registro |
| POST | `/api/{recurso}` | Crear un registro |
| PUT | `/api/{recurso}/{id}` | Actualizar un registro |
| DELETE | `/api/{recurso}/{id}` | Eliminar un registro |

## Crear un jugador

Con la API en ejecución, envía esta solicitud desde Postman u otro cliente HTTP:

```http
POST https://localhost:44300/api/jugadores
Content-Type: application/json
Accept: application/json

{
  "Nombre": "NoobMaster",
  "Edad": 12
}
```

La respuesta esperada es **201 Created**, con el jugador y su `JugadorId` generado. Después puedes consultar los registros con `GET /api/jugadores`.

Para crear una experiencia, usa `POST /api/experiencias` con un cuerpo como este:

```json
{
  "Nombre": "Obby Arcoíris",
  "Genero": "Obby"
}
```

El encabezado `Accept` permite solicitar la respuesta en `application/json` o `application/xml`; `Content-Type` indica el formato del cuerpo que envías.
