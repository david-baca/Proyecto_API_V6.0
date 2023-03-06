using Domain.Dto;
using Domain.Entity;
using Proyectocemilla_verde.Context;
using Proyectocemilla_verde.Services.IServices;
using static Proyectocemilla_verde.Context.Aplication_DB_Context;

namespace Proyectocemilla_verde.Services.Services
{
    internal class ClienteServices : ICliente
    {
        private readonly AplicationdbContext _context;
        public ClienteServices (AplicationdbContext context)
        {
            _context = context;
        }
        public async Task<Response<List<ClienteResponse>>> Obtener_Cliente_BD()
        {
            //Extraemos de la base de datos todos los clientes
            List<Cliente> BD = _context.Clientes.ToList();

            //Inicializamos una respuesta
            List<ClienteResponse> request = new List<ClienteResponse>();

            if (BD.Count == 0)
            {
                return new Response<List<ClienteResponse>>(request, "No hay registros en la base de datos");
            }
            int no_cliente = 0;
            foreach (Cliente item in BD)
            {
                no_cliente++;
                ClienteResponse nuevo = new ClienteResponse(item, no_cliente);
                request.Add(nuevo);
            }
            return new Response<List<ClienteResponse>>(request);
        }

        public async Task<Response<ClienteResponse>> Ingresar_Cliente_BD(ClienteResponse request)
        {
            var list_clientes = _context.Clientes.ToList();
            request.Nombre = request.Nombre.ToUpper();
            request.No_Cliente = list_clientes.Count+1;

            if (_context.Clientes.Where(x => x.Name == request.Nombre).FirstOrDefault() != null)
            {
                return new Response<ClienteResponse>("Ya esxise el Cliente "+request.Nombre);
            }

            Cliente nuevo = new Cliente()
            {
                Name = request.Nombre
            };


            _context.Clientes.Add(nuevo);
            await _context.SaveChangesAsync();

            return new Response<ClienteResponse>(request);
        }

    }
}
