using Lab2_KM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lab2_KM.Utils;

using Microsoft.AspNetCore.Http;

namespace Lab2_KM.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //FarmacoArbol test1 = new FarmacoArbol
            //{
            //    id = 1,
            //    NombreFarmaco = "depo provera"
            //};

            //FarmacoArbol test2 = new FarmacoArbol
            //{
            //    id = 2,
            //    NombreFarmaco = "Prueba 2"
            //};


            //Storage.Instance.ArbolB.insertar(test1, test1.CompararNombreF);

            //Storage.Instance.ArbolB.insertar(test2, test2.CompararNombreF);

            return View();
        }

        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            return RedirectToAction("Create", "Home");
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var newClient = new Models.Client
                {
                    nombre = collection["nombre"],
                    apellido = collection["apellido"],
                    nit = Convert.ToInt32(collection["nit"])
                };
                Storage.Instance.ClientList.Add(newClient);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
