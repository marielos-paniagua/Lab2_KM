using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2_KM.Utils;

namespace Lab2_KM.Models
{
    public class paginacion
    {
        public IEnumerable<FarmacoArbol> farmacos { get; set; }

        public int farmacosPorPagina { get; set; }

        public int paginaActual { get; set; }

        public int paginas() {

            return Convert.ToInt32(Math.Ceiling(farmacos.Count() / (double)farmacosPorPagina));
        
        }

        public IEnumerable<FarmacoArbol> pags() {

            int inicio = (paginaActual - 1) * farmacosPorPagina;
            return farmacos.Skip(inicio).Take(farmacosPorPagina);

        }


    }
}
