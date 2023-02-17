using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    internal class Facturas
    {
        [Key]
        public int FacturasId { get; set; }
        [Required]
        public string Razon_Social { get; set; }
        [Required]
        public string Feche { get; set; }
        [Required]
        public string RFC { get; set; }

        [ForeignKey("Cliente")]
        public int? Fkcliente { get; set; }
        Cliente clieente = new Cliente();
    }
}
