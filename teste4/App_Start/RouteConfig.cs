using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace teste4
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            
            routes.MapRoute(
                name: "CRUD.Index",
                url: "",
                defaults: new { controller = "CRUD", action = "Index"}
            );
            routes.MapRoute(
                name: "CRUD.Adicionar",
                url: "crud/add",
                defaults: new { controller = "CRUD", action = "Adicionar" }
            );
            routes.MapRoute(
                name: "CRUD.Editar",
                url: "crud/edit/{id}",
                defaults: new { controller = "CRUD", action = "Editar" }
            );
            routes.MapRoute(
                name: "CRUD.Excluir",
                url: "crud/excluir/{id}",
                defaults: new { controller = "CRUD", action = "Excluir" }
            );
            
            routes.MapRoute(
                name: "Default",
                url: "Home",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
