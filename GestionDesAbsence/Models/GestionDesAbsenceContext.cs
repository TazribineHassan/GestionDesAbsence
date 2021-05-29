using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.Models
{
    public class GestionDesAbsenceContext : DbContext
    {
        public GestionDesAbsenceContext() : base("name=GestionDesAbsence")
        {

        }

        public DbSet<Absence> Absences { get; set; }
        public DbSet<Administrateur> Administrateurs { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Cycle> Cycles { get; set; }
        public DbSet<Emploi> Emplois { get; set; }
        public DbSet<Details_Emploi> details_Emplois { get; set; }
        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Groupe> Groupes { get; set; }
        public DbSet<Local> Locals { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Professeur> Professeurs { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Semaine> Semaines { get; set; }

    }
}