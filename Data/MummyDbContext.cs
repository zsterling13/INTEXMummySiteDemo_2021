using INTEX2Mock.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2Mock.Data
{
    public class MummyDbContext : IdentityDbContext
    {
        public MummyDbContext(DbContextOptions<MummyDbContext> options)
            : base(options)
        {

        }

        public DbSet<Mummy> Mummies { get; set; }
    }
}
