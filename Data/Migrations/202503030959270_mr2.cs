namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mr2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Personels", "Hizmet_HizmetId", "dbo.Hizmets");
            DropIndex("dbo.Personels", new[] { "Hizmet_HizmetId" });
            DropColumn("dbo.Personels", "HizmetId");
            RenameColumn(table: "dbo.Personels", name: "Hizmet_HizmetId", newName: "HizmetId");
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RolName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Personels", "kullaniciAdi", c => c.String());
            AddColumn("dbo.Personels", "sifre", c => c.String());
            AddColumn("dbo.Personels", "RolId", c => c.Int(nullable: false));
            AddColumn("dbo.Siparis", "MusteriAdi", c => c.String());
            AddColumn("dbo.Siparis", "MusteriSoyadi", c => c.String());
            AddColumn("dbo.Siparis", "Tarih", c => c.DateTime(nullable: false));
            AddColumn("dbo.Musteris", "kayitlimi", c => c.Boolean(nullable: false));
            AddColumn("dbo.Musteris", "Sifre", c => c.String());
            AlterColumn("dbo.Personels", "HizmetId", c => c.Int(nullable: false));
            AlterColumn("dbo.Personels", "HizmetId", c => c.Int(nullable: false));
            CreateIndex("dbo.Personels", "RolId");
            CreateIndex("dbo.Personels", "HizmetId");
            AddForeignKey("dbo.Personels", "RolId", "dbo.Rols", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Personels", "HizmetId", "dbo.Hizmets", "HizmetId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personels", "HizmetId", "dbo.Hizmets");
            DropForeignKey("dbo.Personels", "RolId", "dbo.Rols");
            DropIndex("dbo.Personels", new[] { "HizmetId" });
            DropIndex("dbo.Personels", new[] { "RolId" });
            AlterColumn("dbo.Personels", "HizmetId", c => c.Int());
            AlterColumn("dbo.Personels", "HizmetId", c => c.String());
            DropColumn("dbo.Musteris", "Sifre");
            DropColumn("dbo.Musteris", "kayitlimi");
            DropColumn("dbo.Siparis", "Tarih");
            DropColumn("dbo.Siparis", "MusteriSoyadi");
            DropColumn("dbo.Siparis", "MusteriAdi");
            DropColumn("dbo.Personels", "RolId");
            DropColumn("dbo.Personels", "sifre");
            DropColumn("dbo.Personels", "kullaniciAdi");
            DropTable("dbo.Rols");
            RenameColumn(table: "dbo.Personels", name: "HizmetId", newName: "Hizmet_HizmetId");
            AddColumn("dbo.Personels", "HizmetId", c => c.String());
            CreateIndex("dbo.Personels", "Hizmet_HizmetId");
            AddForeignKey("dbo.Personels", "Hizmet_HizmetId", "dbo.Hizmets", "HizmetId");
        }
    }
}
