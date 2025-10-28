namespace Dental_Manager_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editNullAbleForUserDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Users", "UpdatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
