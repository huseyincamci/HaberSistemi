namespace HaberiSistemi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HaberveResim : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Haber",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Baslik = c.String(nullable: false, maxLength: 255),
                        KisaAciklama = c.String(),
                        Aciklama = c.String(),
                        Aktif = c.Boolean(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        Goruntelenme = c.Int(nullable: false),
                        Resim = c.String(maxLength: 255),
                        KullaniciId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kullanici", t => t.KullaniciId, cascadeDelete: true)
                .Index(t => t.KullaniciId);
            
            CreateTable(
                "dbo.Resim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResimUrl = c.String(),
                        HaberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Haber", t => t.HaberId, cascadeDelete: true)
                .Index(t => t.HaberId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resim", "HaberId", "dbo.Haber");
            DropForeignKey("dbo.Haber", "KullaniciId", "dbo.Kullanici");
            DropIndex("dbo.Resim", new[] { "HaberId" });
            DropIndex("dbo.Haber", new[] { "KullaniciId" });
            DropTable("dbo.Resim");
            DropTable("dbo.Haber");
        }
    }
}
