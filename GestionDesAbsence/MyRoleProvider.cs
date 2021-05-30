using GestionDesAbsence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace GestionDesAbsence
{
    public class MyRoleProvider : RoleProvider
    {
        public override string ApplicationName { get; set; }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            using (GestionDesAbsenceContext db = new GestionDesAbsenceContext())
            {
                string user_role = "";
                Professeur professeur = db.Professeurs.FirstOrDefault(p => p.Email == username);
                if (professeur != null) user_role = professeur.Role.Nome;
                if (user_role.Equals(""))
                {
                    Administrateur admin = db.Administrateurs.FirstOrDefault(p => p.Email == username);
                    if (admin != null) user_role = admin.Role.Nome;
                }
                if (user_role.Equals(""))
                {
                    Etudiant etudiant = db.Etudiants.FirstOrDefault(p => p.Email == username);
                    if (etudiant != null) user_role = etudiant.Role.Nome;
                }   
                string[] role = { user_role };
                return role;
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}