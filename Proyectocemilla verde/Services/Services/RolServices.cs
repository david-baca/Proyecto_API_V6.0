using Azure.Core;
using Domain.Dto;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Response<RolResponse>> CrearRolBD(RolResponse request)
        {
            try
            {
                if(request == null)
                {
                    return new Response<RolResponse>(request, "no puede estar vacio");
                }

                Rol nuevo = new Rol()
                {
                    NombreRol = request.NombreRol
                };
                _context.Roles.Add(nuevo);
                await _context.SaveChangesAsync();

                return new Response<RolResponse>(request, "Se creo");
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }

        public async Task<List<Response<RolResponse>>> ObtenerRolesenlaBD()
        {
            try
            {
                var roles = _context.Roles.ToListAsync();
                if (roles)
                {
                    return new Response<RolResponse>(request, "no puede estar vacio");
                }

                List<Response<RolResponse>> lista = new List<Response<RolResponse>>();
                foreach (var element in roles)
                {
                    RolResponse nuevo = new RolResponse()
                    {
                        NombreRol = element.NombreRol
                    };
                    Response<RolResponse> nuevo2 = new Response<RolResponse>(nuevo);
                    lista.Add(nuevo2);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }

    }
}
