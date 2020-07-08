using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Usuario
    {
        public int id_Usuario { get; set; }
        public string nombreUsuario { get; set; }
        public string contraseña { get; set; }
    }
}