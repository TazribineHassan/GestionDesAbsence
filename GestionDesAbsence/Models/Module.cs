using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.Models
{
    public class Module
    {
        [Key]
        public int Id { get; set; }

        public string NomModule { get; set; }
    }
}