using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.Models
{
    public class AbsenceList
    {
        public int Absence_ID { get; set; }
        public bool Est_Absent { get; set; }
        public Module module { get; set; }
        public Seance seance { get; set; }
        public Semaine semaine { get; set; }
    }
}