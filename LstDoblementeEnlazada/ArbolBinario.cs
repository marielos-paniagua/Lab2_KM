using System;
using System.Collections.Generic;
using System.Text;


namespace LibFarmacos
{
    public class ArbolBinario<T>
    {
        public List<T> listaInOrder = new List<T>();
        public Nodo<T> padre { get; set; }
        public int elementos { get; set; }
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
                this.insertar(NodoNuevo, padre, compararFarmaco);

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

        public Nodo<T> Buscar( Nodo<T> elemento, string Nombre, Func<T, string, int> compararFarmaco)
        {
            bool encontrado = false;

            while (!encontrado)
            {
                // > 0 si el primero es mayor < 0 si el primero es menor y 0 si son iguales                
                if (compararFarmaco(elemento.valorFarmaco, Nombre) == 0)
                {
                    encontrado = true;
                }
                else
                {
                    if (compararFarmaco(elemento.valorFarmaco, Nombre) > 0)
                    {
                        if (elemento.HijoDerecho != null)
                        {
                            elemento = elemento.HijoDerecho;// as ArbolBinario<T>;
                        }
                        

                    }
                    else
                    {
                        if (elemento.HijoIzquierdo != null)
                        {
                            elemento = elemento.HijoIzquierdo;// as ArbolBinarioBase<T>;
                        }
                        
                    }
                }
            }
            return elemento;
        }

        public void Eliminar( string Nombre, Func<string, T, int> compararFarmaco) {

  
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
                                    padre.HijoIzquierdo = siguiente.HijoIzquierdo;
                                else
                                    padre.HijoDerecho = siguiente.HijoDerecho;
                            }
                            else
                            {
                                this.padre = siguiente.HijoIzquierdo;
                            }
                            encontrado = true;

                        }
                        else if (siguiente.HijoIzquierdo == null)  //Si solo tiene rama derecha
                        {
                           
                            if ((padre != null))
                            {
                                if (EsHijoIzquierdo)
                                    padre.HijoIzquierdo = siguiente.HijoDerecho;
                                else
                                    padre.HijoDerecho = siguiente.HijoDerecho;
                            }
                            else
                            {
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
                                    T miDato = aEliminar.valorFarmaco;
                                    aEliminar.valorFarmaco = siguiente.valorFarmaco;
                                    padre.HijoIzquierdo = null;
                                    encontrado = true;
                                }

                            }
                            else
                            {
                                siguiente.HijoIzquierdo = aEliminar.HijoIzquierdo;

                                if (padre != null)
                                {
                                    if (EsHijoIzquierdo)
                                        padre.HijoIzquierdo = aEliminar.HijoDerecho;
                                    else
                                        padre.HijoDerecho = aEliminar.HijoDerecho;
                                }
                                else //Es la raiz
                                {
                                    if (EsHijoIzquierdo)
                                        this.padre = aEliminar.HijoDerecho;
                                    else
                                        this.padre = aEliminar.HijoDerecho;
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
                }//Fin del if comparaci{on
            }


            }


        public void InOrder(Nodo<T> elemento) {
            if (elemento != null)
            {
                listaInOrder.Add(elemento.valorFarmaco);
                InOrder(elemento.HijoIzquierdo);

                InOrder(elemento.HijoDerecho);

                
            }
            
        }
       

    }
}
