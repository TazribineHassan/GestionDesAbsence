using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.Models
{
    public class Classe
    {
        public Classe()
        {
            Etudiants = new HashSet<Etudiant>();
            Modules = new HashSet<Module>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }

        [ForeignKey("Cycle")]
        public int? id_cycle { get; set; }

        public virtual Cycle Cycle { get; set; }
        public virtual ICollection<Etudiant> Etudiants { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
    }
}