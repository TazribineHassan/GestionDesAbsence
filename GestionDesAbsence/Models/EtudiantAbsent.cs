using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.Models
{
    public class EtudiantAbsent
    {
         public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public int absence_count { get; set; }
        public string nomClass { get; set; }


    }
}