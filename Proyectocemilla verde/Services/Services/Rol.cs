﻿using Proyectocemilla_verde.Services.IServices;
using static Proyectocemilla_verde.Context.Aplication_DB_Context;

namespace Proyectocemilla_verde.Services.Services
{
    public class Rol : IRol
    {
        private readonly AplicationdbContext _context;
        public Rol(AplicationdbContext context)
        {
            _context = context;
        }
    }
}
