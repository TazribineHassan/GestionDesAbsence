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
    [Authorize(Roles = "professeur")]
    public class ProfesseurController : Controller
    {
        IProfesseurService professeurService;

        public ProfesseurController(IProfesseurService professeurService)
        {
            this.professeurService = professeurService;
        }

        [Authorize(Roles = "professeur")]
        public ActionResult Index()
        {
            return View();
        }

        public String testData()
        {
            using (GestionDesAbsenceContext db = new GestionDesAbsenceContext())
            {
                
                 // La table de l'admin
                 var admin = new Administrateur() { Email = "admin@gmail.com", Nom = "Admin", Prenom = "admin", Password = Encryption.Encrypt("admin") };
                 db.Administrateurs.Add(admin);
                    db.SaveChanges();

                 // La table de cyccle
                 var cycles = new List<Cycle>();
                 cycles.Add(new Cycle() { Id = 0, Nom = "CP" });
                 cycles.Add(new Cycle() { Id = 0, Nom = "CI" });
                 db.Cycles.AddRange(cycles);
                 db.SaveChanges();

                 // La table de classe
                 var classes = new List<Classe>();
                 classes.Add(new Classe() { Id = 0, Nom = "4 GINFO", id_cycle = 2 });
                 classes.Add(new Classe() { Id = 0, Nom = "3 GTR", id_cycle = 2 });
                 classes.Add(new Classe() { Id = 0, Nom = "CP 1", id_cycle = 1 });
                 db.Classes.AddRange(classes);
                 db.SaveChanges();

                // La table de groupe
                var groupes = new List<Groupe>();
                groupes.Add(new Groupe() { Id = 0, Nom = "Groupe 1", id_classe = 1 });
                groupes.Add(new Groupe() { Id = 0, Nom = "Groupe 2", id_classe = 2 });
                groupes.Add(new Groupe() { Id = 0, Nom = "Groupe 3", id_classe = 2 });
                db.Groupes.AddRange(groupes);
                db.SaveChanges();

                // La table de l'etudiant
                var etudiants = new List<Etudiant>();
                for(int i = 0; i < 100; i++)
                    etudiants.Add(new Etudiant() { Id = 0, Cne = "D132468" + i , Nom = "TAZRIBINE" + i + "", Prenom = "Hassan" + i + "", Email = "hassan" + i +"@gmail.com", Password = Encryption.Encrypt("etudiant"), Id_groupe = 1 });
                db.Etudiants.AddRange(etudiants);
                db.SaveChanges();

                // la table des profs
                var professeurs = new List<Professeur>();
                professeurs.Add(new Professeur() { Id = 0, Code_prof = "UYGGHJ09UU9007", Nom = "OUARRACHI", Prenom = "Maryem", Email = "maryem@gmail.com", Password = Encryption.Encrypt("professeur"), Role_Id = 2 });
                professeurs.Add(new Professeur() { Id = 0, Code_prof = "UYGGHJ09UU9007", Nom = "PROF 1", Prenom = "prof", Email = "prof@gmail.com", Password = Encryption.Encrypt("professeur"), Role_Id = 2 });
                professeurs.Add(new Professeur() { Id = 0, Code_prof = "UYGGHJ09UU9007", Nom = "PROF 2", Prenom = "prof", Email = "prof@gmail.com", Password = Encryption.Encrypt("professeur"), Role_Id = 2 });
                db.Professeurs.AddRange(professeurs);
                db.SaveChanges();

                // la table des modules
                var modules = new List<Module>();
                modules.Add(new Module() { Id = 0, NomModule = "C#", id_Professeur = 1 });
                modules.Add(new Module() { Id = 0, NomModule = "Module x", id_Professeur = 2 });
                modules.Add(new Module() { Id = 0, NomModule = "Module y", id_Professeur = 3 });
                db.Modules.AddRange(modules);
                db.SaveChanges();


            }
            return "well done";
        }


        public ActionResult Notez()
        {
            GestionDesAbsenceContext context = new GestionDesAbsenceContext();

            return View(context.Etudiants.ToList());
        }

        [HttpPost]
        public string Marquez(int ID)
        {

            return "done" + ID;
        }
    }
}