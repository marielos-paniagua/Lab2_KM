using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_KM.Controllers
{
    public class FarmacosController : Controller
    {
        // GET: FarmacosController
        public ActionResult Index()
        {
            return View();
        }

        
    }
}
