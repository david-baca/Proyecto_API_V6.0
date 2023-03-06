using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyectocemilla_verde.Services.IServices;

namespace Proyectocemilla_verde.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PuestoController : Controller
    {
        private readonly IPuesto _PuestoServices;
        public PuestoController(IPuesto PuestoServices)
        {
            _PuestoServices = PuestoServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetPuestos()
        {
            try
            {
                return Ok(await _PuestoServices.Obtener_Puesto_BD());
            }
            catch (Exception ex)
            {
                throw new Exception("Alert -" + ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult> CreatePuesto([FromBody] PuestoResponse i)

        {
            try
            {
                return Ok(await _PuestoServices.Ingresar_Puesto_BD(i));
            }
            catch (Exception ex)
            {
                throw new Exception("Alert -" + ex.Message);
            }
        }
    }
}
