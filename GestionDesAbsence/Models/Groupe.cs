using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.Models
{
    public class Groupe
    {
        public Groupe()
        {
            Etudiants = new HashSet<Etudiant>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }

        [ForeignKey("Classe")]
        public int? id_classe { get; set; }

        public virtual Classe Classe { get; set; }

        public virtual ICollection<Etudiant> Etudiants { get; set; }
    }
}