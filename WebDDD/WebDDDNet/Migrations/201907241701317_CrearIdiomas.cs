namespace WebDDDNet.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CrearIdiomas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Idiomas",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Cultura = c.String(nullable: true, maxLength: 5),
                    Icono = c.String(nullable: true, maxLength: 128),
                    Nombre = c.String(nullable: true, maxLength: 80),
                    UsuarioIdCreacion = c.String(),
                    FechaCreacion = c.DateTime(nullable: true),
                    UsuarioIdActualizacion = c.String(),
                    FechaActualizacion = c.DateTime(),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Idiomas");
        }
    }
}
