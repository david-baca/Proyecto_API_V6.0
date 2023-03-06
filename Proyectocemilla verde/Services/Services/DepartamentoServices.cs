using Domain.Dto;
using Domain.Entity;
using Proyectocemilla_verde.Services.IServices;
using static Proyectocemilla_verde.Context.Aplication_DB_Context;

namespace Proyectocemilla_verde.Services.Services
{
    public class DepartamentoServices : IDepartamento
    {
        private readonly AplicationdbContext _context;
        public DepartamentoServices(AplicationdbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<DepartamentoResponse>>> Obtener_Departamento_BD()
        {
            //Extraemos de la base de datos todos los empleados
            List<Departamento> BD = _context.Departamentos.ToList();

            //Inicializamos una respuesta
            List<DepartamentoResponse> request = new List<DepartamentoResponse>();

            if (BD.Count == 0)
            {
                return new Response<List<DepartamentoResponse>>(request, "No hay registros en la base de datos");
            }
            int no_Rol = 0;
            foreach (Departamento item in BD)
            {
                no_Rol++;
                DepartamentoResponse nuevo = new DepartamentoResponse(item, no_Rol);
                request.Add(nuevo);
            }
            return new Response<List<DepartamentoResponse>>(request);
        }

        public async Task<Response<DepartamentoResponse>> Ingresar_Departamento_BD(DepartamentoResponse request)
        {
            var List_Departamentos = _context.Departamentos.ToList();
            request.NombreDepartamento = request.NombreDepartamento.ToUpper();
            request.No_Departamento = List_Departamentos.Count+1;

            if (_context.Departamentos.Where(x => x.Name == request.NombreDepartamento).FirstOrDefault() != null)
            {
                return new Response<DepartamentoResponse>("Ya esxise el Departamento "+request.NombreDepartamento);
            }

            Departamento nuevo = new Departamento()
            {
                Name = request.NombreDepartamento
            };


            _context.Departamentos.Add(nuevo);
            await _context.SaveChangesAsync();

            return new Response<DepartamentoResponse>(request);
        }
    }
}
