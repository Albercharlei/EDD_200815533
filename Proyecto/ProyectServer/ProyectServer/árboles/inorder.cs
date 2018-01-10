using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectServer
{
    //nodo de la lista
    public class nodoinorder
    {
        public usuario user;
        public nodoinorder anterior;
        public nodoinorder siguiente;

        public nodoinorder() { }

        public nodoinorder(usuario user_)
        {
            user = user_;
            anterior = null;
            siguiente = null;
        }
    }
    public class inorder
    {
        public nodoinorder primero;
        public nodoinorder ultimo;

        public inorder() { }

        public inorder(binario usuarios)//constructor con un arbol binario
        {
            if (usuarios.raiz != null) ingresar(usuarios.raiz);
        }
        //llenar la lista con nodos del arbol binario
        public void ingresar(usuario user)
        {
            //insertar la parte izquierda
            if(user.izq != null) ingresar(user.izq);
            //insertar el nodo actual
            if (ultimo == null)//la lista esta vacia
            {
                primero = new nodoinorder(user);
                ultimo = primero;
            }
            else
            {
                nodoinorder nuevo = new nodoinorder(user);
                ultimo.siguiente = nuevo;
                nuevo.anterior = ultimo;
                ultimo = nuevo;
            }
            //insertar la parte derecha
            if (user.der != null) ingresar(user.der);
        }
    }

    public class nodotopten
    {
        public usuario user;
        public nodotopten anterior;
        public nodotopten siguiente;

        public nodotopten(usuario user_)
        {
            user = user_;
            anterior = null;
            siguiente = null;
        }
    }

    public class topten
    {
        public int tipo;
        public nodotopten primero;

        public topten(int tipo_) {  tipo = tipo_; }

        public void insertar(nodoinorder entrada)
        {
            //copiar nodo de entrada
            nodotopten nuevo = new nodotopten(entrada.user);

            nodotopten temp = primero;
            if (temp == null)
            {
                primero = nuevo;
            }
            else
            {
                if (tipo == 0)//el ordenamiento es por juegos ganados
                {//insertar al inicio
                    if (temp.user.ganados <= nuevo.user.ganados)
                    {
                        nuevo.siguiente = temp;
                        temp.anterior = nuevo;
                        primero = nuevo;
                    }
                    //insertar al medio
                    else
                    {
                        while (temp.siguiente != null)
                        {
                            if (temp.siguiente.user.ganados <= nuevo.user.ganados)
                            {
                                nuevo.siguiente = temp.siguiente;
                                nuevo.siguiente.anterior = nuevo;
                                temp.siguiente = nuevo;
                                nuevo.anterior = temp;
                                return;//terminar el proceso
                            }
                            else temp = temp.siguiente;
                        }
                        //insertar al final
                        temp.siguiente = nuevo;
                        nuevo.anterior = temp;
                    }
                }
                else if(tipo == 1)//el tipo de ordenamiento es por porcentaje
                {//insertar al inicio
                    if (temp.user.porcentaje <= nuevo.user.porcentaje)
                    {
                        nuevo.siguiente = temp;
                        temp.anterior = nuevo;
                        primero = nuevo;
                    }
                    //insertar al medio
                    else
                    {
                        while (temp.siguiente != null)
                        {
                            if (temp.siguiente.user.porcentaje <= nuevo.user.porcentaje)
                            {
                                nuevo.siguiente = temp.siguiente;
                                nuevo.siguiente.anterior = nuevo;
                                temp.siguiente = nuevo;
                                nuevo.anterior = temp;
                                return;//terminar el proceso
                            }
                            else temp = temp.siguiente;
                        }
                        //insertar al final
                        temp.siguiente = nuevo;
                        nuevo.anterior = temp;
                    }
                }
            }
        }
    }
}