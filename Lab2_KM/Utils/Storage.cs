using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2_KM.Models;
using LstDoblementeEnlazada;
using LibFarmacos;

namespace Lab2_KM.Utils
{
    public class Storage
    {
        private static Storage _instance = null;

        public static Storage Instance
        {

            get
            {
                if (_instance == null) _instance = new Storage();
                return _instance;
            }
        }

        //public ListaDobleEnl<FarmacoArbol> listaArtesanal = new ListaDobleEnl<FarmacoArbol>();
        public ArbolBinario<FarmacoArbol> ArbolB = new ArbolBinario<FarmacoArbol>();
        public List<Client> ClientList = new List<Client>();         
    }
}
