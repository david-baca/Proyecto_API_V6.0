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
        public ActionResult<Response<RolResponse>> CrearRol([FromBody] RolResponse i)
        {
            try
            {
                _RolServices.CrearRolBD(i);
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception("Alert -" + ex.Message);
            }

        }

        [HttpGet]
        public ActionResult<List < Response<RolResponse> > > getRol()
        {
            try
            {
                _RolServices.ObtenerRolesenlaBD();
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception("Alert -" + ex.Message);
            }
        }
    }
}
