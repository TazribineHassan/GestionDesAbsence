using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GestionDesAbsence
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            
               routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Admindetails",
                url: "{controller}/Delete/{id}",
                defaults: new { controller = "Admin", action = "DeleteEtudiant", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Admin",
                url: "{controller}/etudiantDetails/{id}",
                defaults: new { controller = "Admin", action = "etudiantDetails", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}
