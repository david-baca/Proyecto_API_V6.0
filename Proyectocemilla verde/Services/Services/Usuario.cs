using Proyectocemilla_verde.Services.IServices;
using static Proyectocemilla_verde.Context.Aplication_DB_Context;

namespace Proyectocemilla_verde.Services.Services
{
    public class Usuario : IUsuario
    {
        private readonly AplicationdbContext _context;
        public Usuario(AplicationdbContext context)
        {
            _context = context;
        }
    }
}
