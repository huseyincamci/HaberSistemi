namespace HaberiSistemi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                        Goruntelenme = c.Int(nullable: false),
                        Resim = c.String(maxLength: 255),
                        KullaniciId = c.Int(nullable: false),
                        KategoriId = c.Int(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        Aktif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kategori", t => t.KategoriId, cascadeDelete: true)
                .ForeignKey("dbo.Kullanici", t => t.KullaniciId, cascadeDelete: true)
                .Index(t => t.KullaniciId)
                .Index(t => t.KategoriId);
            
            CreateTable(
                "dbo.Kategori",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(nullable: false, maxLength: 150),
                        ParentId = c.Int(nullable: false),
                        Url = c.String(maxLength: 150),
                        KullaiciId = c.Int(),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        Aktif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kullanici", t => t.KullaiciId)
                .Index(t => t.KullaiciId);
            
            CreateTable(
                "dbo.Kullanici",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdSoyad = c.String(maxLength: 50),
                        Email = c.String(nullable: false),
                        Sifre = c.String(nullable: false, maxLength: 16),
                        RolId = c.Int(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        Aktif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rol", t => t.RolId, cascadeDelete: true)
                .Index(t => t.RolId);
            
            CreateTable(
                "dbo.Rol",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RolAdi = c.String(maxLength: 150),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        Aktif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResimUrl = c.String(),
                        HaberId = c.Int(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        Aktif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Haber", t => t.HaberId, cascadeDelete: true)
                .Index(t => t.HaberId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resim", "HaberId", "dbo.Haber");
            DropForeignKey("dbo.Haber", "KullaniciId", "dbo.Kullanici");
            DropForeignKey("dbo.Haber", "KategoriId", "dbo.Kategori");
            DropForeignKey("dbo.Kategori", "KullaiciId", "dbo.Kullanici");
            DropForeignKey("dbo.Kullanici", "RolId", "dbo.Rol");
            DropIndex("dbo.Resim", new[] { "HaberId" });
            DropIndex("dbo.Kullanici", new[] { "RolId" });
            DropIndex("dbo.Kategori", new[] { "KullaiciId" });
            DropIndex("dbo.Haber", new[] { "KategoriId" });
            DropIndex("dbo.Haber", new[] { "KullaniciId" });
            DropTable("dbo.Resim");
            DropTable("dbo.Rol");
            DropTable("dbo.Kullanici");
            DropTable("dbo.Kategori");
            DropTable("dbo.Haber");
        }
    }
}
