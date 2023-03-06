using Domain.Entity;

namespace Domain.Dto
{
    public class UsuarioResponse
    {
        public UsuarioResponse()
        {
        }

        public UsuarioResponse(Usuario i)
        {
            PK_Usuario = i.Id;
            Nombre_Usuario = i.UserName;
            Contraseña = i.Password;
            Rol = i.Rol.NombreRol;
            FK_Empleado = i.Empleado.Id;
            Empleado = new EmpleadoResponse(i.Empleado);
        }

        public Usuario Convert(Rol r)
        {
            Usuario i = new Usuario()
            {
                Id = PK_Usuario,
                UserName = Nombre_Usuario,
                Password = Contraseña,
                FkRol = r.Id,
                FKEmpleado = FK_Empleado
            };
            return i;
        }

        public Usuario Comprobacion(Usuario BD)
        {
            if (PK_Usuario != 0) BD.Id = PK_Usuario ;
            if (Nombre_Usuario != "string") BD.UserName = Nombre_Usuario;
            if (Contraseña != "string") BD.Password = Contraseña;
            if (Rol != "string") BD.Rol.NombreRol = Rol;
            if (FK_Empleado != 0) BD.Empleado.Id = FK_Empleado;
            return BD;
        }

        
        public int PK_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }
        public EmpleadoResponse? Empleado { get;}

        public int FK_Empleado { get; set; }
        //se puede buscar empleado por el numero de lista que se optine con GetEmpledos
        //Se requiere que ya se haya creado con anterioridad un empledo
    }
}
