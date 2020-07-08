using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult ProductoHTML()
        {
            ProductoImplementacion cs = new ProductoImplementacion();
            return View(cs.RecuperarTodos());
        }
    }
}