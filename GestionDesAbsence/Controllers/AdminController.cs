using GestionDesAbsence.Common;
using GestionDesAbsence.Models;
using GestionDesAbsence.ServicesImpl;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GestionDesAbsence.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Cookie")) {
                String s = this.ControllerContext.HttpContext.Request.Cookies["AdminName"].Value;
                ViewBag.adminName = s;
            }
            
            return View();
        }


        public ActionResult Home()
        {
<<<<<<< HEAD
            /*using (GestionDesAbsenceContext db = new GestionDesAbsenceContext())
            {

                // // La table de l'admin
                var admin = new Administrateur() { Email = "admin@gmail.com", Nom = "Admin", Prenom = "admin", Password = Encryption.Encrypt("admin"), Role_Id = 1 };
                db.Administrateurs.Add(admin);
                db.SaveChanges();

                // // La table de cycle
                var cycles = new List<Cycle>();
                cycles.Add(new Cycle() { Id = 0, Nom = "CP" });
                cycles.Add(new Cycle() { Id = 0, Nom = "CI" });
                db.Cycles.AddRange(cycles);
                db.SaveChanges();

                // // La table de classe
                var classes = new List<Classe>();
                classes.Add(new Classe() { Id = 0, Nom = "4 GINFO", id_cycle = 2 });
                classes.Add(new Classe() { Id = 0, Nom = "3 GTR", id_cycle = 2 });
                classes.Add(new Classe() { Id = 0, Nom = "CP 1", id_cycle = 1 });
                db.Classes.AddRange(classes);
                db.SaveChanges();

                // La table de groupe
                var groupes = new List<Groupe>();
                groupes.Add(new Groupe() { Id = 0, Nom = "Groupe 1" });
                groupes.Add(new Groupe() { Id = 0, Nom = "Groupe 2" });
                groupes.Add(new Groupe() { Id = 0, Nom = "Groupe 3" });
                db.Groupes.AddRange(groupes);
                db.SaveChanges();

                // La table de l'etudiant
                var etudiants = new List<Etudiant>();
                for (int i = 0; i < 100; i++)
                    if (i < 50)
                    {
                        etudiants.Add(new Etudiant() { Id = 0, Cne = "D132468" + i, Nom = "TAZRIBINE" + i + "", Prenom = "Hassan" + i + "", Email = "hassan" + i + "@gmail.com", Password = Encryption.Encrypt("etudiant"), Id_groupe = 1, Id_classe = 1, Role_Id = 3 });
                    }
                    else
                    {
                        etudiants.Add(new Etudiant() { Id = 0, Cne = "D132468" + i, Nom = "TAZRIBINE" + i + "", Prenom = "Hassan" + i + "", Email = "hassan" + i + "@gmail.com", Password = Encryption.Encrypt("etudiant"), Id_groupe = 2, Id_classe = 2, Role_Id = 3 });
                    }

                db.Etudiants.AddRange(etudiants);
                db.SaveChanges();

                // La table des profs
                var professeurs = new List<Professeur>();
                professeurs.Add(new Professeur() { Id = 0, Code_prof = "UYGGHJ09UU9007", Nom = "OUARRACHI", Prenom = "Maryem", Email = "maryem@gmail.com", Password = Encryption.Encrypt("professeur"), Role_Id = 2 });
                professeurs.Add(new Professeur() { Id = 0, Code_prof = "UYGGHJ09UU9007", Nom = "PROF 1", Prenom = "prof", Email = "prof@gmail.com", Password = Encryption.Encrypt("professeur"), Role_Id = 2 });
                professeurs.Add(new Professeur() { Id = 0, Code_prof = "UYGGHJ09UU9007", Nom = "PROF 2", Prenom = "prof", Email = "prof@gmail.com", Password = Encryption.Encrypt("professeur"), Role_Id = 2 });
                db.Professeurs.AddRange(professeurs);
                db.SaveChanges();

                // La table des modules
                var modules = new List<Module>();
                modules.Add(new Module() { Id = 0, NomModule = "C#", id_Professeur = 1 });

                modules.Add(new Module() { Id = 0, NomModule = "Module x", id_Professeur = 2 });

                modules.Add(new Module() { Id = 0, NomModule = "Java", id_Professeur = 3});

                db.Modules.AddRange(modules);
                db.SaveChanges();

                //attach modules to classes
                //attach model to class 1
                db.Modules.Find(3).Classes.Add(db.Classes.Find(1));
                // attach model to class 1
                db.Modules.Find(3).Classes.Add(db.Classes.Find(1));
                //attach model to class 2
                db.Modules.Find(3).Classes.Add(db.Classes.Find(2));
                db.SaveChanges();

                // La table des locals
                var locals = new List<Local>();
                locals.Add(new Local() { Id = 0, nom = "Salle 1" });
                locals.Add(new Local() { Id = 0, nom = "Salle 2" });
                locals.Add(new Local() { Id = 0, nom = "Salle 3" });
                db.Locals.AddRange(locals);
                db.SaveChanges();

                // La table des seances
                string[] jours = { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche" };
                var seances = new List<Seance>();
                for (int i = 0; i < 7; i++)
                {
                    seances.Add(new Seance() { Jour = jours[i], Heure_debut = "08:00", Heure_fin = "10:00" });
                    seances.Add(new Seance() { Jour = jours[i], Heure_debut = "10:00", Heure_fin = "12:00" });
                    seances.Add(new Seance() { Jour = jours[i], Heure_debut = "12:00", Heure_fin = "14:00" });
                    seances.Add(new Seance() { Jour = jours[i], Heure_debut = "14:00", Heure_fin = "16:00" });
                    seances.Add(new Seance() { Jour = jours[i], Heure_debut = "16:00", Heure_fin = "18:00" });
                }
                db.Seances.AddRange(seances);
                db.SaveChanges();

                // La tables des semaines
                var semaines = new List<Semaine>();
                semaines.Add(new Semaine() { id = 0, Code = "S1", Date_debut = DateTime.Parse("01/05/2021"), Date_fin = DateTime.Parse("07/05/2021") });
                semaines.Add(new Semaine() { id = 0, Code = "S1", Date_debut = DateTime.Parse("08/05/2021"), Date_fin = DateTime.Parse("14/05/2021") });
                semaines.Add(new Semaine() { id = 0, Code = "S1", Date_debut = DateTime.Parse("15/05/2021"), Date_fin = DateTime.Parse("21/05/2021") });
                db.Semaines.AddRange(semaines);
                db.SaveChanges();

                // La table des emplois
                db.Emplois.Add(new Emploi() { Id = 1 });
                db.SaveChanges();

                // La table des details d'un emploi
                var details = new List<Details_Emploi>();
                details.Add(new Details_Emploi() { Id = 0, Emploi_Id = 1, Local_Id = 2, Module_Id = 1, Seance_Id = 1 });
                details.Add(new Details_Emploi() { Id = 0, Emploi_Id = 1, Local_Id = 1, Module_Id = 3, Seance_Id = 2 });
                details.Add(new Details_Emploi() { Id = 0, Emploi_Id = 1, Local_Id = 3, Module_Id = 2, Seance_Id = 4 });
                details.Add(new Details_Emploi() { Id = 0, Emploi_Id = 1, Local_Id = 2, Module_Id = 1, Seance_Id = 5 });
                details.Add(new Details_Emploi() { Id = 0, Emploi_Id = 1, Local_Id = 2, Module_Id = 2, Seance_Id = 6 });
                details.Add(new Details_Emploi() { Id = 0, Emploi_Id = 1, Local_Id = 1, Module_Id = 2, Seance_Id = 7 });
                details.Add(new Details_Emploi() { Id = 0, Emploi_Id = 1, Local_Id = 3, Module_Id = 1, Seance_Id = 8 });
                db.details_Emplois.AddRange(details);
                db.SaveChanges();
                

            }*/
=======
>>>>>>> 9c9932426e298468380b069a0834213217917813
            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();
            gestion.Configuration.ProxyCreationEnabled = false;
            var classe = gestion.details_Emplois.Where(p => p.Module_Id == 1);

            List<Seance> seances = new List<Seance>();

            foreach (var p in classe)
            {
                seances.Add(gestion.Seances.Find(p.Seance_Id));
            }
<<<<<<< HEAD
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Cookie"))
            {
                String s = this.ControllerContext.HttpContext.Request.Cookies["AdminName"].Value;
                ViewBag.adminName = s;
            }
=======

            ViewBag.e = seances.Count();

>>>>>>> 9c9932426e298468380b069a0834213217917813
            return View(seances);
        }

        public ActionResult AllFilieres()
        {
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Cookie"))
            {
                String s = this.ControllerContext.HttpContext.Request.Cookies["AdminName"].Value;
                ViewBag.adminName = s;
            }
            return View();
        }

        public ActionResult AjouterClasse()
        {
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Cookie"))
            {
                String s = this.ControllerContext.HttpContext.Request.Cookies["AdminName"].Value;
                ViewBag.adminName = s;
            }
            return View();
        }

        public ActionResult ExcelPage()
        {
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Cookie"))
            {
                String s = this.ControllerContext.HttpContext.Request.Cookies["AdminName"].Value;
                ViewBag.adminName = s;
            }
            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();
            ViewBag.list = new SelectList(gestion.Cycles, "Id", "Nom");

            return View();
        }
        public JsonResult GetClass(int id)
        {
            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();
            gestion.Configuration.ProxyCreationEnabled = false;
            var classe = gestion.Classes.Where(p => p.id_cycle == id);

            return Json(classe, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AllEtudiants()
        {
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Cookie"))
            {
                String s = this.ControllerContext.HttpContext.Request.Cookies["AdminName"].Value;
                ViewBag.adminName = s;
            }
            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();
            ViewBag.list = new SelectList(gestion.Cycles, "Id", "Nom");
            return View(gestion.Etudiants.ToList());
        }

        //SaveStudent
        [HttpPost]
        public ActionResult SaveEtudiant(string cne, string nom, String prenom,string email,string cycle, int classe,int groupe) 
        {
            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();
            Etudiant e = new Etudiant();
            e.Cne = cne;
            e.Nom = nom;
            e.Prenom = prenom;
            e.Email = email;
            e.Id_groupe = groupe;
            e.Id_classe = classe;
            e.Password = Encryption.Encrypt(cne);
            AdminService service = new AdminService();
            service.saveEtudiant(e);
            ViewBag.list = new SelectList(gestion.Cycles, "Id", "Nom");
             return Redirect("/Admin/AllEtudiants");
        }
        
        //delete Student
        public ActionResult DeleteEtudiant(int id)
        {
            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();
            Etudiant e = gestion.Etudiants.Find(id);
            AdminService service = new AdminService();
            service.deleteEtudiant(e);
            return Redirect("/Admin/AllEtudiants");
        }


        //details student
        public PartialViewResult etudiantDetails(int id)
        {
            //String s = this.ControllerContext.HttpContext.Request.Cookies["AdminName"].Value;
            //ViewBag.adminName = s;
            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();
            Etudiant e = gestion.Etudiants.Find(id);
            return PartialView(e);
        }

        public PartialViewResult etudiantEdit(int id)
        {
            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();
            ViewBag.e = id;
            ViewBag.valN = "";
            ViewBag.list = new SelectList(gestion.Cycles, "Id", "Nom");
            Etudiant e = gestion.Etudiants.Find(id);
            return PartialView(e);
        }

        //edit student
        [HttpPost]
        public ActionResult EditEtudiant(int editidinput, string editcne, string editnom, String editprenom, string editemail, string editcycle, int editclasse, int editgroupe)
        {
            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();
            Etudiant newE = gestion.Etudiants.Find(editidinput);
            newE.Cne = editcne;
            newE.Nom = editnom;
            newE.Prenom = editprenom;
            newE.Email = editemail;
            newE.Id_groupe = editgroupe;
            newE.Id_classe = editclasse;
            gestion.SaveChanges();
            ViewBag.list = new SelectList(gestion.Cycles, "Id", "Nom");
            return Redirect("/Admin/AllEtudiants");
        }

        //Prof
        public ActionResult AllProfs()
        {
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Cookie"))
            {
                String s = this.ControllerContext.HttpContext.Request.Cookies["AdminName"].Value;
                ViewBag.adminName = s;
            }
            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();
            return View(gestion.Professeurs.ToList());
        }

        //saveProf
        //SaveStudent
        [HttpPost]
        public ActionResult SaveProf(string code, string nom, String prenom, string email)
        {

            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();
            Professeur e = new Professeur();
            e.Code_prof = code;
            e.Nom = nom;
            e.Prenom = prenom;
            e.Email = email;
            e.Password = Encryption.Encrypt(email);
            ProfesseurService service = new ProfesseurService();
            service.Save(e);
            return Redirect("/Admin/AllProfs");
        }

        //Prof details PartialVies
        public PartialViewResult ProfDetails(int id)
        {
            //String s = this.ControllerContext.HttpContext.Request.Cookies["AdminName"].Value;
            //ViewBag.adminName = s;
            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();
            Professeur e = gestion.Professeurs.Find(id);
            return PartialView(e);
        }

        //delete Prof
        public ActionResult DeleteProf(int id)
        {
            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();
            Professeur e = gestion.Professeurs.Find(id);
            ProfesseurService service = new ProfesseurService();
            service.deleteProfesseur(e);
            return Redirect("/Admin/AllProfs");
        }

        //editProf partialview

        public PartialViewResult ProfEdit(int id)
        {
            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();
            ViewBag.e = id;
            Professeur p = gestion.Professeurs.Find(id);
            return PartialView(p);
        }

        //editProf (Modify)

        public ActionResult ModifyProf(int editidinput, string editcode, string editnom, String editprenom, string editemail, string editcycle)
        {
            

            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();
            Professeur newE = gestion.Professeurs.Find(editidinput);
            newE.Code_prof = editcode;
            newE.Nom = editnom;
            newE.Prenom = editprenom;
            newE.Email = editemail;

            gestion.SaveChanges();
            ViewBag.list = new SelectList(gestion.Cycles, "Id", "Nom");
            return Redirect("/Admin/AllPrfos");
        }


        GestionDesAbsenceContext db = new GestionDesAbsenceContext();

        [ActionName("Index")]
        [HttpPost]
        public ActionResult import(int myclass)
        {
            HttpPostedFileBase file = Request.Files["file"];
            if (file == null || file.ContentLength <= 0)
            {
                return Json("please select excel file", JsonRequestBehavior.AllowGet);
            }
            Stream streamfile = file.InputStream;
            DataTable dt = new DataTable();
            string FileName = Path.GetExtension(file.FileName);
            if (FileName != ".xls" && FileName != ".xlsx")
            {
                return Json("Only excel file", JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    if (FileName == ".xls")
                    {
                        HSSFWorkbook workbook = new HSSFWorkbook(streamfile);
                        dt = excel.Import(dt, workbook, db, myclass);
                    }
                    else
                    {
                        XSSFWorkbook workbook = new XSSFWorkbook(streamfile);
                        dt = excel.Import(dt, workbook, db, myclass);
                    }
                    return Json("OK", JsonRequestBehavior.AllowGet);
                }

                catch (Exception e)
                {

                    return Json(e.ToString(), JsonRequestBehavior.AllowGet);
                }
            }
            // return View();
        }


        [HttpPost]
        public ActionResult AddProfs()
        {

            HttpPostedFileBase file = Request.Files["file"];
            if (file == null || file.ContentLength <= 0)
            {
                return Json("please select excel file", JsonRequestBehavior.AllowGet);
            }
            Stream streamfile = file.InputStream;
            DataTable dt = new DataTable();
            string FileName = Path.GetExtension(file.FileName);
            if (FileName != ".xls" && FileName != ".xlsx")
            {
                return Json("Only excel file", JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    if (FileName == ".xls")
                    {
                        HSSFWorkbook workbook = new HSSFWorkbook(streamfile);
                        dt = ExcelP.Importing(dt, workbook, db);
                    }
                    else
                    {
                        XSSFWorkbook workbook = new XSSFWorkbook(streamfile);
                        dt = ExcelP.Importing(dt, workbook, db);
                    }
                    return Json("OK", JsonRequestBehavior.AllowGet);
                }

                catch (Exception e)
                {

                    return Json(e.ToString(), JsonRequestBehavior.AllowGet);
                }
            }
            // return View();

        }

        public ActionResult AjouterProfesseur()
        {
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Cookie"))
            {
                String s = this.ControllerContext.HttpContext.Request.Cookies["AdminName"].Value;
                ViewBag.adminName = s;
            }
            return View();
        }
        public ActionResult AjouterEtudiants()
        {
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Cookie"))
            {
                String s = this.ControllerContext.HttpContext.Request.Cookies["AdminName"].Value;
                ViewBag.adminName = s;
            }
            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();
            ViewBag.list = new SelectList(gestion.Cycles, "Id", "Nom");
            return View();
        }

<<<<<<< HEAD
        public ActionResult Statistiques()
        {
            int idSemaine = 1;
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Cookie"))
            {
                String s = this.ControllerContext.HttpContext.Request.Cookies["AdminName"].Value;
                ViewBag.adminName = s;
            }
            GestionDesAbsenceContext db = new GestionDesAbsenceContext();
            var result2 = db.Etudiants.Select(etudiant => new EtudiantAbsent()
            {
                nomClass = etudiant.Classe.Nom,
                id = etudiant.Id,
                nom = etudiant.Nom,
                prenom = etudiant.Prenom,
                absence_count = etudiant.Absences.Where(absence => !absence.EstPresent).Count()
            }).ToList();

            var result3 = db.Etudiants.Join(db.Absences,
                etudiant => etudiant.Id,
                absence => absence.Etudiant.Id,

                (etudiant, absence) => new EtudiantAbsent()
                {
                    nomClass = etudiant.Classe.Nom,
                    id = etudiant.Id,
                    nom = etudiant.Nom,
                    prenom = etudiant.Prenom,
                    absence_count = etudiant.Absences.Where(myabsence => !absence.EstPresent &&  myabsence.Details_Emploi.Emploi.Semaine.id == idSemaine).Count()
                }).ToList();

            return View(result3);
        }
=======
        public ActionResult CorrectAbs()
        {
            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();
            ViewBag.list = new SelectList(gestion.Professeurs, "Id", "Nom");
            ViewBag.listSemaines = new SelectList(gestion.Semaines, "Id", "Code");

            return View();
        }

        public JsonResult GetModule(int id)
        {
            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();
            gestion.Configuration.ProxyCreationEnabled = false;
            var classe = gestion.Modules.Where(p => p.id_Professeur == id);

            return Json(classe, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetSeances(int id)
        {
            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();

            var myclasse = gestion.details_Emplois.Where(p => p.Module_Id == id);

            List<int> ids = new List<int>();

            foreach (var p in myclasse)
            {

                if (gestion.Seances.Find(p.Seance_Id) != null)
                    ids.Add(gestion.Seances.Find(p.Seance_Id).id);

            }

            //ids.Add(1);
            //ids.Add(2);
            GestionDesAbsenceContext db = new GestionDesAbsenceContext();
            db.Configuration.ProxyCreationEnabled = false;
            var seances = db.Seances.Where(s => ids.Contains(s.id));

            return Json(seances, JsonRequestBehavior.AllowGet);

        }


>>>>>>> 9c9932426e298468380b069a0834213217917813
    }
}