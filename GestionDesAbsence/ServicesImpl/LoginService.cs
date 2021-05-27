﻿using GestionDesAbsence.Common;
using GestionDesAbsence.Models;
using GestionDesAbsence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.ServicesImpl
{
    public class LoginService : ILoginService
    {
        ProfesseurService professeurService;

        public LoginService(ProfesseurService professeurService)
        {
            this.professeurService = professeurService;
        }

        public object Login(string email, string password, string userType)
        {
            if (userType.Equals("admin"))
            {
                return null;
            }
            else if (userType.Equals("Prof"))
            {
                Professeur professeur = professeurService.GetProfesseurByEmail(email);
                if(professeur != null)
                {
                    if (password.Equals(Encryption.Decrypt(professeur.Password))) return professeur;
                    else return null;
                }
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}