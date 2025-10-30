namespace Dental_Manager_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePatientIdToLong : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "PatientId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "PatientId", c => c.Int(nullable: false));
        }
    }
}
