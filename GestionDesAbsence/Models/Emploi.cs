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
            Details_Emplois = new HashSet<Details_Emploi>();
        }
        
        [ForeignKey("Semaine")]
        public int Id { get; set; }

        public virtual Semaine Semaine { get; set; }
        public virtual ICollection<Details_Emploi> Details_Emplois { get; set; }

    }

}