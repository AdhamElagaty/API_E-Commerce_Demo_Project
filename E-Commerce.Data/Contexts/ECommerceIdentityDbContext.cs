using E_Commerce.Data.Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Data.Contexts
{
    public class ECommerceIdentityDbContext : IdentityDbContext<AppUser>
    {
        public ECommerceIdentityDbContext(DbContextOptions<ECommerceIdentityDbContext> options) : base(options)
        {
        }
    }
}
