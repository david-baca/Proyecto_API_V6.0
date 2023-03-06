using Domain.Dto;
using Domain.Entity;
using Proyectocemilla_verde.Services.IServices;
using static Proyectocemilla_verde.Context.Aplication_DB_Context;

namespace Proyectocemilla_verde.Services.Services
{
    public class PuestoServices : IPuesto
    {
        private readonly AplicationdbContext _context;
        public PuestoServices(AplicationdbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<PuestoResponse>>> Obtener_Puesto_BD()
        {
            //Extraemos de la base de datos todos los Puestos
            List<Puesto> BD = _context.Puestos.ToList();

            //Inicializamos una respuesta
            List<PuestoResponse> request = new List<PuestoResponse>();

            if (BD.Count == 0)
            {
                return new Response<List<PuestoResponse>>("No hay registros en la base de datos");
            }

            int No_puesto = 0;
            foreach (Puesto item in BD)
            {
                No_puesto++;
                PuestoResponse nuevo = new PuestoResponse(item, No_puesto);
                request.Add(nuevo);
            }
            return new Response<List<PuestoResponse>>(request);
        }

        public async Task<Response<PuestoResponse>> Ingresar_Puesto_BD(PuestoResponse request)
        {
            var list_puesto = _context.Puestos.ToList();
            request.NombrePuesto = request.NombrePuesto.ToUpper();
            request.No_Puesto = list_puesto.Count+1;

            if (_context.Puestos.Where(x => x.Name==request.NombrePuesto).FirstOrDefault() != null)
            {
                return new Response<PuestoResponse>("Ya esxise el Puesto "+ request.NombrePuesto);
            }

            Puesto nuevo = new Puesto()
            {
                Name = request.NombrePuesto
            };


            _context.Puestos.Add(nuevo);
            await _context.SaveChangesAsync();

            return new Response<PuestoResponse>(request);
        }
    }
}
