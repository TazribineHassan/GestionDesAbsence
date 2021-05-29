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
        Object GetSeancesForProf(Semaine semaine, Professeur professeur);
        Object GetStudentsList(int id_seance, int id_module, int id_semaine);
        bool UpdateAbsence(int id_absence, bool est_present);
    }
}
