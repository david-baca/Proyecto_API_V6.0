using Azure;
using Domain.Dto;
using Domain.Entity;
using Proyectocemilla_verde.Services.IServices;
using static Proyectocemilla_verde.Context.Aplication_DB_Context;

namespace Proyectocemilla_verde.Services.Services
{
    public class RolServices : IRol
    {
        private readonly AplicationdbContext _context;
        public RolServices(AplicationdbContext context)
        {
            _context = context;
        }

        public async Task< Response<RolResponse> > CrearRolBD(RolResponse request)
        {
            try
            {

                Rol nuevo = new Rol()
                {
                    NombreRol = request.NombreRol
                };
                _context.Roles.Add(nuevo);
                await _context.SaveChangesAsync();
                var x = new (request);
                return ;
            }
            catch (Exception ex)
            {
                throw new Exception("Alert -" + ex.Message);
            }
        }

        public async Task<List<Response<UsuarioResponse>>> ObtenerRolesenlaBD()
        {
            try
            {
                var roles = _context.Roles.ToList();
                List<RolResponse> lista = new List<RolResponse>();
                foreach (var element in roles)
                {
                    RolResponse nuevo = new RolResponse()
                    {
                        NombreRol = element.NombreRol
                    };
                    lista.Add(nuevo);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Alert -" + ex.Message);
            }
        }

    }
}
