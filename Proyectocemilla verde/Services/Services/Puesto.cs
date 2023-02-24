using Proyectocemilla_verde.Services.IServices;
using static Proyectocemilla_verde.Context.Aplication_DB_Context;

namespace Proyectocemilla_verde.Services.Services
{
    public class Puesto : IPuesto
    {
        private readonly AplicationdbContext _context;
        public Puesto(AplicationdbContext context)
        {
            _context = context;
        }
    }
}
