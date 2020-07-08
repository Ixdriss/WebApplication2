using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Alta()
        {
            return View();
        }
        public ActionResult DirigirProducto(FormCollection collection)
        {
            UsuarioImplementacion ma = new UsuarioImplementacion();
            Usuario usr = new Usuario
            {
                nombreUsuario = collection["Username"],
                contraseña= collection["Password"]
            };
            if (ma.LogIn(usr))
            {
                ProductoController pr = new ProductoController();
                return pr.ProductoHTML();
            }
            else { return RedirectToAction("Index"); }
        }
        [HttpPost]
        public ActionResult Alta(FormCollection collection)
        {
            UsuarioImplementacion ma = new UsuarioImplementacion();
            Usuario usr = new Usuario
            {
                nombreUsuario = collection["Username1"],
                contraseña = collection["Password1"]
            };
            ma.Alta(usr);
            return RedirectToAction("Index");
        }
    }
}
