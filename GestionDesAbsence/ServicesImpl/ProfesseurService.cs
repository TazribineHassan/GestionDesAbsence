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


        public List<SeancesForProf> GetSeancesForProf(int semaine_id, int professeur_id)
        {
            List<SeancesForProf> listSeeances = new List<SeancesForProf>();
                var seance = context.details_Emplois.Where(e => e.Module.Professeur.Id == professeur_id
                                                             && e.Emploi.Semaine.id == semaine_id)
                                                  .Select(e => new
                                                  {
                                                      seance = new { e.Seance.id, e.Seance.Heure_debut, e.Seance.Heure_fin },
                                                      classes = e.Module.Classes.Select(cl => new { 
                                                                                            cl.Id,
                                                                                            cl.Nom
                                                                                        }).ToList(),
                                                      semaine = new { e.Emploi.Semaine.id, e.Emploi.Semaine.Code},
                                                      module = new { e.Module.Id, e.Module.NomModule },
                                                      date = DateTime.Now
                                                  }).ToList();
            return listSeeances;
        }

        public Object GetStudentsList(int id_seance, int id_module, int id_semaine)
        {
            var seance_courante = context.details_Emplois.Where(r => (r.Module_Id == id_module
                                           && r.Seance_Id == id_seance
                                           && r.Emploi.Semaine.id == id_semaine)).FirstOrDefault();
            var students_by_classe = context.Modules.Where(module => module.Id == id_module)
                            .Select(module => new
                            {
                                classes = module.Classes.Select(c => new
                                {
                                    id = c.Id,
                                    nom = c.Nom,
                                    etudiants = c.Etudiants.Select(e => new
                                    {
                                        etudiant_id = e.Id,
                                        e.Nom,
                                        e.Prenom
                                    })
                                })
                            }).FirstOrDefault();


            // generer les absenses 'ils n'existent pas
            List<object> final_result = new List<object>();
            foreach (var classe in students_by_classe.classes)
            {
                foreach(var etudiant in classe.etudiants)
                {
                    var student_from_db = context.Etudiants.Find(etudiant.etudiant_id);
                    if(student_from_db != null)
                    {
                        var absence = student_from_db.Absences.Where(a => a.Details_Emploi.Id == seance_courante.Id)
                                                                .Select(a => new
                                                                {
                                                                    id = a.Id,
                                                                    estPresent = a.EstPresent
                                                                })
                                                                .FirstOrDefault();
                        if(absence == null)
                        {
                            var new_absence = new Absence() { Etudiant_id = student_from_db.Id, EstPresent = true};
                            student_from_db.Absences.Add(new_absence);
                            seance_courante.Absences.Add(new_absence);
                            context.Absences.Add(new_absence);
                            context.SaveChanges();
                            absence = new { id = new_absence.Id, estPresent = new_absence.EstPresent };
                        }

                        final_result.Add(new {
                            classe = new
                            {
                                id = classe.id,
                                nom = classe.nom
                            },
                            etudiant = etudiant,
                            absence = absence
                        });
                    }
                    
                }
            }

            return final_result;
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