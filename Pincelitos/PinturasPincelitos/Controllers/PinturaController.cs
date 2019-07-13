using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PinturasPincelitos.DAL;
using PinturasPincelitos.Models;
using System.Data;
using System.IO;

namespace PinturasPincelitos.Controllers
{
    public class PinturaController : Controller
    {
        // GET: Pintura
        public ActionResult Inicio()
        {
            return View();
        }
        public ActionResult QuienesSomos()
        {
            return View();
        }
        public ActionResult Contacto()
        {
            return View();
        }
        public ActionResult Vinilica()
        {
            return View();
        }
        public ActionResult Acrilica()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EnviarMensaje(string nombre, string correo, string asunto, string telefono, string mensaje)
        {
            MensajeDAL oMensajeDAL;
            oMensajeDAL = new MensajeDAL();
            if (ModelState.IsValid)
            {
                int Resp = 0;
                Resp = oMensajeDAL.Agregar(nombre, correo, asunto, telefono, mensaje);
                if (Resp == 1)
                {
                    TempData["Mensaje"] = "Los Datos se han actualizado con éxito";
                    return RedirectToAction("Contacto", "Pintura");
                }
                else
                {
                    ViewBag.error = "Al parecer hubo un Error";
                    return RedirectToAction("Contacto", "Pintura");
                }

            }
            else
            {
                ViewBag.error = "Al parecer hubo un Error";
                return RedirectToAction("Contacto", "Pintura");
            }
        }
    }
}