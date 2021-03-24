using System;
using System.Collections.Generic;
using System.Text;

namespace LibFarmacos
{
    public class Nodo<T>
    { 
        public Nodo<T> HijoIzquierdo { get; set; }

        public Nodo<T> HijoDerecho { get; set; }

        // Constructor
        public Nodo()
        {
            HijoIzquierdo = null;
            HijoDerecho = null;
            
        }
        public T valorFarmaco { get; set; }
        public Nodo<T> Padre { get; set; }
        public int Balance { get; set; }
    }
}
