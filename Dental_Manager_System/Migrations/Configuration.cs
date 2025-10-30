namespace Dental_Manager_System.Migrations
{
    using Dental_Manager.System.Models.Enums;
    using Dental_Manager_System.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Dental_Manager_System.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Dental_Manager_System.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // ====== 2. Tạo role ADMIN nếu chưa có ======
            string adminRole = RoleTitle.ADMIN.ToString();
            if (!roleManager.RoleExists(adminRole))
            {
                roleManager.Create(new IdentityRole(adminRole));
            }
            string adminEmail = "admin@dental.com";
            string adminPassword = "Admin@123"; // có thể đổi

            var adminUser = userManager.FindByEmail(adminEmail);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = userManager.Create(adminUser, adminPassword);
                if (!result.Succeeded)
                {
                    throw new Exception("Không thể tạo user admin: " + string.Join(", ", result.Errors));
                }
            }
            if (!userManager.IsInRole(adminUser.Id, adminRole))
            {
                userManager.AddToRole(adminUser.Id, adminRole);
            }

            context.SaveChanges();
        }

    }
}

