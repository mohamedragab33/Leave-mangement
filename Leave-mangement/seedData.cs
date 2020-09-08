using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_mangement
{
    public static class seedData
    {
        public static void seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) {

            seedRoles(roleManager);
            seedUsers(userManager);




        }

        private static void seedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("Admin").Result == null) {

                var user = new IdentityUser()
                {

                    UserName = "admin@localhost.com",
                    Email = "admin@localhost.com"


                };
                var reslut = userManager.CreateAsync(user, "P@ssword1").Result;
                if (reslut.Succeeded) {

                    userManager.AddToRoleAsync(user, "Adminstrator").Wait();
                
                }
            
            } 


        }




        private static void seedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Adminstrator").Result) {

                var role = new IdentityRole()
                {

                    Name = "Adminstrator"
                };

            var result = roleManager.CreateAsync(role).Result;
            
            }
            if (!roleManager.RoleExistsAsync("Employee").Result)
            {

                var role = new IdentityRole()
                {

                    Name = "Employee"
                };

                var result = roleManager.CreateAsync(role).Result;

            }
        }

    }
}
