using GestionDesAbsence.Models;
using GestionDesAbsence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        public string CheckAdmin(string email, string password)
        {
            if (email == "admin@gmail.com" && password == "123")
            {
                return "you're in";
            }
            else
            {
                return "please check your email";
            }
        }

        [HttpPost]
        public ActionResult CheckTeacher(string email, string password)
        {
            Professeur professeur = loginService.Login(email, password, "Prof") as Professeur;
            if(professeur != null)
            {

                //set the authentication coockie
                var ticket = new FormsAuthenticationTicket(professeur.Email, true, 3000);
                string encrypt = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypt);
                cookie.Expires = DateTime.Now.AddHours(3);
                Response.Cookies.Add(cookie);
                cookie.HttpOnly = true;

               //ViewBag.Nom = professeur.Nom;
                return RedirectToAction("Index", "Professeur", new { nom = professeur.Nom});

            }
            else
            {
                return RedirectToAction("IndexMsg", new { msg = "Email or password are incorrect" });
            }
        }

        [HttpPost]
        public ActionResult CheckStudent(string email, string password)
        {
            if(email == "student@gmail.com" && password == "123")
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