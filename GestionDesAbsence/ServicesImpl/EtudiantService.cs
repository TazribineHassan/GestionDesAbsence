using GestionDesAbsence.Models;
using System;
using GestionDesAbsence.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.ServicesImpl
{
    public class EtudiantService : IEtudiantService
    {
        GestionDesAbsenceContext context = new GestionDesAbsenceContext();

        public List<Etudiant> getAll()
        {
            return context.Etudiants.ToList();
        }



        public Etudiant getById(int id)
        {
            return (Etudiant)context.Etudiants.Where<Etudiant>(c => c.Id == id );
        }
    }
}