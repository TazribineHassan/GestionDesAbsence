namespace GestionDesAbsence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Absences",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    EstPresent = c.Boolean(nullable: false),
                    Commentaire = c.String(),
                    Emploi_Id = c.Int(),
                    Etudiant_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Emplois", t => t.Emploi_Id)
                .ForeignKey("dbo.Etudiants", t => t.Etudiant_Id)
                .Index(t => t.Emploi_Id)
                .Index(t => t.Etudiant_Id);

            CreateTable(
                "dbo.Emplois",
                c => new
                {
                    Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Semaines", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.Locals",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    nom = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Modules",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    NomModule = c.String(),
                    id_Professeur = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professeurs", t => t.id_Professeur, cascadeDelete: true)
                .Index(t => t.id_Professeur);

            CreateTable(
                "dbo.Classes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nom = c.String(),
                    id_cycle = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cycles", t => t.id_cycle)
                .Index(t => t.id_cycle);

            CreateTable(
                "dbo.Cycles",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nom = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Groupes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nom = c.String(),
                    id_classe = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.id_classe)
                .Index(t => t.id_classe);

            CreateTable(
                "dbo.Etudiants",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Cne = c.String(),
                    Nom = c.String(),
                    Prenom = c.String(),
                    Email = c.String(),
                    Password = c.String(),
                    Id_groupe = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groupes", t => t.Id_groupe)
                .Index(t => t.Id_groupe);

            CreateTable(
                "dbo.Professeurs",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Code_prof = c.String(),
                    Nom = c.String(),
                    Prenom = c.String(),
                    Email = c.String(),
                    Password = c.String(),
                    Role_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.Role_Id);

            CreateTable(
                "dbo.Roles",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nom = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Seances",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    Heure_debut = c.String(),
                    Heure_fin = c.String(),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.Semaines",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    Code = c.String(),
                    Date_debut = c.DateTime(nullable: false),
                    Date_fin = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.Administrateurs",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nom = c.String(),
                    Prenom = c.String(),
                    Email = c.String(),
                    Password = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.LocalEmplois",
                c => new
                {
                    Local_Id = c.Int(nullable: false),
                    Emploi_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Local_Id, t.Emploi_Id })
                .ForeignKey("dbo.Locals", t => t.Local_Id, cascadeDelete: true)
                .ForeignKey("dbo.Emplois", t => t.Emploi_Id, cascadeDelete: true)
                .Index(t => t.Local_Id)
                .Index(t => t.Emploi_Id);

            CreateTable(
                "dbo.ClasseModules",
                c => new
                {
                    Classe_Id = c.Int(nullable: false),
                    Module_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Classe_Id, t.Module_Id })
                .ForeignKey("dbo.Classes", t => t.Classe_Id, cascadeDelete: true)
                .ForeignKey("dbo.Modules", t => t.Module_Id, cascadeDelete: true)
                .Index(t => t.Classe_Id)
                .Index(t => t.Module_Id);

            CreateTable(
                "dbo.ModuleEmplois",
                c => new
                {
                    Module_Id = c.Int(nullable: false),
                    Emploi_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Module_Id, t.Emploi_Id })
                .ForeignKey("dbo.Modules", t => t.Module_Id, cascadeDelete: true)
                .ForeignKey("dbo.Emplois", t => t.Emploi_Id, cascadeDelete: true)
                .Index(t => t.Module_Id)
                .Index(t => t.Emploi_Id);

            CreateTable(
                "dbo.SeanceEmplois",
                c => new
                {
                    Seance_id = c.Int(nullable: false),
                    Emploi_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Seance_id, t.Emploi_Id })
                .ForeignKey("dbo.Seances", t => t.Seance_id, cascadeDelete: true)
                .ForeignKey("dbo.Emplois", t => t.Emploi_Id, cascadeDelete: true)
                .Index(t => t.Seance_id)
                .Index(t => t.Emploi_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Emplois", "Id", "dbo.Semaines");
            DropForeignKey("dbo.SeanceEmplois", "Emploi_Id", "dbo.Emplois");
            DropForeignKey("dbo.SeanceEmplois", "Seance_id", "dbo.Seances");
            DropForeignKey("dbo.Modules", "id_Professeur", "dbo.Professeurs");
            DropForeignKey("dbo.ModuleEmplois", "Emploi_Id", "dbo.Emplois");
            DropForeignKey("dbo.ModuleEmplois", "Module_Id", "dbo.Modules");
            DropForeignKey("dbo.ClasseModules", "Module_Id", "dbo.Modules");
            DropForeignKey("dbo.ClasseModules", "Classe_Id", "dbo.Classes");
            DropForeignKey("dbo.Etudiants", "Id_groupe", "dbo.Groupes");
            DropForeignKey("dbo.Absences", "Etudiant_Id", "dbo.Etudiants");
            DropForeignKey("dbo.Groupes", "id_classe", "dbo.Classes");
            DropForeignKey("dbo.Classes", "id_cycle", "dbo.Cycles");
            DropForeignKey("dbo.LocalEmplois", "Emploi_Id", "dbo.Emplois");
            DropForeignKey("dbo.LocalEmplois", "Local_Id", "dbo.Locals");
            DropForeignKey("dbo.Absences", "Emploi_Id", "dbo.Emplois");
            DropForeignKey("dbo.Professeurs", "Role_Id", "dbo.Roles");
            DropIndex("dbo.SeanceEmplois", new[] { "Emploi_Id" });
            DropIndex("dbo.SeanceEmplois", new[] { "Seance_id" });
            DropIndex("dbo.ModuleEmplois", new[] { "Emploi_Id" });
            DropIndex("dbo.ModuleEmplois", new[] { "Module_Id" });
            DropIndex("dbo.ClasseModules", new[] { "Module_Id" });
            DropIndex("dbo.ClasseModules", new[] { "Classe_Id" });
            DropIndex("dbo.LocalEmplois", new[] { "Emploi_Id" });
            DropIndex("dbo.LocalEmplois", new[] { "Local_Id" });
            DropIndex("dbo.Etudiants", new[] { "Id_groupe" });
            DropIndex("dbo.Groupes", new[] { "id_classe" });
            DropIndex("dbo.Classes", new[] { "id_cycle" });
            DropIndex("dbo.Modules", new[] { "id_Professeur" });
            DropIndex("dbo.Professeurs", new[] { "Role_Id" });
            DropIndex("dbo.Emplois", new[] { "Id" });
            DropIndex("dbo.Absences", new[] { "Etudiant_Id" });
            DropIndex("dbo.Absences", new[] { "Emploi_Id" });
            DropTable("dbo.SeanceEmplois");
            DropTable("dbo.ModuleEmplois");
            DropTable("dbo.ClasseModules");
            DropTable("dbo.LocalEmplois");
            DropTable("dbo.Administrateurs");
            DropTable("dbo.Semaines");
            DropTable("dbo.Seances");
            DropTable("dbo.Roles");
            DropTable("dbo.Professeurs");
            DropTable("dbo.Etudiants");
            DropTable("dbo.Groupes");
            DropTable("dbo.Cycles");
            DropTable("dbo.Classes");
            DropTable("dbo.Modules");
            DropTable("dbo.Locals");
            DropTable("dbo.Emplois");
            DropTable("dbo.Absences");
        }
    }
}
