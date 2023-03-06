using Domain.Dto;

namespace Proyectocemilla_verde.Services.IServices
{
    public interface ICliente
    {
        public Task<Response<List<ClienteResponse>>> Obtener_Cliente_BD();
        public Task<Response<ClienteResponse>> Ingresar_Cliente_BD(ClienteResponse request);
    }
}
