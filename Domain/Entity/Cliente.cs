using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    internal class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string email { get; set; }
        public string Direccion { get; set; }


    }
}
