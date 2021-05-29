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


        public Object GetSeancesForProf(Semaine semaine, Professeur professeur)
        {
            var emploiForProfesseur = context.details_Emplois
                         .Join(context.Modules,
                               details_Emplois => details_Emplois.Id,
                               module => module.Id,
                               (details_Emplois, module) => new { details_Emplois, module}
                              )
                          .Join(context.Professeurs,
                               emploi_module => emploi_module.module.Professeur.Id,
                               prof => prof.Id,
                               (emploi_module, prof) => new {
                                   details_Emplois = emploi_module.details_Emplois,
                                   module = emploi_module.module,
                                   professeur = prof
                               })
                          .Join(context.Emplois,
                               emploi_module => emploi_module.module.Professeur.Id,
                               emploi => emploi.Id,
                               (emploi_module, emploi) => new {
                                   details_Emplois = emploi_module.details_Emplois,
                                   module = emploi_module.module,
                                   professeur = emploi_module.professeur,
                                   empoloi = emploi
                               })
                          .Where(emploi_module_prof => 
                                        emploi_module_prof.professeur.Id == professeur.Id
                                        && emploi_module_prof.empoloi.Semaine.id == semaine.id)
                          .ToList();
            
            return emploiForProfesseur;
        }

    }
}