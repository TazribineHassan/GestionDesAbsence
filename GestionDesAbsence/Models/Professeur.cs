using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.Models
{
    public class Professeur
    {
        public Professeur()
        {
            Modules = new HashSet<Module>();
        }

        public int Id { get; set; }
        public string Code_prof { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [ForeignKey("Role")]
        public Nullable<int> Role_Id { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<Module>  Modules { get; set; }

    }
}