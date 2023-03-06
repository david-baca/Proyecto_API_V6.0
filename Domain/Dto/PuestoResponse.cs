using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class PuestoResponse
    {
        public PuestoResponse()
        {
        }

        public PuestoResponse(Puesto i, int no_puesto)
        {
            No_Puesto = no_puesto;
            NombrePuesto = i.Name;
        }

        public int No_Puesto { get; set; }
        public string NombrePuesto { get; set; }
    }
}
