namespace Dental_Manager_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDiagnoisisToAppointment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Dianoisis", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "Dianoisis");
        }
    }
}
