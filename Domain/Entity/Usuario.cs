using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Password { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("Empleado")]
        public int? FKEmpleado { get; set; }

        [ForeignKey("Rol")]
        public int? FkRol { get; set; }

        public Rol Rol { get; set; }
        public Empledo Empleado { get; set; }

        
    }
}
