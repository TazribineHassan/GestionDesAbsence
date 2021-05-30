namespace GestionDesAbsence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        Details_Emploi_Id = c.Int(),
                        Etudiant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Details_Emploi", t => t.Details_Emploi_Id)
                .ForeignKey("dbo.Etudiants", t => t.Etudiant_Id)
                .Index(t => t.Details_Emploi_Id)
                .Index(t => t.Etudiant_Id);
            
            CreateTable(
                "dbo.Details_Emploi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Emploi_Id = c.Int(nullable: false),
                        Seance_Id = c.Int(nullable: false),
                        Module_Id = c.Int(nullable: false),
                        Local_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Emplois", t => t.Emploi_Id, cascadeDelete: true)
                .ForeignKey("dbo.Locals", t => t.Local_Id, cascadeDelete: true)
                .ForeignKey("dbo.Modules", t => t.Module_Id, cascadeDelete: true)
                .ForeignKey("dbo.Seances", t => t.Seance_Id, cascadeDelete: true)
                .Index(t => t.Emploi_Id)
                .Index(t => t.Seance_Id)
                .Index(t => t.Module_Id)
                .Index(t => t.Local_Id);
            
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
                "dbo.Etudiants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cne = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Role_Id = c.Int(),
                        Id_groupe = c.Int(),
                        Id_classe = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.Id_classe)
                .ForeignKey("dbo.Groupes", t => t.Id_groupe)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .Index(t => t.Role_Id)
                .Index(t => t.Id_groupe)
                .Index(t => t.Id_classe);
            
            CreateTable(
                "dbo.Groupes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Administrateurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .Index(t => t.Role_Id);
            
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
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.Seances",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Jour = c.String(),
                        Heure_debut = c.String(),
                        Heure_fin = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Details_Emploi", "Seance_Id", "dbo.Seances");
            DropForeignKey("dbo.Details_Emploi", "Module_Id", "dbo.Modules");
            DropForeignKey("dbo.Modules", "id_Professeur", "dbo.Professeurs");
            DropForeignKey("dbo.ClasseModules", "Module_Id", "dbo.Modules");
            DropForeignKey("dbo.ClasseModules", "Classe_Id", "dbo.Classes");
            DropForeignKey("dbo.Etudiants", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Professeurs", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Administrateurs", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Etudiants", "Id_groupe", "dbo.Groupes");
            DropForeignKey("dbo.Etudiants", "Id_classe", "dbo.Classes");
            DropForeignKey("dbo.Absences", "Etudiant_Id", "dbo.Etudiants");
            DropForeignKey("dbo.Classes", "id_cycle", "dbo.Cycles");
            DropForeignKey("dbo.Details_Emploi", "Local_Id", "dbo.Locals");
            DropForeignKey("dbo.Details_Emploi", "Emploi_Id", "dbo.Emplois");
            DropForeignKey("dbo.Emplois", "Id", "dbo.Semaines");
            DropForeignKey("dbo.Absences", "Details_Emploi_Id", "dbo.Details_Emploi");
            DropIndex("dbo.ClasseModules", new[] { "Module_Id" });
            DropIndex("dbo.ClasseModules", new[] { "Classe_Id" });
            DropIndex("dbo.Professeurs", new[] { "Role_Id" });
            DropIndex("dbo.Administrateurs", new[] { "Role_Id" });
            DropIndex("dbo.Etudiants", new[] { "Id_classe" });
            DropIndex("dbo.Etudiants", new[] { "Id_groupe" });
            DropIndex("dbo.Etudiants", new[] { "Role_Id" });
            DropIndex("dbo.Classes", new[] { "id_cycle" });
            DropIndex("dbo.Modules", new[] { "id_Professeur" });
            DropIndex("dbo.Emplois", new[] { "Id" });
            DropIndex("dbo.Details_Emploi", new[] { "Local_Id" });
            DropIndex("dbo.Details_Emploi", new[] { "Module_Id" });
            DropIndex("dbo.Details_Emploi", new[] { "Seance_Id" });
            DropIndex("dbo.Details_Emploi", new[] { "Emploi_Id" });
            DropIndex("dbo.Absences", new[] { "Etudiant_Id" });
            DropIndex("dbo.Absences", new[] { "Details_Emploi_Id" });
            DropTable("dbo.ClasseModules");
            DropTable("dbo.Seances");
            DropTable("dbo.Professeurs");
            DropTable("dbo.Administrateurs");
            DropTable("dbo.Roles");
            DropTable("dbo.Groupes");
            DropTable("dbo.Etudiants");
            DropTable("dbo.Cycles");
            DropTable("dbo.Classes");
            DropTable("dbo.Modules");
            DropTable("dbo.Locals");
            DropTable("dbo.Semaines");
            DropTable("dbo.Emplois");
            DropTable("dbo.Details_Emploi");
            DropTable("dbo.Absences");
        }
    }
}
