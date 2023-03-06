using Domain.Dto;

namespace Proyectocemilla_verde.Services.IServices
{
    public interface IPuesto
    {
        public Task<Response<List<PuestoResponse>>> Obtener_Puesto_BD();
        public Task<Response<PuestoResponse>> Ingresar_Puesto_BD(PuestoResponse request);
    }
}
