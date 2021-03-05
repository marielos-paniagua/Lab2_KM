using System;
using System.Collections.Generic;
using System.Text;


namespace LibFarmacos
{
    public class ArbolBinario<T>
    {
        public Nodo<T> padre { get; set; }
        public ArbolBinario()
        {
            padre = null;
        }
        //Metodo para insertar solo la raiz 
        public void insertar(T DatoInsertar, Comparison<T> compararFarmaco)
        {
            Nodo<T> NodoNuevo = new Nodo<T>();
            NodoNuevo.valorFarmaco = DatoInsertar;
            if (padre == null)
            {
                padre = NodoNuevo;
            }
            else
            {
                padre = this.insertar(NodoNuevo, padre, compararFarmaco);

            }
        }
        // Metodo para insertar los hijos ya sea izquierda o derecha
        public Nodo<T> insertar(Nodo<T>Nuevo, Nodo<T> Nodopadre, Comparison<T> compararFarmaco)
        {
            if (compararFarmaco(Nuevo.valorFarmaco, Nodopadre.valorFarmaco)<0)
            {
                if (Nodopadre.HijoIzquierdo == null)
                {
                    Nodopadre.HijoIzquierdo = Nuevo;
                    return Nodopadre;
                }
                else
                {
                    Nodopadre.HijoIzquierdo = insertar(Nuevo,Nodopadre.HijoIzquierdo, compararFarmaco);
                    return Nodopadre;
                }
            }
            else if (compararFarmaco(Nuevo.valorFarmaco, Nodopadre.valorFarmaco) > 0)
            {
                if (Nodopadre.HijoDerecho == null)
                {
                    Nodopadre.HijoDerecho = Nuevo;
                    return Nodopadre;
                }
                else
                {
                    Nodopadre.HijoDerecho = insertar(Nuevo, Nodopadre.HijoDerecho, compararFarmaco);
                    return Nodopadre;
                }
            }
            else
            {
                return Nodopadre;
            }
            

        }


        
    }
}
