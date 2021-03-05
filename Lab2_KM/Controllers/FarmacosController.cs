using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2_KM.Utils;
using Lab2_KM.Models;

namespace Lab2_KM.Controllers
{
    public class FarmacosController : Controller
    {
        // GET: FarmacosController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DataFarmaco(string ID, string NOMBRE)
        {
            LstDoblementeEnlazada.Nodo<InventarioFarmacos> nodoFarmaco = new LstDoblementeEnlazada.Nodo<InventarioFarmacos>();

            nodoFarmaco = Storage.Instance.listaArtesanal.buscar(Storage.Instance.listaArtesanal.nodoRaiz, ID, Storage.Instance.listaArtesanal.nodoRaiz.elemento.compararFarmaco);
            nodoFarmaco.elemento.existencia--;

            if (nodoFarmaco.elemento.existencia >= 0)
            {
                Storage.Instance.listaFarmacos.Add(nodoFarmaco.elemento);
                return View("Index");

            }
            else {
                
                return View("Index");

            }
            
            
        }



    }
}
