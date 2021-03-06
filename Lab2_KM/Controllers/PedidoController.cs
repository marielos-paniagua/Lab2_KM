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
    public class PedidoController : Controller
    {
        // GET: PedidoController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            Pedido pedidoEntrate = new Pedido();
            pedidoEntrate.cliente = collection["Cliente"];
            pedidoEntrate.direccion = collection["Direccion"];
            pedidoEntrate.nit = collection["Nit"];

            Storage.Instance.listaFarmacos.Clear();

            return RedirectToAction("Index", "Farmacos");
        }


    }
}
