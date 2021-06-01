using GestionDesAbsence.Models;
using GestionDesAbsence.ServicesImpl;
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
            using (GestionDesAbsenceContext db = new GestionDesAbsenceContext())
            {
                if (db.Roles.Count() == 0)
                {
                    var adminRole = new Role() { Nome = "admin" };
                    var professeurRole = new Role() { Nome = "professeur" };
                    var etudiantRole = new Role() { Nome = "etudiant" };

                    db.Roles.Add(adminRole);
                    db.Roles.Add(professeurRole);
                    db.Roles.Add(etudiantRole);
                    db.SaveChanges();

                }
                if(db.Administrateurs.Count() == 0)
                {
                    Administrateur sari = new Administrateur();
                    sari.Email = "saricool@gmail.com";
                    sari.Prenom = "sari";
                    sari.Nom = "cool";
                    sari.Role_Id = 1;
                    sari.Password = Common.Encryption.Encrypt("123456");
                    db.Administrateurs.Add(sari);
                    Administrateur admin = new Administrateur();
                    admin.Email = "admin";
                    admin.Prenom = "admin";
                    admin.Nom = "admin";
                    admin.Role_Id = 1;
                    admin.Password = Common.Encryption.Encrypt("admin");
                    db.Administrateurs.Add(admin);
                    db.SaveChanges();
                }
            }

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UnityConfig.RegisterComponents();
        }
    }
}
