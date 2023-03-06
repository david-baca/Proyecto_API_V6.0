using Domain.Dto;
using Domain.Entity;

namespace Proyectocemilla_verde.Services.IServices
{
    public interface IEmpleado
    {
        public Task< Response<List<EmpleadoResponse>> > Obtener_Empleados_BD();
        public Task<Response<EmpleadoResponse>> Ingresar_Empleados_BD(EmpleadoResponse request);
    }
}
