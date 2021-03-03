using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2_KM.Utils;
using System.IO;
using System.Threading.Tasks;
using LstDoblementeEnlazada;
using Microsoft.AspNetCore.Hosting;

namespace Lab2_KM.Controllers
{
    public class CargaDatosController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public CargaDatosController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult cargaArchivo()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            return RedirectToAction("cargaArchivo", "CargaDatos");
        }

        [HttpPost]
        public async Task<IActionResult> cargaArchivo(IFormFile file)
        {

            string csvFolder = Path.Combine(_hostingEnvironment.WebRootPath, "csv");
            var fileName = string.Empty;
            var path = string.Empty;
            string filePath = "";

            if (file.Length > 0)
            {
                filePath = Path.Combine(csvFolder, file.FileName);
                fileName = Path.GetFileName(file.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }

            Reader reader = new Reader(filePath);
            
            return RedirectToAction("listaArtesanal", "Cliente");
        }

        [HttpPost]
        public ActionResult DatosManuales(IFormCollection collection)
        {

            string id = collection["id"];
            string nombre = collection["nombre"];
            string descripcion = collection["descripcion"];
            string casa = collection["casa_productora"];
            string precio = collection["precio"];
            string existencia = collection["existencia"];

            Nodo<string> nodocliente = new Nodo<string>
            {
                id = id,
                nombre = nombre,
                descripcion = descripcion,
                casa_productora = casa,
                precio = precio,
                existencia = existencia
            };

                Storage.Instance.listaArtesanal.InsertarEnLista(
                Storage.Instance.listaArtesanal.nodoRaiz,
                Storage.Instance.listaArtesanal.nodoRaiz,
                nodocliente);

                Storage.Instance.listaArtesanal.cantidadElementos();

            return RedirectToAction("cargaManual", "CargaDatos");
        }
    }
}
