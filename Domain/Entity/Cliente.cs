﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Cliente
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
