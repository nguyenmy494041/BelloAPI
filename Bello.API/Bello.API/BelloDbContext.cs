using Bello.DAL.Implement;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bello.API
{
    public class BelloDbContext : IdentityDbContext<ApplicationUser>
    {
        public BelloDbContext(DbContextOptions<BelloDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
