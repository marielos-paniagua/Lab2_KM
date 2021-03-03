using System;
using System.Collections.Generic;
using System.Text;

namespace LstDoblementeEnlazada
{
    public class ListaDobleEnl<T> //: IBusquedas<T>
    {
        //Nodo Raiz de la lista doblemente enlazada

        public Nodo<T> nodoRaiz { get; set; }

        public int elementos { get; set; }
        public List<Nodo<T>> listaBusqueda = new List<Nodo<T>>();

        public ListaDobleEnl()
        {
            nodoRaiz = null;
        }

        //Metodo para contar la cantidad de Nodos actuales en la lista
        public void cantidadElementos()
        {
            int cantidadNodos = 0;
            Nodo<T> nodoContador = nodoRaiz;

            while (nodoContador != null)
            {
                nodoContador = nodoContador.nodoSiguiente;
                cantidadNodos++;
            }

            elementos = cantidadNodos;
        }

        //Metodo para insertar de manera recursiva los nodos en la lista
        public void InsertarEnLista(Nodo<T> nodoAnterior, Nodo<T> nodoActual, Nodo<T> nodoEntrante)
        {
            if (nodoEntrante != null)
            {

                if (nodoRaiz == null)
                {
                    nodoRaiz = nodoEntrante;
                }
                else
                {
                    if (nodoActual == null)
                    {
                        nodoActual = nodoEntrante;

                        if (nodoAnterior != null)
                        {
                            nodoActual.nodoAnterior = nodoAnterior;
                            nodoAnterior.nodoSiguiente = nodoActual;
                        }
                    }
                    else
                    {
                        InsertarEnLista(nodoActual, nodoActual.nodoSiguiente, nodoEntrante);
                    }

                }

            }
        }

        public void eliminarJugar(Nodo<T> raiz, Nodo<T> jugador)
        {
            if (raiz != null && jugador != null)
            {
                while (raiz != null)
                {

                    if (jugador == raiz)
                    {
                        Nodo<T> nodoSiguiente = jugador.nodoSiguiente;
                        Nodo<T> nodoAnterior = jugador.nodoAnterior;


                        //Solo existe este elemento en la lista
                        if (nodoAnterior == null && nodoSiguiente == null)
                        {
                            nodoRaiz = null;
                        }
                        else
                        {

                            // Se encuentra entre nodos
                            if (nodoSiguiente != null && nodoAnterior != null)
                            {
                                nodoAnterior.nodoSiguiente = nodoSiguiente;
                                nodoSiguiente.nodoAnterior = nodoAnterior;
                            }
                            else
                            {
                                //Es el primer de la lista
                                if (nodoAnterior == null)
                                {
                                    nodoRaiz = nodoSiguiente;
                                    nodoRaiz.nodoAnterior = null;
                                }
                                // Es el ultimo de la lista
                                if (nodoSiguiente == null)
                                {
                                    nodoAnterior.nodoSiguiente = null;

                                }
                            }
                        }
                    }
                    raiz = raiz.nodoSiguiente;
                }

            }
        }
    }
}
