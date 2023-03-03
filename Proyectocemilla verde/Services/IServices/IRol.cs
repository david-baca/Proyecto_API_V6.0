
using Domain.Dto;
using Domain.Entity;
using Proyectocemilla_verde.Services.Services;


namespace Proyectocemilla_verde.Services.IServices
{
    public interface IRol
    {
        public Task<Response<RolResponse>> CrearRolBD(RolResponse request);

        public Task<List<Response<RolResponse>>> ObtenerRolesenlaBD();
    }
}
