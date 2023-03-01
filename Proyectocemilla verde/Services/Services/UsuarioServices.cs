using Azure.Messaging;
using Domain.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Proyectocemilla_verde.Services.IServices;
using System.Collections.Generic;
using System.Net;
using static Proyectocemilla_verde.Context.Aplication_DB_Context;

namespace Proyectocemilla_verde.Services.Services
{
    public class UsuarioServices : IUsuario
    {
        private readonly AplicationdbContext _context;
        public UsuarioServices(AplicationdbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioResponse> CrearUsuarioenBD(UsuarioResponse request)
        {
            try
            {
                if(request == null)
                {
                    throw new ArgumentNullException(nameof(request));
                }

                Usuario nuevo = new Usuario()
                {
                    UserName = request.UserName,
                    Password = request.Password,
                    CreatedDate = request.CrearDate,
                    FKEmpleado = request.FKEmpleado,
                    FkRol = request.FkRol
                };
                _context.Usuarios.Add(nuevo);
                await _context.SaveChangesAsync();

                return request;
            }
            catch(Exception ex)
            {
                throw new Exception("Alert -" + ex.Message);
            }
        }

        public async Task<List<UsuarioResponse>> ObtenerUsuariosdelaBD()
        {
            try
            {
                var Usuarios = _context.Usuarios.ToList();
                List<UsuarioResponse> lista = new List<UsuarioResponse>();
                foreach (var element in Usuarios)
                {
                    UsuarioResponse nuevo = new UsuarioResponse()
                    {
                        UserName = element.UserName,
                        Password = element.Password,
                        CrearDate = element.CreatedDate,
                        FKEmpleado = element.FKEmpleado,
                        FkRol = element.FkRol
                    };
                    lista.Add(nuevo);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Alert -" + ex.Message);
            }
        }


    }
}
