using System;
using System.Collections.Generic;
using System.Text;

namespace LibFarmacos
{
    public interface IBusquedas<T>
    {
        public void busquedaNombre(Nodo<T> raiz, string busqueda);
    }
}
