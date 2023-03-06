using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyectocemilla_verde.Services.IServices;
using Proyectocemilla_verde.Services.Services;

namespace Proyectocemilla_verde.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UsuariosController : Controller
    {
        private readonly IUsuario _UsuarioServices;
        public UsuariosController(IUsuario UsuariosServices)
        {
            _UsuarioServices = UsuariosServices;
        } 

        [HttpGet]
        public async Task<ActionResult> GetUsuarios()
        {
            try
            {
                return Ok(await _UsuarioServices.Obtener_Usuario_BD());
            }
            catch (Exception ex)
            {
                throw new Exception("Alert -" + ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult> CreateUsuario([FromBody] UsuarioResponse i)

        {
            try
            {
                return Ok(await _UsuarioServices.Ingresar_Usuario_BD(i));
            }
            catch (Exception ex)
            {
                throw new Exception("Alert -" + ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> EliminarUsuario(int id)
        {
            try
            {
                return Ok(await _UsuarioServices.Eliminar_Usuario_BD(id));
            }
            catch (Exception ex)
            {
                throw new Exception("Alert -" + ex.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult> Editar_Usuario_BD(int id, [FromBody] UsuarioResponse i)
        {
            try
            {
                return Ok(await _UsuarioServices.Editar_Usuario_BD(id,i));
            }
            catch (Exception ex)
            {
                throw new Exception("Alert -" + ex.Message);
            }
        }


    }
}
