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


        [HttpPost]
        public ActionResult<UsuarioResponse> CrearCliente([FromBody] UsuarioResponse i)
        {
            try
            {
                _UsuarioServices.CrearUsuarioenBD(i);
                return View();
            }
            catch(Exception ex)
            {
                throw new Exception("Alert -" + ex.Message);
            }
            
        }

        [HttpGet]
        public ActionResult<List<UsuarioResponse>> getUser()
        {
            try
            {
                _UsuarioServices.ObtenerUsuariosdelaBD();
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception("Alert -" + ex.Message);
            }
        }


    }
}
