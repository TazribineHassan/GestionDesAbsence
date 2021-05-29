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
    [Authorize(Roles = "professeeur")]
    public class ProfesseurController : Controller
    {
        IProfesseurService professeurService;

        public ProfesseurController(IProfesseurService professeurService)
        {
            this.professeurService = professeurService;
        }

        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Notez()
        {
            GestionDesAbsenceContext context = new GestionDesAbsenceContext();
            return View(context.Etudiants.ToList());
        }

        [HttpPost]
        public ActionResult Marquez(int id, bool presence)
        {

            return RedirectToAction("Notez");   
        }

    }
}