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
        Emploi GetEmploi(Semaine semaine, Professeur professeur);
    }
}
