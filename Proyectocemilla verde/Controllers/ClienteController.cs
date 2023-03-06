using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyectocemilla_verde.Services.IServices;

namespace Proyectocemilla_verde.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly ICliente _ClienteServices;
        public ClienteController(ICliente ClienteServices)
        {
            _ClienteServices = ClienteServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetCliente()
        {
            try
            {
                return Ok(await _ClienteServices.Obtener_Cliente_BD());
            }
            catch (Exception ex)
            {
                throw new Exception("Alert -" + ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult> CreateCliente ([FromBody] ClienteResponse i)

        {
            try
            {
                return Ok(await _ClienteServices.Ingresar_Cliente_BD(i));
            }
            catch (Exception ex)
            {
                throw new Exception("Alert -" + ex.Message);
            }
        }
    }
}
