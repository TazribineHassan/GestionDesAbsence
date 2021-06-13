using GestionDesAbsence.Models;
using System;
using GestionDesAbsence.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.ServicesImpl
{
    public class EtudiantService : IEtudiantService {

        GestionDesAbsenceContext context = new GestionDesAbsenceContext();

       
        public List<AbsenceList> GetAbsence(int Etudiant_id)
        {
            var absences = context.Absences.Where(absence => absence.Etudiant.Id == Etudiant_id)
                            .Select(absence => new { Absence_ID = absence.Id,
                                                     Est_Absent = !absence.EstPresent,
                                                     module = new { Id = absence.Details_Emploi.Module.Id, 
                                                                             NomModule = absence.Details_Emploi.Module .NomModule
                                                                   },
                                                     seance = new 
                                                     {
                                                         id = absence.Details_Emploi.Seance.id,
                                                         Heure_debut = absence.Details_Emploi.Seance.Heure_debut,
                                                         Heure_fin = absence.Details_Emploi.Seance.Heure_fin,
                                                         Jour = absence.Details_Emploi.Seance.Jour
                                                     },
                                                     semaine = new {id = absence.Details_Emploi.Emploi.Semaine.id, 
                                                                    Code = absence.Details_Emploi.Emploi.Semaine.Code }
                                                     
                                                   }).ToList();
            List<AbsenceList> result = new List<AbsenceList>();
            foreach(var absence in absences)
            {
                var item = new AbsenceList()
                {
                    Absence_ID = absence.Absence_ID,
                    Est_Absent = absence.Est_Absent,
                    module = new Module()
                    {
                        Id = absence.module.Id,
                        NomModule = absence.module.NomModule
                    },
                    seance = new Seance()
                    {
                        id = absence.seance.id,
                        Heure_debut = absence.seance.Heure_debut,
                        Heure_fin = absence.seance.Heure_fin,
                        Jour = absence.seance.Jour
                    },
                    semaine = new Semaine()
                    {
                        id = absence.seance.id,
                        Code = absence.semaine.Code
                    }
                };
                result.Add(item);
            }
            return result;
        }

     

        public Etudiant GetEtudiantByEmail(string email)
        {
            return context.Etudiants.FirstOrDefault(etd => etd.Email == email);
        }

        public Etudiant GetEudiantById(int id)
        {
            return context.Etudiants.Find(id);
        }

      
                

             


        }


    }
        

       
    
