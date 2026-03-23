namespace CentroCapacitacionEmergencias.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cohortes",
                c => new
                    {
                        CohorteId = c.Int(nullable: false, identity: true),
                        sNombreCohorte = c.String(),
                    })
                .PrimaryKey(t => t.CohorteId);
            
            CreateTable(
                "dbo.Participantes",
                c => new
                    {
                        ParticipanteId = c.Int(nullable: false, identity: true),
                        sTipoIdentificacion = c.String(),
                        sNumeroIdentificacion = c.String(),
                        sNombreCompleto = c.String(),
                        dtFechaNacimiento = c.DateTime(nullable: false),
                        sProvincia = c.String(),
                        sCanton = c.String(),
                        sDistrito = c.String(),
                        sDetallesResidencia = c.String(),
                        sEstadoCivil = c.String(),
                        sEmail = c.String(),
                        sTelefono = c.String(),
                        sDireccionResidencia = c.String(),
                        sContactoEmergencia = c.String(),
                        bEstaActivo = c.Boolean(nullable: false),
                        iIDCohorte = c.Int(nullable: false),
                        Cohorte_CohorteId = c.Int(),
                    })
                .PrimaryKey(t => t.ParticipanteId)
                .ForeignKey("dbo.Cohortes", t => t.Cohorte_CohorteId)
                .Index(t => t.Cohorte_CohorteId);
            
            CreateTable(
                "dbo.ParticipanteCursoes",
                c => new
                    {
                        ParticipanteCursoId = c.Int(nullable: false, identity: true),
                        iParticipanteID = c.Int(nullable: false),
                        iCursoID = c.Int(nullable: false),
                        CCurso_CursoId = c.Int(),
                        PParticipante_ParticipanteId = c.Int(),
                    })
                .PrimaryKey(t => t.ParticipanteCursoId)
                .ForeignKey("dbo.Cursoes", t => t.CCurso_CursoId)
                .ForeignKey("dbo.Participantes", t => t.PParticipante_ParticipanteId)
                .Index(t => t.CCurso_CursoId)
                .Index(t => t.PParticipante_ParticipanteId);
            
            CreateTable(
                "dbo.Cursoes",
                c => new
                    {
                        CursoId = c.Int(nullable: false, identity: true),
                        sNombreCurso = c.String(),
                        bCursoActivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CursoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParticipanteCursoes", "PParticipante_ParticipanteId", "dbo.Participantes");
            DropForeignKey("dbo.ParticipanteCursoes", "CCurso_CursoId", "dbo.Cursoes");
            DropForeignKey("dbo.Participantes", "Cohorte_CohorteId", "dbo.Cohortes");
            DropIndex("dbo.ParticipanteCursoes", new[] { "PParticipante_ParticipanteId" });
            DropIndex("dbo.ParticipanteCursoes", new[] { "CCurso_CursoId" });
            DropIndex("dbo.Participantes", new[] { "Cohorte_CohorteId" });
            DropTable("dbo.Cursoes");
            DropTable("dbo.ParticipanteCursoes");
            DropTable("dbo.Participantes");
            DropTable("dbo.Cohortes");
        }
    }
}
