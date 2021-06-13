using GestionDesAbsence.Common;
using GestionDesAbsence.Models;
using GestionDesAbsence.Services;
using GestionDesAbsence.ServicesImpl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GestionDesAbsence.Controllers
{

        //[Authorize(Roles = "etudiant")]
        public class EtudiantController : Controller
        {
            IEtudiantService etudiantService;

            public EtudiantController()
            {
            this.etudiantService = new EtudiantService();
            }

        // GET: Etudiant
        public ActionResult Index()
        {

            var listOfAbsence = etudiantService.GetAbsence(GetEtudiantIdFromCockie());

            return View(listOfAbsence);
        }

        private int GetEtudiantIdFromCockie()
        {
            HttpCookie coockie = Request.Cookies[FormsAuthentication.FormsCookieName];
            string crypted_ticket = coockie.Value;
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(crypted_ticket);
            string email = ticket.Name;
            return etudiantService.GetEtudiantByEmail(email).Id;
        }
    }
    }
