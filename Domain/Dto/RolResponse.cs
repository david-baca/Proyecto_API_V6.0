

using Domain.Entity;

namespace Domain.Dto
{

    public class RolResponse
    {
        public RolResponse()
        {
        }

        public RolResponse(Rol i, int no_rol)
        {
            NO_Rol = no_rol;
            NombreRol = i.NombreRol;
        }

        public int NO_Rol {get;set;}
        public string NombreRol { get; set; }
    }

}
