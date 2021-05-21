using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.Models
{
    public class Emploi
    {
        public Emploi()
        {
            Seances = new HashSet<Seance>();
            Locals = new HashSet<Local>();
            Absences = new HashSet<Absence>();
            Modules = new HashSet<Module>();
        }

        public int Id { get; set; }

        [ForeignKey("Semaine")]
        public int Semaine_id { get; set; }

        public virtual Semaine Semaine { get; set; }

        public virtual ICollection<Seance> Seances { get; set; }
        public virtual ICollection<Local> Locals { get; set; }
        public virtual ICollection<Absence> Absences { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
        
    }

}