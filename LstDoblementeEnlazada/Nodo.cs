using System;
using System.Collections.Generic;
using System.Text;

namespace LstDoblementeEnlazada
{
    public class Nodo<T>
    {
        public T id { get; set; }
        public T nombre { get; set; }
        public T descripcion { get; set; }
        public T casa_productora { get; set; }
        public T precio { get; set; }
        public T existencia { get; set; }

        public Nodo<T> nodoAnterior { get; set; }

        public Nodo<T> nodoSiguiente { get; set; }

        // Constructor
        public Nodo()
        {
            nodoAnterior = null;
            nodoSiguiente = null;
        }
    }
}
