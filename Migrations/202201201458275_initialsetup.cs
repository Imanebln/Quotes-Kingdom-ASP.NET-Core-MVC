  namespace jokes3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialsetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Quotes");
        }
    }
}
