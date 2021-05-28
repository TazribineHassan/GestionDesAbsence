using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.Models
{
    public class Module
    {
        public Module()
        {
            Classes = new HashSet<Classe>();
            Emplois = new HashSet<Emploi>();
        }

        public int Id { get; set; }
        public string NomModule { get; set; }

        [ForeignKey("Professeur")]
        public int id_Professeur { get; set; }

        public virtual Professeur Professeur { get; set; }

        public virtual ICollection<Classe> Classes { get; set; }
        public virtual ICollection<Emploi> Emplois { get; set; }
    }
}