using Proyectocemilla_verde.Services.IServices;
using static Proyectocemilla_verde.Context.Aplication_DB_Context;

namespace Proyectocemilla_verde.Services.Services
{
    internal class FacturasServices : IFacturas
    {
        private readonly AplicationdbContext _context;
        public FacturasServices(AplicationdbContext context)
        {
            _context = context;
        }
    }
}
