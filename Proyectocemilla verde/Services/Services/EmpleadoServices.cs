using Azure.Core;
using Domain.Dto;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Proyectocemilla_verde.Services.IServices;
using static Proyectocemilla_verde.Context.Aplication_DB_Context;

namespace Proyectocemilla_verde.Services.Services
{
    public class EmpleadoServices : IEmpleado
    {
        private readonly AplicationdbContext _context;
        public EmpleadoServices(AplicationdbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<EmpleadoResponse>>> Obtener_Empleados_BD()
        {
            //Extraemos de la base de datos todos los empleados
            List<Empleado> BD = _context.Empleados.Include(x=>x.Puesto).Include(x=>x.Departamento).ToList();

            //Inicializamos una respuesta
            List<EmpleadoResponse> request = new List<EmpleadoResponse>();

            if(BD.Count == 0)
            {
                return new Response<List<EmpleadoResponse>>(request, "No hay registros en la base de datos");
            }
            foreach(Empleado emplado in BD)
            {
                EmpleadoResponse nuevo = new EmpleadoResponse(emplado);
                request.Add(nuevo);
            }

            return new Response<List<EmpleadoResponse>>(request);
        }

        public async Task<Response<EmpleadoResponse>> Ingresar_Empleados_BD(EmpleadoResponse request)
        {
            var puesto = _context.Puestos.Where(x => x.Name == request.Nombre_Puesto).FirstOrDefault();
            var departamento = _context.Departamentos.Where(x => x.Name == request.Nombre_Departamento).FirstOrDefault();
            if (puesto == null || departamento == null)
            {
                return new Response<EmpleadoResponse>(request, "No existe el departamento '" + request.Nombre_Departamento + 
               "' o  el puesto '"+ request.Nombre_Puesto + "' En la base de datos Creelas instancias o " +
               "verifique la forma de escritura");
            }

            Empleado nuevo = request.Convert(departamento, puesto);

            _context.Empleados.Add(nuevo);
            await _context.SaveChangesAsync();

            return new Response<EmpleadoResponse>(request);
        }
    }
}
