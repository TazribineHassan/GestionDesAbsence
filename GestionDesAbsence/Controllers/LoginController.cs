using GestionDesAbsence.Models;
using GestionDesAbsence.Services;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GestionDesAbsence.Controllers
{
    public class LoginController : Controller
    {
        ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }


        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexMsg(string msg)
        {
            ViewBag.Msg = msg;
            return View("Index");
        }

        public ActionResult Admin()
        {
            return View();
        }        
        
        public ActionResult AdminMsg(string msg)
        {
            ViewBag.Msg = msg;
            return View("Admin");
        }




        [HttpPost]
        public ActionResult CheckAdmin(string email, string password)
        {
            Administrateur admin = loginService.Login(email, password, "admin") as Administrateur;
            if (admin != null)
            {

                //set the authentication cookie
                var ticket = new FormsAuthenticationTicket(admin.Email, true, 3000);
                string encrypt = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypt);
                HttpCookie cookieNom = new HttpCookie("AdminName");
                cookieNom.Value = admin.Nom + " "+ admin.Prenom;
                this.ControllerContext.HttpContext.Response.Cookies.
                Add(cookieNom);
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);
                cookie.HttpOnly = true;

                //ViewBag.Nom = professeur.Nom;
                return RedirectToAction("Home", "Admin");

            }
            else
            {
                return RedirectToAction("AdminMsg", new { msg = "Email or password are incorrect" });
            }
        }

        [HttpPost]
        public ActionResult CheckTeacher(string email, string password)
        {
            Professeur professeur = loginService.Login(email, password, "Prof") as Professeur;
            if (professeur != null)
            {

                //set the authentication cookie
                var ticket = new FormsAuthenticationTicket(professeur.Email, true, 3000);
                string encrypt = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypt);
                cookie.Expires = DateTime.Now.AddHours(4);
                Response.Cookies.Add(cookie);
                cookie.HttpOnly = true;

                //ViewBag.Nom = professeur.Nom;
                return RedirectToAction("Index", "Professeur");

            }
            else
            {
                return RedirectToAction("IndexMsg", new { msg = "Email or password are incorrect" });
            }
        }

        [HttpPost]
        public ActionResult CheckStudent(string email, string password)
        {
            if (email == "student@gmail.com" && password == "123")
            {

                return View("Home");
            }
            else
            {
                return RedirectToAction("IndexMsg", new { msg = "Email or password are incorrect" });
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

    }
}