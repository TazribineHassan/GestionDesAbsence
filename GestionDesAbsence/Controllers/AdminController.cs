using GestionDesAbsence.Common;
using GestionDesAbsence.Models;
using GestionDesAbsence.ServicesImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDesAbsence.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult AllFilieres()
        {
            return View();
        }

        public ActionResult AjouterClasse()
        {
            return View();
        }

        public ActionResult ExcelPage()
        {
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
            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();
            ViewBag.valN = "";
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

    }
}