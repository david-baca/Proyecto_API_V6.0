using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyectocemilla_verde.Services.Services;

namespace Proyectocemilla_verde.Services.IServices
{
    public interface IUsuario
    {
        public Task<Response<List<UsuarioResponse>>> Obtener_Usuario_BD();
        public Task<Response<UsuarioResponse>> Ingresar_Usuario_BD(UsuarioResponse request);
        public Task<Response<UsuarioResponse>> Eliminar_Usuario_BD(int id);
        public Task<Response<UsuarioResponse>> Editar_Usuario_BD(int id, UsuarioResponse request);
    }
}
