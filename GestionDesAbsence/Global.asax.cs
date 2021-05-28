using GestionDesAbsence.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GestionDesAbsence
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //using (GestionDesAbsenceContext db = new GestionDesAbsenceContext())
            //{
            //    if (db.Roles.Count() == 0)
            //    {
            //        var adminRole = new Role() { Nome = "admin" };
            //        var professeurRole = new Role() { Nome = "professeur" };
            //        var etudiantRole = new Role() { Nome = "etudiant" };

            //        db.Roles.Add(adminRole);
            //        db.Roles.Add(professeurRole);
            //        db.Roles.Add(etudiantRole);
            //        db.SaveChanges();

            //    }
            //}

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UnityConfig.RegisterComponents();
        }
    }
}
