namespace Dental_Manager_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixAppointmentPatientId_And_Relationships : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "PatientId", c => c.Long(nullable: false));
            CreateIndex("dbo.Appointments", "PatientId");
            CreateIndex("dbo.Appointments", "DoctorId");
            CreateIndex("dbo.Appointments", "ReceptionistId");
            AddForeignKey("dbo.Appointments", "DoctorId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "PatientId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "ReceptionistId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "ReceptionistId", "dbo.Users");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Users");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Users");
            DropIndex("dbo.Appointments", new[] { "ReceptionistId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            AlterColumn("dbo.Appointments", "PatientId", c => c.Int(nullable: false));
        }
    }
}
