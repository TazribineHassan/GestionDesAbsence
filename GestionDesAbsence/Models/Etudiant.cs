using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.Models
{
    public class Etudiant
    {
        public int Id { get; set; }
        public string Cne { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [ForeignKey("Groupe")]
        public int? id_fil { get; set; }

        public virtual Groupe Groupe { get; set; }

        public virtual ICollection<Absence> Absences { get; set; }

        public Etudiant()
        {
            this.Absences = new HashSet<Absence>();
        }

    }
}