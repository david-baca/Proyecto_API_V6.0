using Proyectocemilla_verde.Services.IServices;
using static Proyectocemilla_verde.Context.Aplication_DB_Context;

namespace Proyectocemilla_verde.Services.Services
{
    public class Departamento : IDepartamento
    {
        private readonly AplicationdbContext _context;
        public Departamento(AplicationdbContext context)
        {
            _context = context;
        }
    }
}
