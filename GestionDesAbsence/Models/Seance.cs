using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GestionDesAbsence.Models
{
    public class Seance : ISerializable
    {
        public Seance()
        {
            this.Details_Emplois = new HashSet<Details_Emploi>();
        }
        [Key]
        public int id { get; set; }
        public string Jour { get; set; }
        public string Heure_debut { get; set; }
        public string Heure_fin { get; set; }

        public virtual ICollection<Details_Emploi> Details_Emplois { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}