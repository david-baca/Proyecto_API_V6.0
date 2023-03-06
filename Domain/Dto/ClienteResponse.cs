

using Domain.Entity;

namespace Domain.Dto
{
    public class ClienteResponse
    {
        public ClienteResponse()
        {
        }

        public ClienteResponse(Cliente i, int no_cliente)
        {
            No_Cliente = no_cliente;
            Nombre = i.Name;
            Apellido = i.Apellido;
            Telefono = i.Telefono;
            Email = i.email;
            Direccion = i.Direccion;
        }

        public int No_Cliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
    }
}
