using E_Commerce.Data.Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository
{
    public class ECommerceIdentityContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Adham Elagaty",
                    Email = "adhamalagaty@gmail.com",
                    UserName = "AdhamElagaty",
                    Address = new Address
                    {
                        FirstName = "Adham",
                        LastName = "Elagaty",
                        Street = "456",
                        City = "Giza",
                        State = "Cairo",
                        PostalCode = "12345"
                    }
                };
                await userManager.CreateAsync(user, "Password123!");
            }
        }
    }
}
