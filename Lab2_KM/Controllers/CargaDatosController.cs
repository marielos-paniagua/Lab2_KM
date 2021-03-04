using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2_KM.Utils;
using System.IO;
using System.Threading.Tasks;
using LibFarmacos;
using Lab2_KM.Models;
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

        [HttpPost]
        public async Task<IActionResult> cargaArchivo(IFormFile file)
        {
            //Folde o Carpeta
            string csvFolder = Path.Combine(_hostingEnvironment.WebRootPath, "csv");
            // Nombre Archivo
            var fileName = string.Empty;

            var path = string.Empty;

            string filePath = "";


            if (file.Length > 0)
            {
                //wwwroot/csv/MoclUdata(4).csv
                filePath = Path.Combine(csvFolder, file.FileName);
                
                //MockData(4)
                fileName = Path.GetFileName(file.FileName);

                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    //Copia el archivo del servidor a la direccion fisica
                    await file.CopyToAsync(fileStream);
                }
            }

            Reader reader = new Reader(filePath);

            return RedirectToAction("listaArtesanal", "CargaDatos");
        }

        public ActionResult test() {
            FarmacoArbol test1 = new FarmacoArbol
            {
                id = 1,
                NombreFarmaco = "depo provera"
            };

            FarmacoArbol test2 = new FarmacoArbol
            {
                id = 2,
                NombreFarmaco = "Prueba 2"
            };


            Storage.Instance.ArbolB.insertar(test1, test1.CompararNombreF);

            return RedirectToAction("cargaArchivo", "CargaDatos");


        }
    }
}
