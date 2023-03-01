using Domain.Dto;
using Proyectocemilla_verde.Services.Services;

namespace Proyectocemilla_verde.Services.IServices
{
    public interface IRol
    {
        public Task<RolResponse> CrearRolBD(RolResponse request);

        public Task<List<RolResponse>> ObtenerRolesenlaBD();
    }
}
