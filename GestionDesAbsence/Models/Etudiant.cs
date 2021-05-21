﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.Models
{
    public class Etudiant
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public virtual ICollection<Absence> Absences { get; set; }

        public Etudiant()
        {
            this.Absences = new HashSet<Absence>();
        }
    }
}