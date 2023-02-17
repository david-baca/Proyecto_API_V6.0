
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Proyectocemilla_verde.Context
{
    public class Aplication_DB_Context
    {
        public class AplicationdbContext : DbContext
        {
            public AplicationdbContext(DbContextOptions<AplicationdbContext> options) : base(options)
            {
                //public DbSet<Usuario> Usuario { get; set; }
            }
            public DbSet<Empledo> Empledos { get; set; }
        }
    }
}
