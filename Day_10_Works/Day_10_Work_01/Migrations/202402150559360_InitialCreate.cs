namespace Day_10_Work_01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        WorkerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Trade = c.Int(nullable: false),
                        Contact = c.String(nullable: false, maxLength: 20),
                        Picture = c.String(nullable: false, maxLength: 30),
                        PayRate = c.Decimal(nullable: false, storeType: "money"),
                        StartDate = c.DateTime(nullable: false, storeType: "date"),
                        EndDate = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.WorkerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Workers");
        }
    }
}
