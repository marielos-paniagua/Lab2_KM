using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using LstDoblementeEnlazada;
using LibFarmacos;
using Lab2_KM.Models;
using System.Text.RegularExpressions;


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

        public void readerLineByLine(string[] lineasCsv)
        {

            foreach (var linea in lineasCsv)
            {
                if (isFirstLine)
                {
                    isFirstLine = false;
                    continue;
                }

                


                LstDoblementeEnlazada.Nodo<InventarioFarmacos> nodo = new LstDoblementeEnlazada.Nodo<InventarioFarmacos>();
                

                InventarioFarmacos farmacoEntrante = new InventarioFarmacos();

                string expresionRegular = ",(\"[^\"]*\"|[^,]*)";

                string[] regexText = Regex.Split(linea, expresionRegular);

                List<string> finalRegexText = new List<string>();

                foreach (var item in regexText)
                {
                    if (item.Length > 0)
                    {
                        finalRegexText.Add(item);
                    }

                }


                InventarioFarmacos farmaco = new InventarioFarmacos();

                farmaco.Id = finalRegexText[0];
                farmaco.NombreFarmaco = finalRegexText[1];
                farmaco.descripcion = finalRegexText[3];
                farmaco.CasaProductora = finalRegexText[3];
                farmaco.precio = finalRegexText[4];
                farmaco.existencia = int.Parse(finalRegexText[5]);


                FarmacoArbol nodoArbol = new FarmacoArbol();
                nodoArbol.id = finalRegexText[0];
                nodoArbol.NombreFarmaco = finalRegexText[1];



                nodo.elemento = farmaco;

                Storage.Instance.listaArtesanal.InsertarEnLista(Storage.Instance.listaArtesanal.nodoRaiz,
                    Storage.Instance.listaArtesanal.nodoRaiz, nodo);


                // Insercion Arbol B

                Storage.Instance.ArbolB.insertar(nodoArbol, nodoArbol.CompararNombreF);
            }
        }
    }
}
