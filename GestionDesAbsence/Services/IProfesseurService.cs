using GestionDesAbsence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesAbsence.Services
{
    public interface IProfesseurService
    {
        void Save(Professeur professeur);
        IEnumerable<Etudiant> FindAll();
        Professeur GetProfesseurById(int id);
        Professeur GetProfesseurByEmail(string email);

        /* type de retour 
        list => {
          seance => id, heur_debut, heur_fin
          classes => list { Id, Nom }
          semaine => id, Code
          module => Id, NomModule
          date:"2021-05-30"
        }*/
        Object GetSeancesForProf(int semaine_id, int professeur_id);

        /* type de retour 
        list => {
          classe => id, nom
          etudiant => id, nom, prenom
          absence => id, estPresent
        }*/
        Object GetStudentsList(int id_seance, int id_module, int id_semaine);
        bool UpdateAbsence(int id_absence, bool est_present);

        void deleteProfesseur(Professeur p);
    }
}
