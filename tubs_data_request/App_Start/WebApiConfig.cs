using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace tubs_data_request
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.Routes.MapHttpRoute("DefaultApiDelete", "Api/{controller}", new { action = "Delete" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Delete) });
            config.Routes.MapHttpRoute("DefaultApiPut", "Api/{controller}", new { action = "Put" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Put) });
            config.Routes.MapHttpRoute("DefaultApiPost", "Api/{controller}", new { action = "Post" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) });

            config.Routes.MapHttpRoute(
                name: "DefaultApi2",
                routeTemplate: "api/{controller}",
                defaults: new { action = "Get" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional, action = "Get" },
                constraints: new { id = @"\d+" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiForCount",
                routeTemplate: "api/{controller}/GetCount",
                defaults: new { action = "GetCount" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiSearch",
                routeTemplate: "api/{controller}/Search",
                defaults: new { action = "Search" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiWithName",
                routeTemplate: "api/{controller}/{code}",
                defaults: new { id = RouteParameter.Optional, action = "Get" }//,
                //constraints: new { id = @"\s+" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiWithActionAndId",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: null,
                constraints: new { id = @"\d+" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiWithAction",
                routeTemplate: "api/{controller}/{action}/{name}",
                defaults: null
            );     
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
