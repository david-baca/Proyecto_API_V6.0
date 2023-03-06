using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyectocemilla_verde.Services.IServices;

namespace Proyectocemilla_verde.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : Controller
    {
        private readonly IDepartamento _DepartamentoServices;
        public DepartamentoController(IDepartamento DepartamentoServices)
        {
            _DepartamentoServices = DepartamentoServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetDepartamento()
        {
            try
            {
                return Ok(await _DepartamentoServices.Obtener_Departamento_BD());
            }
            catch (Exception ex)
            {
                throw new Exception("Alert -" + ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult> CreateDepartamento([FromBody] DepartamentoResponse i)

        {
            try
            {
                return Ok(await _DepartamentoServices.Ingresar_Departamento_BD(i));
            }
            catch (Exception ex)
            {
                throw new Exception("Alert -" + ex.Message);
            }
        }
    }
}
