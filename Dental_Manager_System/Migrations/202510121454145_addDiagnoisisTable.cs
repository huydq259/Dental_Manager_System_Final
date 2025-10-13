namespace Dental_Manager_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDiagnoisisTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diagnoisis",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Diagnoisis");
        }
    }
}
