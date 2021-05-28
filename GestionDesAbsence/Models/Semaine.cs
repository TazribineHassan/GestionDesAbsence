using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.Models
{
    public class Semaine
    {

        public int id { get; set; }
        public string Code { get; set; }
        public DateTime Date_debut { get; set; }
        public DateTime Date_fin { get; set; }

        public virtual Emploi Emploi { get; set; }
    }
}