using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectServer
{
    public class nodoavl
    {
        public usuario user;//referencia al usuario del nodo
        public String nick;
        public String pass;
        public String email;

        public nodoavl raiz;
        public nodoavl izq;
        public nodoavl der;

        public nodoavl() { }//constructor sin parametros para el webservice

        public nodoavl(usuario user_)
        {
            user = user_;
            nick = user_.getnick();
            pass = user_.getpass();
            email = user_.email;

            raiz = null;
            izq = null;
            der = null;
        }
        //altura del nodo
        public int altura()
        {
            int ret = 0;
            //obtener altura izquierda
            int hizq = 0;
            if (izq != null) hizq = izq.altura() + 1;
            //obtener altura derecha
            int hder = 0;
            if (der != null) hder = der.altura() + 1;

            if (hizq >= hder) return hizq + 1;
            else return hder + 1;
        }
        //factor de equilibrio
        public int fe()
        {
            int hder = 0;
            if (der != null) hder = der.altura();
            int hizq = 0;
            if (izq != null) hizq = izq.altura();
            return hder - hizq;
        }
    }
    public class avl
    {
        public nodoavl raiz;//raíz del árbol

        public avl() { raiz = null; }

        public nodoavl giroizq(nodoavl nodo)
        {
            //cambiar apuntadores
            nodoavl tempder = nodo.der;
            tempder.raiz = nodo.raiz;
            nodo.raiz = tempder;
            nodo.der = tempder.izq;
            tempder.izq = nodo;
            if (nodo.der != null) nodo.der.raiz = nodo;
            if (tempder.raiz != null)
            {
                if (tempder.raiz.der == nodo) tempder.raiz.der = tempder;
                else tempder.raiz.izq = tempder;
            }
            else raiz = tempder;//si el padre es nulo, la nueva raiz es el nodo rotado
            return tempder;
        }

        public nodoavl giroder(nodoavl nodo)
        {
            //cambiar apuntadores
            nodoavl tempizq = nodo.izq;
            tempizq.raiz = nodo.raiz;
            nodo.raiz = tempizq;
            nodo.izq = tempizq.der;
            tempizq.der = nodo;
            if (nodo.izq != null) nodo.izq.raiz = nodo;
            if (tempizq.raiz != null)
            {
                if (tempizq.raiz.der == nodo) tempizq.raiz.der = tempizq;
                else tempizq.raiz.izq = tempizq;
            }
            else raiz = tempizq;//si el padre es nulo, la nueva raiz es el nodo rotado
            return tempizq;
        }

        public void rotacion(nodoavl nodo)
        {
            int balance = nodo.fe();//obtener factor de equilibrio
            if(balance > 1)//el factor de equilibrio es 2 o más, el peso es por la derecha
            {
                if(nodo.der != null)
                {
                    if (nodo.der.fe() >= 0)
                    {
                        nodoavl rotado = giroizq(nodo);//realizar rotación izquierda
                        if (rotado.raiz != null) rotacion(rotado.raiz);//continuar con la rotación hacia la raíz
                    }
                    else if (nodo.der.fe() < 0)//realizar rotación doble por la derecha y luego por la izquierda
                    {
                        giroder(nodo.der);//realizar rotación derecha con el nodo derecho
                        nodoavl rotado = giroizq(nodo);//realizar rotación izquierda con el nodo
                        if (rotado.raiz != null) rotacion(rotado.raiz);//continuar con la rotación hacia la raíz
                    }
                }
                
                //else no se hace rotación porque el nodo esá balanceado
            }
            else if (balance < -1)//el factor de equilibrio es -2 o menos, el peso es por la izquierda
            {
                if(nodo.izq != null)
                {
                    if (nodo.izq.fe() <= 0)
                    {
                        nodoavl rotado = giroder(nodo);//realizar rotación derecha
                        if (rotado.raiz != null) rotacion(rotado.raiz);//continuar con la rotación hacia la raíz
                    }
                    else if (nodo.izq.fe() > 0)//realizar rotación doble por la izquierda y luego por la derecha
                    {
                        giroizq(nodo.izq);//realizar rotación izquierda con el nodo izquierdo
                        nodoavl rotado = giroder(nodo);//realizar rotación derecha con el nodo
                        if (rotado.raiz != null) rotacion(rotado.raiz);//continuar con la rotación hacia la raíz
                    }
                }
                //else no se hace rotación porque el nodo esá balanceado
            }
            else
            {
                if (nodo.raiz != null) rotacion(nodo.raiz);//continuar con la rotacion hacia la raiz
            }
        }

        public void insertar(usuario nuevouser, nodoavl nodo)
        {
            if (nodo == null)
            {
                if (raiz == null) raiz = new nodoavl(nuevouser);//crear nueva raiz
                else insertar(nuevouser, raiz);//insertar a partir de la raiz
            }
            else
            {
                //el nodo va a la rama izquierda
                if (String.Compare(nodo.nick,nuevouser.getnick()) > 0)
                {
                    if (nodo.izq == null)
                    {
                        nodo.izq = new nodoavl(nuevouser);
                        nodo.izq.raiz = nodo;
                        rotacion(nodo.izq);//realizar balanceo
                    }
                    else insertar(nuevouser, nodo.izq);
                }
                //el nodo va a la rama derecha
                else if(String.Compare(nodo.nick,nuevouser.getnick()) < 0)
                {
                    if (nodo.der == null)
                    {
                        nodo.der = new nodoavl(nuevouser);
                        nodo.der.raiz = nodo;
                        rotacion(nodo.der);//realizar balanceo
                    }
                    else insertar(nuevouser, nodo.der);
                }
            }
        }
    }
}