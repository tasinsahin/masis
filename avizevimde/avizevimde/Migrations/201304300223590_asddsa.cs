namespace avizevimde.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asddsa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.sehirs", "admin_Id", "dbo.admins");
            DropForeignKey("dbo.mahalles", "admin_Id", "dbo.admins");
            DropForeignKey("dbo.vergiDairesis", "admin_Id", "dbo.admins");
            DropForeignKey("dbo.siparis", "montajci_MyProperty", "dbo.montajcis");
            DropIndex("dbo.sehirs", new[] { "admin_Id" });
            DropIndex("dbo.mahalles", new[] { "admin_Id" });
            DropIndex("dbo.vergiDairesis", new[] { "admin_Id" });
            DropIndex("dbo.siparis", new[] { "montajci_MyProperty" });
            RenameColumn(table: "dbo.sehirs", name: "admin_Id", newName: "ekleyenId");
            RenameColumn(table: "dbo.mahalles", name: "admin_Id", newName: "ekleyenId");
            RenameColumn(table: "dbo.vergiDairesis", name: "admin_Id", newName: "ekleyenId");
            RenameColumn(table: "dbo.siparis", name: "montajci_MyProperty", newName: "montajci_id");
            CreateTable(
                "dbo.smsTuketicis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        tuketiciId = c.Int(nullable: false),
                        smsTarihi = c.DateTime(nullable: false),
                        smsNumara = c.Int(nullable: false),
                        eklenmeTarihi = c.DateTime(nullable: false),
                        ekleyenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.admins", t => t.ekleyenId, cascadeDelete: true)
                .Index(t => t.ekleyenId);
            
            AddColumn("dbo.markas", "degistirilenId", c => c.Int(nullable: false));
            AddColumn("dbo.markas", "degistirenId", c => c.Int(nullable: false));
            AddColumn("dbo.markas", "enYeni", c => c.Boolean(nullable: false));
            AddColumn("dbo.taksits", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.montajcis", "id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.montajcis", "tanim", c => c.String(nullable: false));
            AddColumn("dbo.montajcis", "telefon", c => c.String(nullable: false));
            AddColumn("dbo.montajcis", "telefon2", c => c.String(nullable: false));
            AddColumn("dbo.montajcis", "cepTelefonu", c => c.String(nullable: false));
            AddColumn("dbo.montajcis", "epostaAdresi", c => c.String(nullable: false));
            AddColumn("dbo.semts", "IlceId", c => c.Int(nullable: false));
            AlterColumn("dbo.sehirs", "ekleyenId", c => c.Int(nullable: false));
            AlterColumn("dbo.mahalles", "degistirenId", c => c.Int(nullable: false));
            AlterColumn("dbo.bankas", "ekleyenId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.taksits", new[] { "taksitSecenegiId" });
            AddPrimaryKey("dbo.taksits", "Id");
            DropPrimaryKey("dbo.montajcis", new[] { "MyProperty" });
            AddPrimaryKey("dbo.montajcis", "id");
            AddForeignKey("dbo.logoes", "degistirenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.sehirs", "ekleyenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.sehirs", "degistirenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ilces", "ekleyenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ilces", "degistirenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.mahalles", "ekleyenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.mahalles", "degistirenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.markas", "degistirenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.bankas", "ekleyenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.bankas", "degistirenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.bankaSubes", "ekleyenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.bankaSubes", "degistirenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.kategoris", "ekleyenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.kategoris", "degistirenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.blogs", "ekleyenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.blogs", "degistirenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.banners", "ekleyenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.banners", "degistirenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.taksits", "ekleyenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.carousels", "ekleyenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.carousels", "degistirenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.vergiDairesis", "ekleyenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.vergiDairesis", "degistirenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.montajciLogs", "MontajciId", "dbo.montajcis", "id", cascadeDelete: true);
            AddForeignKey("dbo.renks", "degistirenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.siparis", "montajci_id", "dbo.montajcis", "id");
            AddForeignKey("dbo.tasimaSartis", "ekleyenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tasiyiciSubes", "DegistirenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.semts", "IlceId", "dbo.ilces", "Id", cascadeDelete: true);
            AddForeignKey("dbo.semts", "ekleyenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.semts", "degistirenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MontajciBankas", "bankaId", "dbo.bankas", "bankaId", cascadeDelete: true);
            AddForeignKey("dbo.MontajciBankas", "bankaSubeId", "dbo.bankaSubes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MontajciFaturas", "montajciId", "dbo.montajcis", "id", cascadeDelete: true);
            AddForeignKey("dbo.MontajciAdres", "sehirId", "dbo.sehirs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MontajciAdres", "ilceId", "dbo.ilces", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MontajciAdres", "semtId", "dbo.semts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MontajciAdres", "mahalleId", "dbo.mahalles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MontajciAdres", "montajciId", "dbo.montajcis", "id", cascadeDelete: true);
            AddForeignKey("dbo.altKategoris", "ekleyenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.altKategoris", "degistirenId", "dbo.admins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.altKategoris", "kategoriId", "dbo.kategoris", "Id", cascadeDelete: true);
            CreateIndex("dbo.logoes", "degistirenId");
            CreateIndex("dbo.sehirs", "ekleyenId");
            CreateIndex("dbo.sehirs", "degistirenId");
            CreateIndex("dbo.ilces", "ekleyenId");
            CreateIndex("dbo.ilces", "degistirenId");
            CreateIndex("dbo.mahalles", "ekleyenId");
            CreateIndex("dbo.mahalles", "degistirenId");
            CreateIndex("dbo.markas", "degistirenId");
            CreateIndex("dbo.bankas", "ekleyenId");
            CreateIndex("dbo.bankas", "degistirenId");
            CreateIndex("dbo.bankaSubes", "ekleyenId");
            CreateIndex("dbo.bankaSubes", "degistirenId");
            CreateIndex("dbo.kategoris", "ekleyenId");
            CreateIndex("dbo.kategoris", "degistirenId");
            CreateIndex("dbo.blogs", "ekleyenId");
            CreateIndex("dbo.blogs", "degistirenId");
            CreateIndex("dbo.banners", "ekleyenId");
            CreateIndex("dbo.banners", "degistirenId");
            CreateIndex("dbo.taksits", "ekleyenId");
            CreateIndex("dbo.carousels", "ekleyenId");
            CreateIndex("dbo.carousels", "degistirenId");
            CreateIndex("dbo.vergiDairesis", "ekleyenId");
            CreateIndex("dbo.vergiDairesis", "degistirenId");
            CreateIndex("dbo.montajciLogs", "MontajciId");
            CreateIndex("dbo.renks", "degistirenId");
            CreateIndex("dbo.siparis", "montajci_id");
            CreateIndex("dbo.tasimaSartis", "ekleyenId");
            CreateIndex("dbo.tasiyiciSubes", "DegistirenId");
            CreateIndex("dbo.semts", "IlceId");
            CreateIndex("dbo.semts", "ekleyenId");
            CreateIndex("dbo.semts", "degistirenId");
            CreateIndex("dbo.MontajciBankas", "bankaId");
            CreateIndex("dbo.MontajciBankas", "bankaSubeId");
            CreateIndex("dbo.MontajciFaturas", "montajciId");
            CreateIndex("dbo.MontajciAdres", "sehirId");
            CreateIndex("dbo.MontajciAdres", "ilceId");
            CreateIndex("dbo.MontajciAdres", "semtId");
            CreateIndex("dbo.MontajciAdres", "mahalleId");
            CreateIndex("dbo.MontajciAdres", "montajciId");
            CreateIndex("dbo.altKategoris", "ekleyenId");
            CreateIndex("dbo.altKategoris", "degistirenId");
            CreateIndex("dbo.altKategoris", "kategoriId");
            DropColumn("dbo.markas", "vergiSecenegiDegistirilenId");
            DropColumn("dbo.markas", "vergiSecenegiDegistirlenEnYeni");
            DropColumn("dbo.bankaSubes", "adminId");
            DropColumn("dbo.taksits", "taksitSecenegiId");
            DropColumn("dbo.montajcis", "MyProperty");
            DropColumn("dbo.montajcis", "montajciId");
            DropColumn("dbo.montajcis", "montajciAdi");
            DropColumn("dbo.montajcis", "montajciTanim");
            DropColumn("dbo.montajcis", "montajciTelefon");
            DropColumn("dbo.montajcis", "montajciTelefon2");
            DropColumn("dbo.montajcis", "montajciCepTelefonu");
            DropColumn("dbo.montajcis", "montajciEpostaAdresi");
            DropColumn("dbo.semts", "semtIlceId");
            DropTable("dbo.sms");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.sms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        tuketiciId = c.Int(nullable: false),
                        montajciId = c.Int(nullable: false),
                        ureticiId = c.Int(nullable: false),
                        smsTarihi = c.DateTime(nullable: false),
                        smsNumara = c.Int(nullable: false),
                        eklenmeTarihi = c.DateTime(nullable: false),
                        ekleyenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.semts", "semtIlceId", c => c.Int(nullable: false));
            AddColumn("dbo.montajcis", "montajciEpostaAdresi", c => c.String(nullable: false));
            AddColumn("dbo.montajcis", "montajciCepTelefonu", c => c.String(nullable: false));
            AddColumn("dbo.montajcis", "montajciTelefon2", c => c.String(nullable: false));
            AddColumn("dbo.montajcis", "montajciTelefon", c => c.String(nullable: false));
            AddColumn("dbo.montajcis", "montajciTanim", c => c.String(nullable: false));
            AddColumn("dbo.montajcis", "montajciAdi", c => c.String(nullable: false));
            AddColumn("dbo.montajcis", "montajciId", c => c.Int(nullable: false));
            AddColumn("dbo.montajcis", "MyProperty", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.taksits", "taksitSecenegiId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.bankaSubes", "adminId", c => c.Int(nullable: false));
            AddColumn("dbo.markas", "vergiSecenegiDegistirlenEnYeni", c => c.Boolean(nullable: false));
            AddColumn("dbo.markas", "vergiSecenegiDegistirilenId", c => c.Int(nullable: false));
            DropIndex("dbo.altKategoris", new[] { "kategoriId" });
            DropIndex("dbo.altKategoris", new[] { "degistirenId" });
            DropIndex("dbo.altKategoris", new[] { "ekleyenId" });
            DropIndex("dbo.MontajciAdres", new[] { "montajciId" });
            DropIndex("dbo.MontajciAdres", new[] { "mahalleId" });
            DropIndex("dbo.MontajciAdres", new[] { "semtId" });
            DropIndex("dbo.MontajciAdres", new[] { "ilceId" });
            DropIndex("dbo.MontajciAdres", new[] { "sehirId" });
            DropIndex("dbo.MontajciFaturas", new[] { "montajciId" });
            DropIndex("dbo.MontajciBankas", new[] { "bankaSubeId" });
            DropIndex("dbo.MontajciBankas", new[] { "bankaId" });
            DropIndex("dbo.semts", new[] { "degistirenId" });
            DropIndex("dbo.semts", new[] { "ekleyenId" });
            DropIndex("dbo.semts", new[] { "IlceId" });
            DropIndex("dbo.tasiyiciSubes", new[] { "DegistirenId" });
            DropIndex("dbo.smsTuketicis", new[] { "ekleyenId" });
            DropIndex("dbo.tasimaSartis", new[] { "ekleyenId" });
            DropIndex("dbo.siparis", new[] { "montajci_id" });
            DropIndex("dbo.renks", new[] { "degistirenId" });
            DropIndex("dbo.montajciLogs", new[] { "MontajciId" });
            DropIndex("dbo.vergiDairesis", new[] { "degistirenId" });
            DropIndex("dbo.vergiDairesis", new[] { "ekleyenId" });
            DropIndex("dbo.carousels", new[] { "degistirenId" });
            DropIndex("dbo.carousels", new[] { "ekleyenId" });
            DropIndex("dbo.taksits", new[] { "ekleyenId" });
            DropIndex("dbo.banners", new[] { "degistirenId" });
            DropIndex("dbo.banners", new[] { "ekleyenId" });
            DropIndex("dbo.blogs", new[] { "degistirenId" });
            DropIndex("dbo.blogs", new[] { "ekleyenId" });
            DropIndex("dbo.kategoris", new[] { "degistirenId" });
            DropIndex("dbo.kategoris", new[] { "ekleyenId" });
            DropIndex("dbo.bankaSubes", new[] { "degistirenId" });
            DropIndex("dbo.bankaSubes", new[] { "ekleyenId" });
            DropIndex("dbo.bankas", new[] { "degistirenId" });
            DropIndex("dbo.bankas", new[] { "ekleyenId" });
            DropIndex("dbo.markas", new[] { "degistirenId" });
            DropIndex("dbo.mahalles", new[] { "degistirenId" });
            DropIndex("dbo.mahalles", new[] { "ekleyenId" });
            DropIndex("dbo.ilces", new[] { "degistirenId" });
            DropIndex("dbo.ilces", new[] { "ekleyenId" });
            DropIndex("dbo.sehirs", new[] { "degistirenId" });
            DropIndex("dbo.sehirs", new[] { "ekleyenId" });
            DropIndex("dbo.logoes", new[] { "degistirenId" });
            DropForeignKey("dbo.altKategoris", "kategoriId", "dbo.kategoris");
            DropForeignKey("dbo.altKategoris", "degistirenId", "dbo.admins");
            DropForeignKey("dbo.altKategoris", "ekleyenId", "dbo.admins");
            DropForeignKey("dbo.MontajciAdres", "montajciId", "dbo.montajcis");
            DropForeignKey("dbo.MontajciAdres", "mahalleId", "dbo.mahalles");
            DropForeignKey("dbo.MontajciAdres", "semtId", "dbo.semts");
            DropForeignKey("dbo.MontajciAdres", "ilceId", "dbo.ilces");
            DropForeignKey("dbo.MontajciAdres", "sehirId", "dbo.sehirs");
            DropForeignKey("dbo.MontajciFaturas", "montajciId", "dbo.montajcis");
            DropForeignKey("dbo.MontajciBankas", "bankaSubeId", "dbo.bankaSubes");
            DropForeignKey("dbo.MontajciBankas", "bankaId", "dbo.bankas");
            DropForeignKey("dbo.semts", "degistirenId", "dbo.admins");
            DropForeignKey("dbo.semts", "ekleyenId", "dbo.admins");
            DropForeignKey("dbo.semts", "IlceId", "dbo.ilces");
            DropForeignKey("dbo.tasiyiciSubes", "DegistirenId", "dbo.admins");
            DropForeignKey("dbo.smsTuketicis", "ekleyenId", "dbo.admins");
            DropForeignKey("dbo.tasimaSartis", "ekleyenId", "dbo.admins");
            DropForeignKey("dbo.siparis", "montajci_id", "dbo.montajcis");
            DropForeignKey("dbo.renks", "degistirenId", "dbo.admins");
            DropForeignKey("dbo.montajciLogs", "MontajciId", "dbo.montajcis");
            DropForeignKey("dbo.vergiDairesis", "degistirenId", "dbo.admins");
            DropForeignKey("dbo.vergiDairesis", "ekleyenId", "dbo.admins");
            DropForeignKey("dbo.carousels", "degistirenId", "dbo.admins");
            DropForeignKey("dbo.carousels", "ekleyenId", "dbo.admins");
            DropForeignKey("dbo.taksits", "ekleyenId", "dbo.admins");
            DropForeignKey("dbo.banners", "degistirenId", "dbo.admins");
            DropForeignKey("dbo.banners", "ekleyenId", "dbo.admins");
            DropForeignKey("dbo.blogs", "degistirenId", "dbo.admins");
            DropForeignKey("dbo.blogs", "ekleyenId", "dbo.admins");
            DropForeignKey("dbo.kategoris", "degistirenId", "dbo.admins");
            DropForeignKey("dbo.kategoris", "ekleyenId", "dbo.admins");
            DropForeignKey("dbo.bankaSubes", "degistirenId", "dbo.admins");
            DropForeignKey("dbo.bankaSubes", "ekleyenId", "dbo.admins");
            DropForeignKey("dbo.bankas", "degistirenId", "dbo.admins");
            DropForeignKey("dbo.bankas", "ekleyenId", "dbo.admins");
            DropForeignKey("dbo.markas", "degistirenId", "dbo.admins");
            DropForeignKey("dbo.mahalles", "degistirenId", "dbo.admins");
            DropForeignKey("dbo.mahalles", "ekleyenId", "dbo.admins");
            DropForeignKey("dbo.ilces", "degistirenId", "dbo.admins");
            DropForeignKey("dbo.ilces", "ekleyenId", "dbo.admins");
            DropForeignKey("dbo.sehirs", "degistirenId", "dbo.admins");
            DropForeignKey("dbo.sehirs", "ekleyenId", "dbo.admins");
            DropForeignKey("dbo.logoes", "degistirenId", "dbo.admins");
            DropPrimaryKey("dbo.montajcis", new[] { "id" });
            AddPrimaryKey("dbo.montajcis", "MyProperty");
            DropPrimaryKey("dbo.taksits", new[] { "Id" });
            AddPrimaryKey("dbo.taksits", "taksitSecenegiId");
            AlterColumn("dbo.bankas", "ekleyenId", c => c.String(nullable: false));
            AlterColumn("dbo.mahalles", "degistirenId", c => c.String());
            AlterColumn("dbo.sehirs", "ekleyenId", c => c.String());
            DropColumn("dbo.semts", "IlceId");
            DropColumn("dbo.montajcis", "epostaAdresi");
            DropColumn("dbo.montajcis", "cepTelefonu");
            DropColumn("dbo.montajcis", "telefon2");
            DropColumn("dbo.montajcis", "telefon");
            DropColumn("dbo.montajcis", "tanim");
            DropColumn("dbo.montajcis", "id");
            DropColumn("dbo.taksits", "Id");
            DropColumn("dbo.markas", "enYeni");
            DropColumn("dbo.markas", "degistirenId");
            DropColumn("dbo.markas", "degistirilenId");
            DropTable("dbo.smsTuketicis");
            RenameColumn(table: "dbo.siparis", name: "montajci_id", newName: "montajci_MyProperty");
            RenameColumn(table: "dbo.vergiDairesis", name: "ekleyenId", newName: "admin_Id");
            RenameColumn(table: "dbo.mahalles", name: "ekleyenId", newName: "admin_Id");
            RenameColumn(table: "dbo.sehirs", name: "ekleyenId", newName: "admin_Id");
            CreateIndex("dbo.siparis", "montajci_MyProperty");
            CreateIndex("dbo.vergiDairesis", "admin_Id");
            CreateIndex("dbo.mahalles", "admin_Id");
            CreateIndex("dbo.sehirs", "admin_Id");
            AddForeignKey("dbo.siparis", "montajci_MyProperty", "dbo.montajcis", "MyProperty");
            AddForeignKey("dbo.vergiDairesis", "admin_Id", "dbo.admins", "Id");
            AddForeignKey("dbo.mahalles", "admin_Id", "dbo.admins", "Id");
            AddForeignKey("dbo.sehirs", "admin_Id", "dbo.admins", "Id");
        }
    }
}
