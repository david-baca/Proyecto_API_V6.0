using Proyectocemilla_verde.Context;
using Proyectocemilla_verde.Services.IServices;
using static Proyectocemilla_verde.Context.Aplication_DB_Context;

namespace Proyectocemilla_verde.Services.Services
{
    internal class Cliente : ICliente
    {
        private readonly AplicationdbContext _context;
        public Cliente (AplicationdbContext context)
        {
            _context = context;
        }
    }
}
