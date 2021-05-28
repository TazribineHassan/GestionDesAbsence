using GestionDesAbsence;
using GestionDesAbsence.Common;
using GestionDesAbsence.Models;
using GestionDesAbsence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDesAbsence.Controllers
{
    public class ProfesseurController : Controller
    {
        IProfesseurService professeurService;

        public ProfesseurController(IProfesseurService professeurService)
        {
            this.professeurService = professeurService;
        }

        [Authorize(Roles = "professeeur")]
        public ActionResult Index(string nom)
        {
            /*GestionDesAbsenceContext context = new GestionDesAbsenceContext();

            context.Roles.Add(new Role() { Nome = "admin" });
            context.Roles.Add(new Role() { Nome = "professeeur" });
            context.Roles.Add(new Role() { Nome = "etudiant" });
            context.SaveChanges();*/

            /*            professeurService.Save(new Professeur()
                        {
                            Id = 0,
                            Code_prof = "UYGGHJ09UU9007",
                            Nom = "OUARRACHI",
                            Prenom = "Maryem",
                            Email = "maryem@gmail.com",
                            Password = Encryption.Encrypt("professeur"),
                            Role_Id = 2
                        });*/
            ViewBag.nom = nom;
            return View();
        }


    }
}