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

        [HttpPost]
        public async Task<ActionResult> CrearRol([FromBody] RolResponse i)
        {
            try
            {
                return Ok(await _RolServices.CrearRolBD(i));
            }
            catch (Exception ex)
            {
                throw new Exception("Alert -" + ex.Message);
            }

        }

        [HttpGet]
        public async Task<ActionResult> getRol()
        {
             return Ok(await _RolServices.ObtenerRolesenlaBD());
        }
    }
}
