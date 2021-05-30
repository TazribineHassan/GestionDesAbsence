using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.Models
{
    public class StudentsList
    {
        public Classe Classe { get; set; }
        public Etudiant Etudiant { get; set; }
        public Absence Absence { get; set; }
    }
}