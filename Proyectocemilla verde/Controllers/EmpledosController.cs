using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyectocemilla_verde.Services.IServices;
using System.ComponentModel.DataAnnotations;

namespace Proyectocemilla_verde.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EmpledosController : Controller
    {
        private readonly IEmpleado _EmpledoServices;
        public EmpledosController(IEmpleado empleadoservices)
        {
            _EmpledoServices = empleadoservices;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmpledos()
        {
            try
            {
                return Ok(await _EmpledoServices.Obtener_Empleados_BD());
            }
            catch (Exception ex)
            {
                throw new Exception("Alert -" + ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult> CreateEmpleados([FromBody] EmpleadoResponse i)

        {
            try
            {
                return Ok(await _EmpledoServices.Ingresar_Empleados_BD(i));
            }
            catch (Exception ex)
            {
                throw new Exception("Alert -" + ex.Message);
            }
        }
    }
}
