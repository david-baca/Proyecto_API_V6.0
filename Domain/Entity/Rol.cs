﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }

        public string NombreRol { get; set; }


    }
}
