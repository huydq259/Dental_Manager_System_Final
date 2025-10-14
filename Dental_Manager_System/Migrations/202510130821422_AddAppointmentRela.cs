namespace Dental_Manager_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAppointmentRela : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "FullName", c => c.String());
            AddColumn("dbo.Appointments", "Phone", c => c.String());
            DropColumn("dbo.Appointments", "Reason");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "Reason", c => c.String());
            DropColumn("dbo.Appointments", "Phone");
            DropColumn("dbo.Appointments", "FullName");
        }
    }
}
