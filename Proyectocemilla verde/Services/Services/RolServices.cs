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


        public async Task<Response<List<RolResponse>>> Obtener_Roles_BD()
        {
            //Extraemos de la base de datos todos los empleados
            List<Rol> BD = _context.Roles.ToList();

            //Inicializamos una respuesta
            List<RolResponse> request = new List<RolResponse>();

            if (BD.Count == 0)
            {
                return new Response<List<RolResponse>>(request, "No hay registros en la base de datos");
            }
            int no_Rol = 0;
            foreach (Rol item in BD)
            {
                no_Rol++;
                RolResponse nuevo = new RolResponse(item, no_Rol);
                request.Add(nuevo);
            }
            return new Response<List<RolResponse>>(request);
        }

        public async Task<Response<RolResponse>> Ingresar_Rol_BD(RolResponse request)
        {
            var no_Rol = _context.Roles.ToList();
            request.NombreRol = request.NombreRol.ToUpper();
            request.NO_Rol = no_Rol.Count+1;

            if (_context.Roles.Where(x=>x.NombreRol==request.NombreRol).FirstOrDefault() != null)
            {
                return new Response<RolResponse>("Ya esxise el Rol "+request.NombreRol);
            }

            Rol nuevo = new Rol()
            {
                NombreRol = request.NombreRol
            };


            _context.Roles.Add(nuevo);
            await _context.SaveChangesAsync();

            return new Response<RolResponse>(request);
        }


    }
}
