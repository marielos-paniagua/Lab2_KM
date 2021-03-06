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

        public int buscarFarmacoBinario(FarmacoArbol InventarioF, string InventarioF2)
        {
            return InventarioF2.CompareTo(InventarioF.NombreFarmaco);
        }

        public int buscarEliminacionFarmacoBinario(string InventarioF2, FarmacoArbol InventarioF)
        {
            return InventarioF2.CompareTo(InventarioF.NombreFarmaco);
        }
    }
}
