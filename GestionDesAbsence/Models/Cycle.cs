using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.Models
{
    public class Cycle
    {
        public Cycle()
        {
            Classes = new HashSet<Classe>(); 
        }

        public int Id { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<Classe> Classes { get; set; }
    }
}