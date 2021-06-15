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
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("AdminName")) {
                String s = this.ControllerContext.HttpContext.Request.Cookies["AdminName"].Value;
                ViewBag.adminName = s;
            }

            return View();
        }


        public ActionResult Home()
        {
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("AdminName"))
            {
                String s = this.ControllerContext.HttpContext.Request.Cookies["AdminName"].Value;
                ViewBag.adminName = s;
            }
            return View();
        }

        public ActionResult AllFilieres()
        {
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("AdminName"))
            {
                String s = this.ControllerContext.HttpContext.Request.Cookies["AdminName"].Value;
                ViewBag.adminName = s;
            }
            return View();
        }

        public ActionResult AjouterClasse()
        {
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("AdminName"))
            {
                String s = this.ControllerContext.HttpContext.Request.Cookies["AdminName"].Value;
                ViewBag.adminName = s;
            }
            return View();
        }

        public ActionResult ExcelPage()
        {
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("AdminName"))
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
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("AdminName"))
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
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("AdminName"))
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
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("AdminName"))
            {
                String s = this.ControllerContext.HttpContext.Request.Cookies["AdminName"].Value;
                ViewBag.adminName = s;
            }
            return View();
        }
        public ActionResult AjouterEtudiants()
        {
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("AdminName"))
            {
                String s = this.ControllerContext.HttpContext.Request.Cookies["AdminName"].Value;
                ViewBag.adminName = s;
            }
            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();
            ViewBag.list = new SelectList(gestion.Cycles, "Id", "Nom");
            return View();
        }

        public ActionResult CorrectAbs()
        {
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("AdminName"))
            {
                String s = this.ControllerContext.HttpContext.Request.Cookies["AdminName"].Value;
                ViewBag.adminName = s;
            }
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

        public ActionResult Statistiques()
        {
            int idSemaine = 1;
            int[] tabSem = { 1, 2, 3 };
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("AdminName"))
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
                    absence_count = etudiant.Absences.Where(myabsence => !absence.EstPresent && tabSem.Contains(myabsence.Details_Emploi.Emploi.Semaine.id)).Count()
                }).ToList();

            return View(result3);
        }

        public ActionResult StatistiquesPDF()
        {
            int idSemaine = 1;
            int[] tabSem = { 1, 2, 3 };
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("AdminName"))
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

            List<EtudiantAbsent> elist = db.Etudiants.Join(db.Absences,
                etudiant => etudiant.Id,
                absence => absence.Etudiant.Id,

                (etudiant, absence) => new EtudiantAbsent()
                {
                    nomClass = etudiant.Classe.Nom,
                    id = etudiant.Id,
                    nom = etudiant.Nom,
                    prenom = etudiant.Prenom,
                    absence_count = etudiant.Absences.Where(myabsence => !absence.EstPresent && tabSem.Contains(myabsence.Details_Emploi.Emploi.Semaine.id)).Count()
                }).ToList();

            List<EtudiantAbsent> filtredList = new List<EtudiantAbsent>();

            for (int i = 0; i < elist.Count; i++)
            {
                if(elist[i].absence_count > 1)
                {
                    filtredList.Add(elist[i]);
                }
            }
            return View(filtredList);
        }

        public ActionResult GeneratePDF()
        {
            return new Rotativa.ActionAsPdf("StatistiquesPDF");
        }


    }
}