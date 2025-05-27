using SkinShopAPI.Models;
using System;

namespace SkinShopAPI.Data
{
    public static class DbSeeder
    {
        public static void SeedRoles(SkincareShopForMenContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                new Role { RoleName = "Admin" },
                new Role { RoleName = "Staff" },
                new Role { RoleName = "Customer" }
          

                );
                context.SaveChanges();
            }
        }
    }
}
