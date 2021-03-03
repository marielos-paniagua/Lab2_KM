using System;
using System.Collections.Generic;
using System.Text;

namespace LstDoblementeEnlazada
{
    public interface IBusquedas<T>
    {
        public void busquedaNombre(Nodo<T> raiz, string busqueda);
    }
}
