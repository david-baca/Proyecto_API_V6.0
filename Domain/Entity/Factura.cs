using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Factura
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

        public Cliente Cliente { get; set; }
    }
}
