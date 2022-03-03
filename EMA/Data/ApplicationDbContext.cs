using EMA.EntityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.Data
{
    public class ApplicationDbContext: IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Machine> Machine { get; set; }
        public DbSet<Sowing> Sowing { get; set; }
        public DbSet<Fertilizer> Fertilizer { get; set; }
        public DbSet<Harvesting> Harvesting { get; set; }
        public DbSet<InterCulture> InterCulture { get; set; }
        public DbSet<Irrigation> Irrigation { get; set; }
        public DbSet<PlantProtection> PlantProtection { get; set; }
        public DbSet<Production> Production { get; set; }
        public DbSet<FarmerDetail> FarmerDetail { get; set; }
        public DbSet<SeedBeed> SeedBeed { get; set; }

    }
}
