namespace Dental_Manager_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRequireUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "DateOfBirth", c => c.DateTime());
            AlterColumn("dbo.Users", "Gender", c => c.String());
            AlterColumn("dbo.Users", "Address", c => c.String());
            DropColumn("dbo.Users", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
