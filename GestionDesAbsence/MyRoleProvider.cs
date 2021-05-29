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
                var user_role = db.Professeurs.Include("Role").Where(p => p.Email == username).FirstOrDefault().Role.Nome;
                if(user_role == null)
                    user_role = db.Administrateurs.Include("Role").Where(p => p.Email == username).FirstOrDefault().Role.Nome;
                if (user_role == null)
                    user_role = db.Etudiants.Include("Role").Where(p => p.Email == username).FirstOrDefault().Role.Nome;
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