using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.Models
{
    public class Seance
    {
        [Key]
        public int id { get; set; }
        public string Heure_debut { get; set; }
        public string Heure_fin { get; set; }

        public virtual ICollection<Emploi> Emplois { get; set; }
    }
}