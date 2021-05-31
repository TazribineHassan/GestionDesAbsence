﻿using GestionDesAbsence.Common;
using GestionDesAbsence.Models;
using GestionDesAbsence.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GestionDesAbsence.Controllers
{
    [Authorize(Roles = "professeur")]
    public class ProfesseurController : Controller
    {
        IProfesseurService professeurService;

        public ProfesseurController(IProfesseurService professeurService)
        {
            this.professeurService = professeurService;
        }

        public ActionResult Index()
        {
            
            var listOfSeance = professeurService.GetSeancesForProf(1, 1);


            return View(listOfSeance);
        }

        public string testData()
        {
            //using (GestionDesAbsenceContext db = new GestionDesAbsenceContext())
            //{

            //    // // La table de l'admin
            //    var admin = new Administrateur() { Email = "admin@gmail.com", Nom = "Admin", Prenom = "admin", Password = Encryption.Encrypt("admin"), Role_Id = 1 };
            //    db.Administrateurs.Add(admin);
            //    db.SaveChanges();

            //    // // La table de cycle
            //    var cycles = new List<Cycle>();
            //    cycles.Add(new Cycle() { Id = 0, Nom = "CP" });
            //    cycles.Add(new Cycle() { Id = 0, Nom = "CI" });
            //    db.Cycles.AddRange(cycles);
            //    db.SaveChanges();

            //    // // La table de classe
            //    var classes = new List<Classe>();
            //    classes.Add(new Classe() { Id = 0, Nom = "4 GINFO", id_cycle = 2 });
            //    classes.Add(new Classe() { Id = 0, Nom = "3 GTR", id_cycle = 2 });
            //    classes.Add(new Classe() { Id = 0, Nom = "CP 1", id_cycle = 1 });
            //    db.Classes.AddRange(classes);
            //    db.SaveChanges();

            //    // La table de groupe
            //    var groupes = new List<Groupe>();
            //    groupes.Add(new Groupe() { Id = 0, Nom = "Groupe 1" });
            //    groupes.Add(new Groupe() { Id = 0, Nom = "Groupe 2" });
            //    groupes.Add(new Groupe() { Id = 0, Nom = "Groupe 3" });
            //    db.Groupes.AddRange(groupes);
            //    db.SaveChanges();

            //    // La table de l'etudiant
            //    var etudiants = new List<Etudiant>();
            //    for (int i = 0; i < 100; i++)
            //        if (i < 50)
            //        {
            //            etudiants.Add(new Etudiant() { Id = 0, Cne = "D132468" + i, Nom = "TAZRIBINE" + i + "", Prenom = "Hassan" + i + "", Email = "hassan" + i + "@gmail.com", Password = Encryption.Encrypt("etudiant"), Id_groupe = 1, Id_classe = 1, Role_Id = 3 });
            //        }
            //        else
            //        {
            //            etudiants.Add(new Etudiant() { Id = 0, Cne = "D132468" + i, Nom = "TAZRIBINE" + i + "", Prenom = "Hassan" + i + "", Email = "hassan" + i + "@gmail.com", Password = Encryption.Encrypt("etudiant"), Id_groupe = 2, Id_classe = 1, Role_Id = 3 });
            //        }

            //    db.Etudiants.AddRange(etudiants);
            //    db.SaveChanges();

            //    // La table des profs
            //    var professeurs = new List<Professeur>();
            //    professeurs.Add(new Professeur() { Id = 0, Code_prof = "UYGGHJ09UU9007", Nom = "OUARRACHI", Prenom = "Maryem", Email = "maryem@gmail.com", Password = Encryption.Encrypt("professeur"), Role_Id = 2 });
            //    professeurs.Add(new Professeur() { Id = 0, Code_prof = "UYGGHJ09UU9007", Nom = "PROF 1", Prenom = "prof", Email = "prof@gmail.com", Password = Encryption.Encrypt("professeur"), Role_Id = 2 });
            //    professeurs.Add(new Professeur() { Id = 0, Code_prof = "UYGGHJ09UU9007", Nom = "PROF 2", Prenom = "prof", Email = "prof@gmail.com", Password = Encryption.Encrypt("professeur"), Role_Id = 2 });
            //    db.Professeurs.AddRange(professeurs);
            //    db.SaveChanges();

            //    // La table des modules
            //    var modules = new List<Module>();
            //    modules.Add(new Module() { Id = 0, NomModule = "C#", id_Professeur = 1 });

            //    modules.Add(new Module() { Id = 0, NomModule = "Module x", id_Professeur = 2 });

            //    modules.Add(new Module() { Id = 0, NomModule = "Module y", id_Professeur = 3 });

            //    db.Modules.AddRange(modules);
            //    db.SaveChanges();

            //    //attach modules to classes
            //    //attach model to class 1
            //    db.Modules.Find(1).Classes.Add(db.Classes.Find(1));
            //    // attach model to class 1
            //    db.Modules.Find(2).Classes.Add(db.Classes.Find(1));
            //    //attach model to class 2
            //    db.Modules.Find(3).Classes.Add(db.Classes.Find(2));
            //    db.SaveChanges();

            //    // La table des locals
            //    var locals = new List<Local>();
            //    locals.Add(new Local() { Id = 0, nom = "Salle 1" });
            //    locals.Add(new Local() { Id = 0, nom = "Salle 2" });
            //    locals.Add(new Local() { Id = 0, nom = "Salle 3" });
            //    db.Locals.AddRange(locals);
            //    db.SaveChanges();

            //    // La table des seances
            //    string[] jours = { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche" };
            //    var seances = new List<Seance>();
            //    for (int i = 0; i < 7; i++)
            //    {
            //        seances.Add(new Seance() { Jour = jours[i], Heure_debut = "08:00", Heure_fin = "10:00" });
            //        seances.Add(new Seance() { Jour = jours[i], Heure_debut = "10:00", Heure_fin = "12:00" });
            //        seances.Add(new Seance() { Jour = jours[i], Heure_debut = "12:00", Heure_fin = "14:00" });
            //        seances.Add(new Seance() { Jour = jours[i], Heure_debut = "14:00", Heure_fin = "16:00" });
            //        seances.Add(new Seance() { Jour = jours[i], Heure_debut = "16:00", Heure_fin = "18:00" });
            //    }
            //    db.Seances.AddRange(seances);
            //    db.SaveChanges();

            //    // La tables des semaines
            //    var semaines = new List<Semaine>();
            //    semaines.Add(new Semaine() { id = 0, Code = "S1", Date_debut = DateTime.Parse("05/01/2021"), Date_fin = DateTime.Parse("05/07/2021") });
            //    semaines.Add(new Semaine() { id = 0, Code = "S1", Date_debut = DateTime.Parse("05/08/2021"), Date_fin = DateTime.Parse("05/14/2021") });
            //    semaines.Add(new Semaine() { id = 0, Code = "S1", Date_debut = DateTime.Parse("05/15/2021"), Date_fin = DateTime.Parse("05/21/2021") });
            //    db.Semaines.AddRange(semaines);
            //    db.SaveChanges();

            //    // La table des emplois
            //    db.Emplois.Add(new Emploi() { Id = 1});
            //    db.SaveChanges();

            //    // La table des details d'un emploi
            //    var details = new List<Details_Emploi>();
            //    details.Add(new Details_Emploi() { Id = 0, Emploi_Id = 1, Local_Id = 2, Module_Id = 1, Seance_Id = 1});
            //    details.Add(new Details_Emploi() { Id = 0, Emploi_Id = 1, Local_Id = 1, Module_Id = 2, Seance_Id = 2 });
            //    details.Add(new Details_Emploi() { Id = 0, Emploi_Id = 1, Local_Id = 3, Module_Id = 2, Seance_Id = 4 });
            //    details.Add(new Details_Emploi() { Id = 0, Emploi_Id = 1, Local_Id = 2, Module_Id = 1, Seance_Id = 5 });
            //    details.Add(new Details_Emploi() { Id = 0, Emploi_Id = 1, Local_Id = 2, Module_Id = 3, Seance_Id = 6 });
            //    details.Add(new Details_Emploi() { Id = 0, Emploi_Id = 1, Local_Id = 1, Module_Id = 2, Seance_Id = 1 });
            //    details.Add(new Details_Emploi() { Id = 0, Emploi_Id = 1, Local_Id = 3, Module_Id = 1, Seance_Id = 1 });
            //    db.details_Emplois.AddRange(details);
            //    db.SaveChanges();


            //}
            return "well done";
        }


        public ActionResult Notez()
        {
            GestionDesAbsenceContext context = new GestionDesAbsenceContext();
            var listOfSeance = new List<object>();            
           
            return View(context.Etudiants.ToList());
        }

        [HttpPost]
        public ActionResult Marquez(int id, bool presence)
        {

            return RedirectToAction("Notez");   
        }

        public object LogicTest()
        {
            // get current professeur
            HttpCookie coockie = Request.Cookies[FormsAuthentication.FormsCookieName];
            string crypted_ticket = coockie.Value;
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(crypted_ticket);
            string email = ticket.Name;
            Professeur professeur = professeurService.GetProfesseurByEmail(email);

            Semaine semaine_courante;
            using (var db = new GestionDesAbsenceContext())
            {
                semaine_courante = db.Semaines.Where(s => s.Date_debut.CompareTo(DateTime.Now) < 0).FirstOrDefault();
            }

            var result = professeurService.GetStudentsList(1, 1, 1);

            var str1 = JsonConvert.SerializeObject(result, Formatting.Indented,
                                                     new JsonSerializerSettings
                                                     {
                                                         ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                                     });

            var result2 = professeurService.GetSeancesForProf(1 , 1);
            var str2 = JsonConvert.SerializeObject(result2, Formatting.Indented,
                                                    new JsonSerializerSettings
                                                    {
                                                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                                    });

            return str1;
        }
    }
}