using Azure;
using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyectocemilla_verde.Services.IServices;
using Proyectocemilla_verde.Services.Services;

namespace Proyectocemilla_verde.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolesController : Controller
    {
        private readonly IRol _RolServices;
        public RolesController(IRol RolServices)
        {
            _RolServices = RolServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetRoles()
        {
            try
            {
                return Ok(await _RolServices.Obtener_Roles_BD());
            }
            catch (Exception ex)
            {
                throw new Exception("Alert -" + ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult> CreateRol([FromBody] RolResponse i)

        {
            try
            {
                return Ok(await _RolServices.Ingresar_Rol_BD(i));
            }
            catch (Exception ex)
            {
                throw new Exception("Alert -" + ex.Message);
            }
        }

    }
}
