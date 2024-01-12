using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CabinetStomatologic.Models;

namespace CabinetStomatologic.Data
{
    public class CabinetStomatologicContext : DbContext
    {
        public CabinetStomatologicContext (DbContextOptions<CabinetStomatologicContext> options)
            : base(options)
        {
        }

        public DbSet<CabinetStomatologic.Models.Cabinet> Cabinet { get; set; } = default!;

        public DbSet<CabinetStomatologic.Models.Doctor>? Doctor { get; set; }

        public DbSet<CabinetStomatologic.Models.Pacient>? Pacient { get; set; }

        public DbSet<CabinetStomatologic.Models.Specializare>? Specializare { get; set; }

        public DbSet<CabinetStomatologic.Models.Programare>? Programare { get; set; }
    }
}
