using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_KM.Models
{
    public class InventarioFarmacos
    {
        public string Id { get; set; }
        public string NombreFarmaco { get; set; }

        public string descripcion { get; set; }

        public string CasaProductora { get; set; }

        public string precio { get; set; }

        public int existencia { get; set; }

        public int compararFarmaco(InventarioFarmacos farmaco, string ID) {
            return farmaco.Id.CompareTo(ID);
        }
    }
}
