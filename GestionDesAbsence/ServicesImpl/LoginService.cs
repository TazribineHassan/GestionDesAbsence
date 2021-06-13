using GestionDesAbsence.Common;
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
        EtudiantService etudiantService;


        public LoginService(ProfesseurService professeurService)
        {
            this.professeurService = professeurService;
            this.etudiantService = new EtudiantService();
        }

        public object Login(string email, string password, string userType)
        {
            if (userType.Equals("admin"))
            {
                GestionDesAbsenceContext context = new GestionDesAbsenceContext();
                Administrateur administrateur = context.Administrateurs.FirstOrDefault(admin => admin.Email == email);
                if (administrateur != null)
                {
                    if (password.Equals(Encryption.Decrypt(administrateur.Password))) return administrateur;
                    else return null;
                }
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
            else if (userType.Equals("etudiant"))
            {
                     Etudiant etudiant = etudiantService.GetEtudiantByEmail(email);
                if (etudiant != null)
                {
                    if (password.Equals(Encryption.Decrypt(etudiant.Password))) return etudiant;
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