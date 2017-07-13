namespace SaintSender.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        sender = c.String(),
                        body = c.String(),
                        to = c.String(),
                        date = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Emails");
        }
    }
}
