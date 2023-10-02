using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class UsuarioDto
    {
        public int CodUsuario { get; set; }
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public string? Rol { get; set; }
        public int CodRol { get; set; }
        public bool Activo { get; set; }

    }
}
