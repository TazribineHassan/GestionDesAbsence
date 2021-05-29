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
                            .Join(context.Classes,
                            emploi_module => emploi_module.module.Id,
                            classe => classe.Id,
                            (emploi_module, classe) => new {
                                module = emploi_module.module,
                                details_Emplois = emploi_module.details_Emplois,
                                classe = classe
                            })
                          .Join(context.Professeurs,
                               emploi_module_classe => emploi_module_classe.module.Professeur.Id,
                               prof => prof.Id,
                               (emploi_module_classe, prof) => new {
                                   details_Emplois = emploi_module_classe.details_Emplois,
                                   module = emploi_module_classe.module,
                                   classe = emploi_module_classe.classe,
                                   professeur = prof
                               })
                          .Join(context.Emplois,
                               emploi_module => emploi_module.module.Professeur.Id,
                               emploi => emploi.Id,
                               (all, emploi) => new {
                                   details_Emplois = all.details_Emplois,
                                   module = all.module,
                                   classe = all.classe,
                                   professeur = all.professeur,
                                   emploi = emploi
                               })
                          .Where(emploi_module_prof => 
                                        emploi_module_prof.professeur.Id == professeur.Id
                                        && emploi_module_prof.emploi.Semaine.id == semaine.id)
                          .Select(all => new { module = new { all.module.Id ,all.module.NomModule }, 
                               seance = new { all.details_Emplois.Seance.id, all.details_Emplois.Seance.Heure_debut, all.details_Emplois.Seance.Heure_fin },
                               semaine = new { semaine.id, semaine.Code},
                               classe = new { all.classe.Id, all.classe.Nom}
                          }).ToList();
            
            return emploiForProfesseur;
        }

        public Object GetStudentsList(int id_seance, int id_module, int id_semaine)
        {
            var students = context.Modules
                            .Join(context.Classes,
                            module => module.Id,
                            classe => classe.Id,
                            (module, classe) => new { 
                                module = module, 
                                classe = classe })
                            .Join(context.Groupes,
                            module_classe => module_classe.classe.Id,
                            groupe => groupe.Id,
                            (module_classe, groupe) => new { 
                                module = module_classe.module, 
                                classe = module_classe.classe,
                                groupe = groupe
                            })
                            .Join(context.Etudiants,
                            module_classe_groupe => module_classe_groupe.groupe.Id,
                            etudiant => etudiant.Id,
                            (module_classe_groupe, etudiant) => new { 
                                module = module_classe_groupe.module, 
                                classe = module_classe_groupe.classe,
                                groupe = module_classe_groupe.groupe,
                                etudiant = etudiant
                            })
                            .Join(context.details_Emplois,
                            all => all.module.Id,
                            details_emploi => details_emploi.Id,
                            (all, details_emploi) => new {
                                module = all.module,
                                classe = all.classe,
                                groupe = all.groupe,
                                etudiant = all.etudiant,
                                details_emploi = details_emploi
                            })
                            .Where(all => (all.module.Id == id_module
                                           && all.details_emploi.Seance_Id == id_seance
                                           && all.details_emploi.Emploi.Semaine.id == id_semaine))
                            .Select(all => new {
                                etudiants = new { all.etudiant.Id, all.etudiant.Nom, all.etudiant.Prenom },
                                presence = new { emploi_id = all.details_emploi.Id, etudiant_id = all.etudiant.Id },
                            }).ToList();

            return students;
        }

        public bool UpdateAbsence(int id_absence, bool est_present)
        {
            var absence = context.Absences.Find(id_absence);
            absence.EstPresent = est_present;
            var result = context.SaveChanges();
            return result >= 1; //return true if more than one record updated successfully
        }
    }
}