using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proiectChioranAndrei.Models;

namespace proiectChioranAndrei.Data
{
    public class proiectChioranAndreiContext : DbContext
    {
        public proiectChioranAndreiContext (DbContextOptions<proiectChioranAndreiContext> options)
            : base(options)
        {
        }

        public DbSet<proiectChioranAndrei.Models.ObiectivTuristic> ObiectivTuristic { get; set; } = default!;

        public DbSet<proiectChioranAndrei.Models.Oras>? Oras { get; set; }

        public DbSet<proiectChioranAndrei.Models.Tara>? Tara { get; set; }
    }
}
