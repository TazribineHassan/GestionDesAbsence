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
            var result = new Emploi();
            var emploiForProfesseur = context.Emplois
                         .Join(context.Modules,
                               emploi => emploi.Id,
                               module => module.Id,
                               (emploi, module) => new {emploi, module}
                              )
                          .Join(context.Professeurs,
                               emploi_module => emploi_module.module.Professeur.Id,
                               prof => prof.Id,
                               (emploi_module, prof) => new { 
                                   emploi = emploi_module.emploi,
                                   module = emploi_module.module,
                                   professeur = prof
                               })
                          .Where(emploi_module_prof => 
                                        emploi_module_prof.professeur.Id == professeur.Id
                                        && emploi_module_prof.emploi.Semaine.id == semaine.id)
                          ;
            
            return result;
        }

    }
}