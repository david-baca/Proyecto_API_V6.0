using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyectocemilla_verde.Services.Services;

namespace Proyectocemilla_verde.Services.IServices
{
    public interface IUsuario
    {
        public Task<UsuarioResponse> CrearUsuarioenBD(UsuarioResponse request);

        public Task<List<UsuarioResponse>> ObtenerUsuariosdelaBD();
    }
}
