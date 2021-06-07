using GestionDesAbsence.Common;
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

        //[Authorize(Roles = "etudiant")]
        public class EtudiantController : Controller
        {
            IEtudiantService etudiantService;

            public EtudiantController(IEtudiantService etudiantService)
            {
                this.etudiantService = etudiantService;
            }
    
        // GET: Etudiant
        public ActionResult Index()
            {
                
                return View();
            }
        }
    }
