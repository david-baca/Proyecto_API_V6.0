using Domain.Dto;

namespace Proyectocemilla_verde.Services.IServices
{
    public interface IDepartamento
    {
        public Task<Response<List<DepartamentoResponse>>> Obtener_Departamento_BD();
        public Task<Response<DepartamentoResponse>> Ingresar_Departamento_BD(DepartamentoResponse request);
    }
}
