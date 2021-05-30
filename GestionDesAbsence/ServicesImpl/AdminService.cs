using GestionDesAbsence.Models;
using GestionDesAbsence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.ServicesImpl
{
    public class AdminService : IAdminService
    {
        GestionDesAbsenceContext context = new GestionDesAbsenceContext();
        public void Save(Administrateur admin)
        {
            context.Administrateurs.Add(admin);
            context.SaveChanges();
        }

        public void saveEtudiant(Etudiant e)
        {
            e.Role_Id = 3;
            context.Etudiants.Add(e);
            context.SaveChanges();
        }

        public void deleteEtudiant(Etudiant e)
        {
            context.Etudiants.Remove(e);
            context.SaveChanges();
        }

        public void updateEtudiant(Etudiant e)
        {
            Etudiant etud = context.Etudiants.Find(e.Id);
            etud = e;
            context.SaveChanges();
        }
    }
}