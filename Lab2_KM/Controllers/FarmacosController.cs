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
        public ActionResult Index(int page = 1)
        {
            if (Storage.Instance.ArbolB.listaInOrder.Count > 0)
            {
                Storage.Instance.ArbolB.listaInOrder.Clear();
            }
            
            Storage.Instance.ArbolB.InOrder(Storage.Instance.ArbolB.padre);
            var paginacionFarmacos = new paginacion
            {
                farmacosPorPagina = 50,
                farmacos = Storage.Instance.ArbolB.listaInOrder,
                paginaActual = page
            };

            Storage.Instance.pagination = paginacionFarmacos;
            return View("Index", Storage.Instance.pagination);
        }

        [HttpGet]
        public ActionResult DataFarmaco(string ID, string NOMBRE)
        {
            LstDoblementeEnlazada.Nodo<InventarioFarmacos> nodoFarmaco = new LstDoblementeEnlazada.Nodo<InventarioFarmacos>();

            nodoFarmaco = Storage.Instance.listaArtesanal.buscar(Storage.Instance.listaArtesanal.nodoRaiz, ID, Storage.Instance.listaArtesanal.nodoRaiz.elemento.compararFarmaco);
            

            if (nodoFarmaco.elemento.existencia > 0)
            {
                nodoFarmaco.elemento.existencia--;
                Storage.Instance.listaFarmacos.Add(nodoFarmaco.elemento);
                return View("Index", Storage.Instance.pagination);

            }
            else {
                
                return View("Index", Storage.Instance.pagination);

            }
            
            
        }

        public ActionResult buscarFarmaco() {
            return View();
        }

        [HttpPost]
        public ActionResult buscarFarmaco(IFormCollection collection)
        {
            string busqueda = collection["Busqueda"];


            LibFarmacos.Nodo<FarmacoArbol> nodoFarmacoEncontrado = Storage.Instance.ArbolB.Buscar(Storage.Instance.ArbolB.padre,
                busqueda, Storage.Instance.ArbolB.padre.valorFarmaco.buscarFarmacoBinario);

            LstDoblementeEnlazada.Nodo<InventarioFarmacos> Busqueda = Storage.Instance.listaArtesanal.buscar(Storage.Instance.listaArtesanal.nodoRaiz,
                nodoFarmacoEncontrado.valorFarmaco.id, Storage.Instance.listaArtesanal.nodoRaiz.elemento.compararFarmaco);

            
            return View("ResultadoBusqueda", Busqueda.elemento);
        }


        [HttpGet]
        public ActionResult abastecerFarmaco(string nombreFarmaco)
        {
            LibFarmacos.Nodo<FarmacoArbol> nodoFarmacoEncontrado = Storage.Instance.ArbolB.Buscar(Storage.Instance.ArbolB.padre,
               nombreFarmaco, Storage.Instance.ArbolB.padre.valorFarmaco.buscarFarmacoBinario);
            

            LstDoblementeEnlazada.Nodo<InventarioFarmacos> Busqueda = Storage.Instance.listaArtesanal.buscar(Storage.Instance.listaArtesanal.nodoRaiz,
                nodoFarmacoEncontrado.valorFarmaco.id, Storage.Instance.listaArtesanal.nodoRaiz.elemento.compararFarmaco);

            return View("abastecer", Busqueda.elemento);
        }


        [HttpPost]
        public ActionResult abastecerFarmaco(string NOMBRE, IFormCollection collection)
        {
            
            int existencia = int.Parse(collection["Existencia"]);


            LibFarmacos.Nodo<FarmacoArbol> nodoFarmacoEncontradoAux = Storage.Instance.ArbolB.Buscar(Storage.Instance.ArbolB.padre,
               NOMBRE, Storage.Instance.ArbolB.padre.valorFarmaco.buscarFarmacoBinario);

            LibFarmacos.Nodo<FarmacoArbol> nodoFarmacoEncontrado = Storage.Instance.ArbolB.Buscar(Storage.Instance.ArbolB.padre,
               NOMBRE, Storage.Instance.ArbolB.padre.valorFarmaco.buscarFarmacoBinario);

            LstDoblementeEnlazada.Nodo<InventarioFarmacos> Busqueda = Storage.Instance.listaArtesanal.buscar(Storage.Instance.listaArtesanal.nodoRaiz,
                nodoFarmacoEncontrado.valorFarmaco.id, Storage.Instance.listaArtesanal.nodoRaiz.elemento.compararFarmaco);

            Busqueda.elemento.existencia = existencia;

            FarmacoArbol nodoAuxiliar = new FarmacoArbol();



            nodoAuxiliar.id = nodoFarmacoEncontrado.valorFarmaco.id;
            nodoAuxiliar.NombreFarmaco = nodoFarmacoEncontrado.valorFarmaco.NombreFarmaco;

           

            // Eliminacion del farmaco del arbol B
            Storage.Instance.ArbolB.Eliminar(Busqueda.elemento.NombreFarmaco, 
                Storage.Instance.ArbolB.padre.valorFarmaco.buscarEliminacionFarmacoBinario);


           

            Storage.Instance.ArbolB.insertar(nodoAuxiliar,
              Storage.Instance.ArbolB.padre.valorFarmaco.CompararNombreF);

            

        
            return View("Index", Storage.Instance.pagination);
        }


    }
}
