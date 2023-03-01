

namespace Domain.Dto
{
    public class UsuarioResponse
    {
        public string UserName { get; set; }
        public int Password { get; set; }
        public DateTime CrearDate { get; set; }
        public int? FKEmpleado { get; set; }
        public int? FkRol { get; set; }
    }
}
