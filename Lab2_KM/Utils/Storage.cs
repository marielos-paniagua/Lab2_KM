using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2_KM.Models;
using LstDoblementeEnlazada;

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
        
        public ListaDobleEnl<string> listaArtesanal = new ListaDobleEnl<string>();
        public List<Client> ClientList = new List<Client>();         
    }
}
