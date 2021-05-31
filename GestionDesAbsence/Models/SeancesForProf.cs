using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.Models
{
    public class SeancesForProf
    {
        public Seance Seance { get; set; }
        public List<Classe> Classes { get; set; }
        public Semaine  Semaine { get; set; }
        public Module Module { get; set; }
        public DateTime Date { get; set; }
    }
}