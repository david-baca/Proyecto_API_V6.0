using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class DepartamentoResponse
    {
        public DepartamentoResponse()
        {
        }

        public DepartamentoResponse(Departamento i, int no_rol)
        {
            No_Departamento = no_rol;
            NombreDepartamento = i.Name;
        }

        public int No_Departamento { get; set; }
        public string NombreDepartamento { get; set; }
    }
}
