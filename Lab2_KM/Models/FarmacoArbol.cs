using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_KM.Models
{
    public class FarmacoArbol
    {
        public string id { get; set; }
        public string NombreFarmaco { get; set; }
        public int CompareTo(object Farmaco2)
        {
            return NombreFarmaco.CompareTo(((FarmacoArbol)Farmaco2).NombreFarmaco);
        }
        public Comparison<FarmacoArbol> CompararNombreF = delegate (FarmacoArbol InventarioF, FarmacoArbol InventarioF2)
        {
            return InventarioF.NombreFarmaco.CompareTo(InventarioF2.NombreFarmaco);
        };
    }
}
