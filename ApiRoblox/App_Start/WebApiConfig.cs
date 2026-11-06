using System.Net.Http.Headers;
using System.Web.Http;

namespace ApiRoblox
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Formato JSON
            config.Formatters.JsonFormatter.SupportedMediaTypes
                  .Add(new MediaTypeHeaderValue("application/json"));

            // Formato XML
            config.Formatters.XmlFormatter.SupportedMediaTypes
                  .Add(new MediaTypeHeaderValue("application/xml"));

            // Permite enviar XML simple, sin espacios de nombres (ver nota)
            config.Formatters.XmlFormatter.UseXmlSerializer = true;
        }
    }
}