using GestionDesAbsence.Models;
using GestionDesAbsence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.ServicesImpl
{
    public class ProfesseurService : IProfesseurService
    {
        GestionDesAbsenceContext context = new GestionDesAbsenceContext();

        public IEnumerable<Etudiant> FindAll()
        {
            return (IEnumerable<Etudiant>)context.Professeurs.ToList();
        }

        public Professeur GetProfesseurByEmail(string email)
        {

            return context.Professeurs.FirstOrDefault(prof => prof.Email == email); ;
        }

        public Professeur GetProfesseurById(int id)
        {
            return context.Professeurs.Find(id);
        }

        public void Save(Professeur professeur)
        {
            context.Professeurs.Add(professeur);
            context.SaveChanges();
        }


        public Emploi GetEmploi(Semaine semaine)
        {
            var emploi = context.Emplois.FirstOrDefault(x => x.Semaine.id == semaine.id);
            return emploi;
        }

    }
}