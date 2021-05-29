using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.Models
{
    public class Absence
    {
        [Key]
        public int Id { get; set; }
        public bool EstPresent { get; set; }
        public string Commentaire { get; set; }

        [ForeignKey("Etudiant")]
        public Nullable<int> Etudiant_id;
        public virtual Etudiant Etudiant { get; set; }

        [ForeignKey("Details_Emploi")]
        public Nullable<int> Details_Emploi_id;
        public virtual Details_Emploi Details_Emploi { get; set; }

    }
}