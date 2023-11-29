using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetAll();

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Error = result.ErrorMessage;
            }

            return View(usuario);
        }

        [HttpGet]
        public ActionResult Form(int? IdUsuario) 
        {
            ML.Usuario usuario = new ML.Usuario();

            if(IdUsuario != 0) // update
            {
                ML.Result result = BL.Usuario.GetById(IdUsuario.Value);
                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;
                }
                else
                {
                    ViewBag.Error = result.ErrorMessage;
                }
            }
            else //add
            {

            }
            
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            if (usuario.IdUsuario == 0) //add
            {
                ML.Result result = BL.Usuario.Add(usuario);
                if (result.Correct)
                {
                    ViewBag.Mensage = "Se incerto correctamente";
                }
                else
                {
                    ViewBag.Error = result.ErrorMessage;
                }
            }
            else //update
            {
                ML.Result result = BL.Usuario.Update(usuario);
                if(result.Correct)
                {
                    ViewBag.Mensage = "Se actualizo correectamente";
                }
                else
                {
                    ViewBag.Error = result.ErrorMessage;
                }
            }
            return PartialView("Modal");
        }

        public ActionResult Delete(int IdUsuario)
        {
            ML.Result result = BL.Usuario.Delete(IdUsuario);
            if (result.Correct)
            {
                ViewBag.Mensage = "Se elimino correctamente";
            }
            else
            {
                ViewBag.Error = result.ErrorMessage;
            }
            return PartialView("Modal");
        }
    }
}