using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursusOverzichtApi.Models
{
    public class CursusContext : DbContext
    {
        public CursusContext(DbContextOptions<CursusContext> options)
            : base(options) {
        }

        public DbSet<Cursus> cursussen { get; set; }
        public DbSet<Cursusinstantie> cursusinstanties { get; set; }
    }
}
