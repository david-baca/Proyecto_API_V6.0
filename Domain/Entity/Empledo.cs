using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Empledo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Apellidos { get; set; }


        [ForeignKey("Puesto")]
        public int? FKpuesto { get; set; }

        [ForeignKey("Departamento")]
        public int? FKdepartamento { get; set; }


        public Puesto Puesto { get; set; }
        public Departamento Departamento { get; set; }
    }
}
