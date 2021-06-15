using GestionDesAbsence.Common;
using GestionDesAbsence.Models;
using GestionDesAbsence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public bool UpdateAbsence(int id_absence, bool est_present)
        {
            var absence = context.Absences.Where(ab => ab.Id == id_absence).FirstOrDefault();
            absence.EstPresent = est_present;
            var result = context.SaveChanges();
            return result >= 1; //return true if more than one record updated successfully
        }
        

        public void saveEtudiant(Etudiant e)
        {
            e.Role_Id = 3;
            context.Etudiants.Add(e);
            context.SaveChanges();
        }

        public void deleteEtudiant(Etudiant e)
        {
            Etudiant etud = context.Etudiants.Find(e.Id);
            context.Etudiants.Remove(etud);
            context.SaveChanges();
        }

        public void updateEtudiant(Etudiant e)
        {
            Etudiant etud = context.Etudiants.Find(e.Id);
            etud = e;
            context.SaveChanges();
        }


        public List<StudentsList> GetStudentsList(int id_seance, int id_module, int id_semaine)
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
                                        e.Prenom,
                                        id_groupe = e.Groupe.Id,
                                        nom_groupe = e.Groupe.Nom

                                    })
                                })
                            }).FirstOrDefault();


            // generer les absenses 'ils n'existent pas
            List<StudentsList> final_result = new List<StudentsList>();
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

                        final_result.Add(new StudentsList() {
                            Classe = new Classe()
                            {
                                Id = classe.id,
                                Nom = classe.nom
                            },
                            Etudiant = new Etudiant() { Id = etudiant.etudiant_id, Nom = etudiant.Nom, Prenom = etudiant.Prenom, Id_groupe = etudiant.id_groupe, Groupe = new Groupe() { Id = etudiant.id_groupe, Nom = etudiant.nom_groupe } },
                            Absence = new Absence() { Id = absence.id, EstPresent = absence.estPresent }
                        });
                    }
                    
                }
            }

            return final_result;
        }



       



    }

}