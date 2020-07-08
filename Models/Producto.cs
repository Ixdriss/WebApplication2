using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Producto
    {
        public int id_Producto { get; set; }
        public String nombreProducto { get; set; }
        public Double precioProducto { get; set; }
        public String categoriaProducto { get; set; }

    }
}