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

namespace GestionDesAbsence.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        /*public ActionResult Index()
        {
            return View();
        }*/

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

        public ActionResult AjouterProfesseur()
        {
            return View();
        }
        public ActionResult AjouterEtudiants()
        {
            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();
            ViewBag.list = new SelectList(gestion.Cycles, "Id", "Nom");
            return View();
        }

        public ActionResult ExcelPage()
        {
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
             return Redirect("/Admin/AllEtudiant");
        }
        
        //delete Student
        public ActionResult DeleteEtudiant(int id)
        {
            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();
            Etudiant e = gestion.Etudiants.Find(id);
            AdminService service = new AdminService();
            service.deleteEtudiant(e);
            return Redirect("/Admin/AllEtudiant");
        }

        GestionDesAbsenceContext db = new GestionDesAbsenceContext();


        [ActionName("Index")]
        [HttpPost]
        public ActionResult import( int myclass)
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
                    
                    return Json( e.ToString(), JsonRequestBehavior.AllowGet);
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




    }
}