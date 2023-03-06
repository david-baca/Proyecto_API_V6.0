using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class EmpleadoResponse
    {
        public EmpleadoResponse()
        {
        }

        public EmpleadoResponse(Empleado i)
        {
            PK_Empleado = i.Id;
            Apellido = i.Apellidos;
            Nombre = i.Name;
            Nombre_Puesto = i.Puesto.Name;
            Nombre_Departamento = i.Departamento.Name;
        }


        public Empleado Convert(Departamento d, Puesto p)
        {
            Empleado i = new Empleado()
            {
                Id = PK_Empleado,
                Name = Nombre,
                Apellidos = Apellido,
                FKdepartamento = d.Id,
                FKpuesto = p.Id
            };
            return i;
        }

        public int PK_Empleado { get; set; }
        public string Nombre_Departamento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nombre_Puesto { get; set; }
    }
}
