

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

            public DbSet<Cliente> Clientes { get; set; }
            public DbSet<Departamento> Departamentos { get; set; }
            public DbSet<Empleado> Empleados { get; set; }
            public DbSet<Factura> Facturas { get; set; }
            public DbSet<Puesto> Puestos { get; set; }
            public DbSet<Rol> Roles { get; set; }
            public DbSet<Usuario> Usuarios { get; set; }


        }
    }
}
