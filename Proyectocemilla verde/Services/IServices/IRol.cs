
using Domain.Dto;
using Domain.Entity;
using Proyectocemilla_verde.Services.Services;


namespace Proyectocemilla_verde.Services.IServices
{
    public interface IRol
    {
        public Task<Response<List<RolResponse>>> Obtener_Roles_BD();
        public Task<Response<RolResponse>> Ingresar_Rol_BD(RolResponse request);
    }
}
