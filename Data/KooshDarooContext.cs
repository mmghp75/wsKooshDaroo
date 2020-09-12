using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wsKooshDaroo.Models;

namespace wsKooshDaroo.Data
{
    public class KooshDarooContext : DbContext
    {
        public KooshDarooContext (DbContextOptions<KooshDarooContext> options)
            : base(options)
        {
        }

        public DbSet<wsKooshDaroo.Models.Member> Member { get; set; }

        public DbSet<wsKooshDaroo.Models.Prescribe> Prescribe { get; set; }

        public DbSet<wsKooshDaroo.Models.PrescribeResource> PrescribeResource { get; set; }

        public DbSet<wsKooshDaroo.Models.Pharmacy> Pharmacy { get; set; }

        public DbSet<wsKooshDaroo.Models.PharmacyConnection> PharmacyConnection { get; set; }

        public DbSet<wsKooshDaroo.Models.PrescribeItem> PrescribeItem { get; set; }
    }
}
