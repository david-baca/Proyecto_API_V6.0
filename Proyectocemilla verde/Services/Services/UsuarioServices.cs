using Azure.Messaging;
using Domain.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Response<List<UsuarioResponse>>> Obtener_Usuario_BD()
        {
            //extraemos de la BD una lista de usuarios
            List<Usuario> BD = _context.Usuarios.Include(x=>x.Rol).Include(x=>x.Empleado)
                .Include(x=>x.Empleado.Puesto).Include(x=>x.Empleado.Departamento).ToList();
            //Inicializamos una respuesta
            List<UsuarioResponse> request = new List<UsuarioResponse>();

            if (BD.Count == 0)
            {
                return new Response<List<UsuarioResponse>>(request, "No hay registros en la base de datos");
            }

            foreach (Usuario item in BD)
            {
                UsuarioResponse nuevo = new UsuarioResponse(item);
                request.Add(nuevo);
            }
            return new Response<List<UsuarioResponse>>(request);
        }

        public async Task<Response<UsuarioResponse>> Ingresar_Usuario_BD(UsuarioResponse request)
        {
            var Rol = _context.Roles.Where(x => x.NombreRol == request.Rol).FirstOrDefault();
            var empleado = _context.Empleados.Find(request.FK_Empleado);
            if (Rol == null || empleado == null)
            {
                return new Response<UsuarioResponse>(request, "No existe el Rol '" + request.Rol + 
               "' o no existe el Empleado '"+ request.FK_Empleado+ "'"+
               "' En la base de datos; Cree las instancias o " + "verifique la forma de escritura");
            }

            Usuario nuevo = request.Convert(Rol);

            _context.Usuarios.Add(nuevo);
            await _context.SaveChangesAsync();

            return new Response<UsuarioResponse>(request);
        }

        public async Task<Response<UsuarioResponse>> Eliminar_Usuario_BD(int id)
        {
            Usuario BD = _context.Usuarios.Where(x=>x.Id == id).Include(x => x.Rol).Include(x => x.Empleado)
                .Include(x => x.Empleado.Puesto).Include(x => x.Empleado.Departamento).FirstOrDefault();
            
            if(BD == null)
            {
                return new Response<UsuarioResponse>("No existe en la base de datos el ID: "+id
                    +"Verifique la informacion");
            }
            UsuarioResponse requiest = new UsuarioResponse(BD);
            _context.Remove(BD);
            await _context.SaveChangesAsync();

            return new Response<UsuarioResponse>(requiest);
        }

        public async Task<Response<UsuarioResponse>> Editar_Usuario_BD(int id, UsuarioResponse request)
        {
            Usuario BD = _context.Usuarios.Where(x => x.Id == id).Include(x => x.Rol).Include(x => x.Empleado)
                .Include(x => x.Empleado.Puesto).Include(x => x.Empleado.Departamento).FirstOrDefault();

            if (BD == null)
            {
                return new Response<UsuarioResponse>("No existe en la base de datos el ID: "+id
                    +"Verifique la informacion");
            }
            Usuario editado = request.Comprobacion(BD);

            //despues de comprobar los campos nulos comprobamos la exsistancia de los atributos
            var Rol = _context.Roles.Where(x => x.NombreRol == editado.Rol.NombreRol).FirstOrDefault();
            var empleado = _context.Empleados.Find(editado.FKEmpleado);
            if (Rol == null || empleado == null)
            {
                return new Response<UsuarioResponse>(request, "No existe el Rol '" + request.Rol +
               "' o no existe el Empleado '"+ request.FK_Empleado+ "'"+
               "' En la base de datos; Cree las instancias o " + "verifique la forma de escritura");
            }
            request = new UsuarioResponse(editado);
            _context.Entry(editado).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return new Response<UsuarioResponse>(request);
        }


    }
}
