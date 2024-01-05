using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesRocket.Models;

namespace RazorPagesRocket.Data
{
    public class RazorPagesRocketContext : DbContext
    {
        public RazorPagesRocketContext (DbContextOptions<RazorPagesRocketContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesRocket.Models.Rocket> Rocket { get; set; } = default!;
    }
}
