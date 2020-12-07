using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bello.API
{
    public class BelloDbContext : IdentityDbContext
    {
        public BelloDbContext(DbContextOptions<BelloDbContext> options):base(options)
        {

        }
    }
}
