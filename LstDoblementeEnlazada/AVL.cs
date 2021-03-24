using System;
using System.Collections.Generic;
using System.Text;

namespace LibFarmacos
{
    public class AVL<T> : ArbolBinario<T>
    {
        public Nodo<T> Raiz
        {
            get
            {
                return this.padre;
            }
        }

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
                this.insertar(NodoNuevo, padre, compararFarmaco);

            }
        }
        // Metodo para insertar los hijos ya sea izquierda o derecha
        public Nodo<T> insertar(Nodo<T> Nuevo, Nodo<T> Nodopadre, Comparison<T> compararFarmaco)
        {
            if (compararFarmaco(Nuevo.valorFarmaco, Nodopadre.valorFarmaco) < 0)
            {
                if (Nodopadre.HijoIzquierdo == null)
                {
                    Nodopadre.HijoIzquierdo = Nuevo;
                    Nodopadre.HijoIzquierdo.Padre = Nodopadre;
                    Equilibrar(Nodopadre, true, true);
                    return Nodopadre;
                }
                else
                {
                    Nodopadre.HijoIzquierdo = insertar(Nuevo, Nodopadre.HijoIzquierdo, compararFarmaco);
                    return Nodopadre;
                }
            }
            else if (compararFarmaco(Nuevo.valorFarmaco, Nodopadre.valorFarmaco) > 0)
            {
                if (Nodopadre.HijoDerecho == null)
                {
                    Nodopadre.HijoDerecho = Nuevo;
                    Nodopadre.HijoDerecho.Padre = Nodopadre;
                    Equilibrar(Nodopadre, false, true);
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

        public void Eliminar(string Nombre, Func<string, T, int> compararFarmaco)
        {


            Nodo<T> siguiente = this.padre;
            Nodo<T> padre = null;
            bool EsHijoIzquierdo = false;
            bool encontrado = false;

            while (!encontrado)
            {

                if (compararFarmaco(Nombre, siguiente.valorFarmaco) == 0)
                {

                    if ((siguiente.HijoDerecho == null) && (siguiente.HijoIzquierdo == null)) //Si es una hoja
                    {

                        if ((padre != null))
                        {
                            if (EsHijoIzquierdo)
                                padre.HijoIzquierdo = null;
                            else
                                padre.HijoDerecho = null;
                            Equilibrar(padre, EsHijoIzquierdo, false);
                        }
                        else //Si padre es null entonces es la raiz
                        {
                            this.padre = null;
                        }

                        encontrado = true;
                    }
                    else
                    {
                        if (siguiente.HijoDerecho == null) //Si solo tiene rama izquierda
                        {
                            if ((padre != null))
                            {
                                if (EsHijoIzquierdo)
                                {
                                    padre.HijoIzquierdo = siguiente.HijoIzquierdo;
                                    siguiente.HijoIzquierdo.Padre = padre;
                                }
                                else
                                {
                                    padre.HijoDerecho = siguiente.HijoDerecho;
                                    siguiente.HijoIzquierdo.Padre = padre;
                                }
                                Equilibrar(padre, EsHijoIzquierdo, false);
                            }
                            else
                            {
                                siguiente.HijoIzquierdo.Padre = null;
                                this.padre = siguiente.HijoIzquierdo;
                            }
                            encontrado = true;

                        }
                        else if (siguiente.HijoIzquierdo == null)  //Si solo tiene rama derecha
                        {

                            if ((padre != null))
                            {
                                if (EsHijoIzquierdo)
                                {
                                    padre.HijoIzquierdo = siguiente.HijoDerecho;
                                    siguiente.HijoDerecho.Padre = padre;
                                }
                                else
                                {
                                    padre.HijoDerecho = siguiente.HijoDerecho;
                                    siguiente.HijoDerecho.Padre = padre;
                                }
                                Equilibrar(padre, EsHijoIzquierdo, false);
                            }
                            else
                            {
                                siguiente.HijoDerecho.Padre = null;
                                this.padre = siguiente.HijoDerecho;
                            }

                            encontrado = true;
                        }
                        else  //Tiene ambas ramas el que lo sustituirá será el mas izquierdo de los derechos
                        {
                            Nodo<T> aEliminar = siguiente;
                            siguiente = siguiente.HijoDerecho;
                            int cont = 0;
                            while (siguiente.HijoIzquierdo != null)
                            {
                                padre = siguiente;
                                siguiente = siguiente.HijoIzquierdo;
                                cont++;
                            }

                            if (cont > 0)
                            {
                                if (padre != null)
                                {
                                    aEliminar.valorFarmaco = siguiente.valorFarmaco;
                                    if (siguiente.HijoDerecho == null)
                                    {
                                        padre.HijoIzquierdo = null;
                                        Equilibrar(padre, true, false);
                                    }
                                    else
                                    {
                                        padre.HijoIzquierdo = siguiente.HijoDerecho;
                                        siguiente.HijoDerecho.Padre = padre;
                                        Equilibrar(padre, true, false);
                                    }
                                    encontrado = true;
                                }

                            }
                            else
                            {
                                //asignar nuevo hijo a Siguiente
                                siguiente.HijoIzquierdo = aEliminar.HijoIzquierdo;
                                aEliminar.HijoIzquierdo.Padre = siguiente;
                                siguiente.Balance = aEliminar.Balance;
                                siguiente.Padre = aEliminar.Padre;

                                if (padre != null)
                                {
                                    if (EsHijoIzquierdo)
                                    {
                                        padre.HijoIzquierdo = aEliminar.HijoDerecho;
                                        Equilibrar(siguiente, false, false);
                                    }
                                    else
                                    {
                                        padre.HijoDerecho = aEliminar.HijoDerecho;
                                        Equilibrar(siguiente, false, false);
                                    }
                                }
                                else //Es la raiz
                                {
                                    this.padre = aEliminar.HijoDerecho;
                                    Equilibrar(this.padre, false, false);
                                }

                                encontrado = true;
                            }

                        }
                    }
                }
                else
                {
                    if (compararFarmaco(Nombre, siguiente.valorFarmaco) > 0)
                    {
                        if (siguiente.HijoDerecho != null)
                        {
                            padre = siguiente;
                            EsHijoIzquierdo = false;
                            siguiente = siguiente.HijoDerecho;

                        }


                    }
                    else //menor que 0
                    {
                        if (siguiente.HijoIzquierdo != null)
                        {
                            padre = siguiente;
                            EsHijoIzquierdo = true;
                            siguiente = siguiente.HijoIzquierdo;
                        }

                    }
                }//Fin del if comparación
            }
        }

        internal void Equilibrar(Nodo<T> nodo, bool esIzquierdo, bool esNuevo)
        {
            bool terminar = false;//necesita rotación

            while ((nodo != null) && !terminar)
            {
                bool rota = false;//inicia sin rotar
                if (esNuevo)
                {
                    if (esIzquierdo)
                        nodo.Balance--;//se está añadiendo
                    else
                        nodo.Balance++;
                }
                else
                {
                    if (nodo.Balance == 0)
                        terminar = true;

                    if (esIzquierdo)
                        nodo.Balance++;//se está borrando
                    else
                        nodo.Balance--;
                }

                if (nodo.Balance == 0)
                    terminar = true;//no varía la altura, no equilibrar
                else if (nodo.Balance == -2)//hay desbalance, con rotación doble o simple a la derecha
                {
                    if (nodo.HijoIzquierdo.Balance == 1)
                    {
                        RDD(nodo); //doble
                        rota = true;
                    }
                    else
                    {
                        RSD(nodo);//simple
                        rota = true;
                    }
                    terminar = true;
                }
                else if (nodo.Balance == 2)//hay desbalance, con rotación doble o simple a la izquierda
                {
                    if (nodo.HijoDerecho.Balance == -1)
                    {
                        RDI(nodo);//doble
                        rota = true;
                    }
                    else
                    {
                        RSI(nodo);//simple
                        rota = true;
                    }
                    terminar = true;
                }

                if (rota && (nodo.Padre != null) && !esNuevo)
                    nodo = nodo.Padre;

                if (nodo.Padre != null)
                {
                    if (nodo.Padre.HijoDerecho == nodo)
                        esIzquierdo = false;
                    else
                        esIzquierdo = true;

                    if (!esNuevo && nodo.Balance == 0)
                        terminar = false;
                }

                nodo = nodo.Padre;//calcular balance, siguiente nodo (padre)
            }
        }

        public void RDD(Nodo<T> nodo)
        {
            Nodo<T> Padre = nodo.Padre;
            Nodo<T> P = nodo;
            Nodo<T> Q = P.HijoIzquierdo;
            Nodo<T> R = Q.HijoDerecho;
            Nodo<T> B = R.HijoIzquierdo;
            Nodo<T> C = R.HijoDerecho;

            if (Padre != null)
            {
                if (Padre.HijoDerecho == P)
                    Padre.HijoDerecho = R;
                else
                    Padre.HijoIzquierdo = R;
            }
            else
            {
                this.padre = R;
                this.padre.Padre = null;
            }

            //reconstruir
            Q.HijoDerecho = B;
            P.HijoIzquierdo = C;
            R.HijoIzquierdo = Q;
            R.HijoDerecho = P;

            //reasignar padre
            R.Padre = Padre;
            P.Padre = Q.Padre = R;
            if (B != null)
                B.Padre = Q;
            if (C != null)
                C.Padre = P;

            //ajustar valores
            switch (R.Balance)
            {
                case -1:
                    {
                        Q.Balance = 0;
                        P.Balance = 1;
                    }
                    break;
                case 0:
                    {
                        Q.Balance = 0;
                        P.Balance = 0;
                    }
                    break;
                case 1:
                    {
                        Q.Balance = -1;
                        P.Balance = 0;
                    }
                    break;
            }
            R.Balance = 0;
        }

        public void RSD(Nodo<T> nodo)
        {
            Nodo<T> Padre = nodo.Padre;
            Nodo<T> P = nodo;
            Nodo<T> Q = P.HijoIzquierdo;
            Nodo<T> B = Q.HijoDerecho;

            if (Padre != null)
            {
                if (Padre.HijoDerecho == P)
                    Padre.HijoDerecho = Q;
                else
                    Padre.HijoIzquierdo = Q;
            }
            else
            {
                this.padre = Q;
                this.padre.Padre = null;
            }

            //reconstruir
            P.HijoIzquierdo = B;
            Q.HijoDerecho = P;

            //reasignar padre
            P.Padre = Q;
            if (B != null)
                B.Padre = P;
            Q.Padre = Padre;

            //ajustar valores
            if (Q.Balance == 0)
            {
                P.Balance = -1;
                Q.Balance = 1;
            }
            else
            {
                P.Balance = 0;
                Q.Balance = 0;
            }
        }

        public void RDI(Nodo<T> nodo)
        {
            Nodo<T> Padre = nodo.Padre;
            Nodo<T> P = nodo;
            Nodo<T> Q = nodo.HijoDerecho;
            Nodo<T> R = Q.HijoIzquierdo;
            Nodo<T> B = R.HijoIzquierdo;
            Nodo<T> C = R.HijoDerecho;

            if (Padre != null)
            {
                if (Padre.HijoDerecho == P)
                    Padre.HijoDerecho = R;
                else
                    Padre.HijoIzquierdo = R;
            }
            else
            {
                this.padre = R;
                this.padre.Padre = null;
            }

            //reconstruir
            P.HijoDerecho = B;
            Q.HijoIzquierdo = C;
            R.HijoIzquierdo = P;
            R.HijoDerecho = Q;

            //reasignar padre
            R.Padre = Padre;
            P.Padre = Q.Padre = R;
            if (B != null)
                B.Padre = P;
            if (C != null)
                C.Padre = Q;

            //ajustar valores
            switch (R.Balance)
            {
                case -1:
                    {
                        P.Balance = 0;
                        Q.Balance = 1;
                    }
                    break;
                case 0:
                    {
                        P.Balance = 0;
                        Q.Balance = 0;
                    }
                    break;
                case 1:
                    {
                        P.Balance = -1;
                        Q.Balance = 0;
                    }
                    break;
            }
            R.Balance = 0;
        }

        public void RSI(Nodo<T> nodo)
        {
            Nodo<T> Padre = nodo.Padre;
            Nodo<T> P = nodo;
            Nodo<T> Q = P.HijoDerecho;
            Nodo<T> B = Q.HijoIzquierdo;

            if (Padre != null)
            {
                if (Padre.HijoDerecho == P)
                    Padre.HijoDerecho = Q;
                else
                    Padre.HijoIzquierdo = Q;
            }
            else
            {
                this.padre = Q;
                this.padre.Padre = null;
            }

            //reconstruir
            P.HijoDerecho = B;
            Q.HijoIzquierdo = P;

            //reasignar padre
            P.Padre = Q;
            if (B != null)
                B.Padre = P;
            Q.Padre = Padre;

            //ajustar valores
            if (Q.Balance == 0)
            {
                P.Balance = 1;
                Q.Balance = -1;
            }
            else
            {
                P.Balance = 0;
                Q.Balance = 0;
            }
        }

        public Nodo<T> BuscarAVL(Nodo<T> elemento, string Nombre, Func<T, string, int> compararFarmaco)
        {
            ArbolBinario<T> buscar = new ArbolBinario<T>();
            elemento = buscar.Buscar(elemento, Nombre, compararFarmaco);
            return elemento;
        }

        public void InOrderAVL(Nodo<T> elemento)
        {
            ArbolBinario<T> recorrido = new ArbolBinario<T>();
            recorrido.InOrder(elemento);
        }
    }
}
