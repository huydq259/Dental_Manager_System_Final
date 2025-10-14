namespace Dental_Manager_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointment",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false, identity: true),
                        AppointmentDate = c.DateTime(nullable: false),
                        AppointmentTime = c.Time(nullable: false, precision: 7),
                        AppointmentStatus = c.Int(nullable: false),
                        Reason = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        PatientId = c.Long(nullable: false),
                        DoctorId = c.Long(nullable: false),
                        ReceptionistId = c.Long(),
                    })
                .PrimaryKey(t => t.AppointmentId)
                .ForeignKey("dbo.User", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.ReceptionistId)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId)
                .Index(t => t.ReceptionistId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Long(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RoleTitle = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Consulation",
                c => new
                    {
                        ConsulationId = c.Int(nullable: false, identity: true),
                        Dianoisis = c.String(nullable: false),
                        Notes = c.String(),
                        CreatedAt = c.DateTime(),
                        AppointmentId = c.Int(nullable: false),
                        DoctorId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ConsulationId);
            
            CreateTable(
                "dbo.Medicine",
                c => new
                    {
                        MedicineId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        DosageForm = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MedicineId);
            
            CreateTable(
                "dbo.Patient_Record",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        MedicalHistory = c.String(nullable: false),
                        Allergies = c.String(nullable: false),
                        Notes = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        PatientId = c.Long(nullable: false),
                        DoctorId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaidAt = c.DateTime(nullable: false),
                        PaymentMethod = c.String(nullable: false),
                        PaymentStatus = c.Int(nullable: false),
                        AppointmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId);
            
            CreateTable(
                "dbo.Prescription",
                c => new
                    {
                        PrescriptionId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        DosageInstructions = c.String(),
                        ConsulationId = c.Int(nullable: false),
                        MedicineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrescriptionId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Appointment", "ReceptionistId", "dbo.User");
            DropForeignKey("dbo.Appointment", "PatientId", "dbo.User");
            DropForeignKey("dbo.Appointment", "DoctorId", "dbo.User");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Appointment", new[] { "ReceptionistId" });
            DropIndex("dbo.Appointment", new[] { "DoctorId" });
            DropIndex("dbo.Appointment", new[] { "PatientId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Prescription");
            DropTable("dbo.Payment");
            DropTable("dbo.Patient_Record");
            DropTable("dbo.Medicine");
            DropTable("dbo.Consulation");
            DropTable("dbo.User");
            DropTable("dbo.Appointment");
        }
    }
}
