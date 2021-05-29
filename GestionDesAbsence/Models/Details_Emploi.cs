using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.Models
{
    public class Details_Emploi
    {
        public int Id { get; set; }

        [ForeignKey("Emploi")]
        public int Emploi_Id { get; set; }

        [ForeignKey("Seance")]
        public int Seance_Id { get; set; }

        [ForeignKey("Module")]
        public int Module_Id { get; set; }

        [ForeignKey("Local")]
        public int Local_Id { get; set; }


        public Emploi Emploi { get; set; }

        public Seance Seance { get; set; }

        public Module Module { get; set; }

        public Local Local { get; set; }

        public virtual ICollection<Absence> Absences { get; set; }
    }
}