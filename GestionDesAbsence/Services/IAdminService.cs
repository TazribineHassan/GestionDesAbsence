using GestionDesAbsence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesAbsence.Services
{
    interface IAdminService
    {

        void Save(Administrateur admin);
        void saveEtudiant(Etudiant e);
        void deleteEtudiant(Etudiant e);
        void updateEtudiant(Etudiant e);

    }
}
