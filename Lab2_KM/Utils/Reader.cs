using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using LstDoblementeEnlazada;
using LibFarmacos;

namespace Lab2_KM.Utils
{
    public class Reader
    {
        public Reader(string ruta)
        {
            string[] lineasCsv = File.ReadAllLines(ruta);
            readerLineByLine(lineasCsv);
        }

        bool isFirstLine = true;

        //public void readerLineByLine(string[] lineasCsv)
        //{

        //    foreach (var linea in lineasCsv)
        //    {
        //        if (isFirstLine)
        //        {
        //            isFirstLine = false;
        //            continue;
        //        }

        //        var lineaDeDatos = linea.Split(',');

        //        Nodo<string> nodo = new Nodo<string>
        //        {
        //            id = lineaDeDatos[0],
        //            nombre = lineaDeDatos[1],
        //            descripcion = lineaDeDatos[2],
        //            casa_productora = lineaDeDatos[3],
        //            precio = lineaDeDatos[4],
        //            existencia = lineaDeDatos[5],
        //        };

        //    }
        //}
    }
}
