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


        public Emploi GetEmploi(Semaine semaine, Professeur professeur)
        {
            var globalEmpoli = context.Emplois.FirstOrDefault(emp => emp.Semaine.id == semaine.id);
            var emploiForProf = new Emploi();
            var module = from m in globalEmpoli.Modules 
                         where m.Professeur.Id == professeur.Id 
                         select m;
            var seances = from s in globalEmpoli.Seances select s;
            var locals = from l in globalEmpoli.Locals select l;
            
            return emploiForProf;
        }

    }
}