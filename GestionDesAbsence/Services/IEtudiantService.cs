using GestionDesAbsence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesAbsence.Services
{
    public interface IEtudiantService
    {
        List<Etudiant> getAll();
        Etudiant getById(int id);


    }
}
