namespace Dental_Manager_System.Migrations
{
    using Dental_Manager.System.Models.Enums;
    using Dental_Manager.System.Models;
    using Dental_Manager_System.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Dental_Manager_System.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        // Migrations/Configuration.cs
        protected override void Seed(ApplicationDbContext context)
        {
            // Seed Users
            var users = new List<User>
    {
        // Doctors
        new User
        {
            UserId = 1,
            FullName = "BS. Nguyễn Văn An",
            DateOfBirth = new DateTime(1980, 5, 15),
            Gender = "Nam",
            Phone = "0901234567",
            Email = "doctor.an@gmail.com",
            Address = "123 Nguyễn Trãi, Q.5, TP.HCM",
            Password = "123456", // In production, hash this!
            RoleTitle = RoleTitle.DOCTOR,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        },
        new User
        {
            UserId = 2,
            FullName = "BS. Trần Thị Bình",
            DateOfBirth = new DateTime(1985, 8, 20),
            Gender = "Nữ",
            Phone = "0902345678",
            Email = "doctor.binh@gmail.com",
            Address = "456 Lê Lợi, Q.1, TP.HCM",
            Password = "123456",
            RoleTitle = RoleTitle.DOCTOR,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        },
        
        // Patients
        new User
        {
            UserId = 1001,
            FullName = "Đoàn Quang Huy",
            DateOfBirth = new DateTime(1995, 3, 10),
            Gender = "Nam",
            Phone = "0393838838",
            Email = "huy.patient@gmail.com",
            Address = "789 Bùi Thị Xuân, Q.1, TP.HCM",
            Password = "123456",
            RoleTitle = RoleTitle.PATIENT,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        },
        
        // Receptionist
        new User
        {
            UserId = 5001,
            FullName = "Lễ tân Minh",
            DateOfBirth = new DateTime(1998, 1, 15),
            Gender = "Nam",
            Phone = "0912345678",
            Email = "receptionist.minh@gmail.com",
            Address = "111 Võ Văn Tần, Q.3, TP.HCM",
            Password = "123456",
            RoleTitle = RoleTitle.RECEPTIONIST,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        }
    };

            context.Users.AddOrUpdate(u => u.UserId, users.ToArray());

            // Seed Appointments
            var appointments = new List<Appointment>
    {
        new Appointment
        {
            AppointmentId = 1,
            PatientId = 1001,
            DoctorId = 1,
            ReceptionistId = 5001,
            AppointmentDate = new DateTime(2025, 10, 25),
            AppointmentTime = new TimeSpan(14, 0, 0),
            AppointmentStatus = AppointmentStatus.SCHEDULED,
            Reason = "Bị sâu răng và muốn trám",
            CreatedAt = DateTime.Now
        }
    };

            context.Appointments.AddOrUpdate(a => a.AppointmentId, appointments.ToArray());
            context.SaveChanges();
        }
    }
}
