using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.Models
{
    public class Local
    {
        public Local()
        {
            this.Details_Emplois = new HashSet<Details_Emploi>();
        }
        [Key]
        public int Id { get; set; }
        public string nom { get; set; }

        public virtual ICollection<Details_Emploi> Details_Emplois { get; set; }
    }
}