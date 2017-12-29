﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectServer
{
    public class usuario
    {
        private String nick;
        private String pass;
        public String email;
        public int conectado;
        public listajuegos listado;

        public usuario raiz;
        public usuario izq;
        public usuario der;

        public usuario() { }

        public usuario(String nick_, String pass_, String email_, int conectado_)
        {
            nick = nick_;
            pass = pass_;
            email = email_;
            conectado = conectado_;
            listado = null;
            raiz = null;
            izq = null;
            der = null;
        }

        public void setnick(String nick_) { nick = nick_; }

        public String getnick() { return nick; }

        public void setpass(String pass_) { pass = pass_; }

        public String getpass() { return pass; }

        public void insertarjuego(String oponente_, int desplegadas_, int sobrevivientes_, int destruidas_, int gano_)
        {
            if (listado == null) listado = new listajuegos();
            listado.insertar(nick, oponente_, desplegadas_, sobrevivientes_, destruidas_, gano_);
        }
    }

    public class binario
    {
        public usuario raiz;

        public binario()
        {
            raiz = null;
        }
        //método de inserción en el árbol binario
        public void insertar(String nick_, String pass_, String email_, int conectado_, usuario r)
        {
            //insertar desde la raiz
            if (r == null)
            {
                //insertar en la raiz
                if (raiz == null) raiz = new usuario(nick_, pass_, email_,conectado_);
                else insertar(nick_, pass_, email_, conectado_, raiz);
            }
            else
            {
                //el nodo va al hijo izquierdo
                if (String.Compare(r.getnick(), nick_) > 0)
                {
                    //insertar si el nodo es nulo
                    if (r.izq == null)
                    {
                        r.izq = new usuario(nick_, pass_, email_, conectado_);
                        r.izq.raiz = r;
                    }
                    //insertar en el arbol izquierdo
                    else insertar(nick_, pass_, email_, conectado_, r.izq);
                }
                //el nodo va al hijo derecho
                else if (String.Compare(r.getnick(), nick_) < 0)
                {
                    //insertar si el nodo es nulo
                    if (r.der == null)
                    {
                        r.der = new usuario(nick_, pass_, email_, conectado_);
                        r.der.raiz = r;
                    }
                    //insertar en el arbol izquierdo
                    else insertar(nick_, pass_, email_, conectado_, r.der);
                }
            }
        }

        //método de búsqueda de un usuario
        public usuario buscar(String nick_, usuario r)
        {
            if (this.raiz == null) return null;
            else
            {
                if (r != null)
                {
                    int comp = String.Compare(r.getnick(), nick_);
                    switch (comp)
                    {
                        case -1:
                            return buscar(nick_, r.der);
                        case 0:
                            return r;
                        case 1:
                            return buscar(nick_, r.izq);
                    }
                }
                return null;
            }
        }

        //método de eliminación de un nodo
        public void eliminar(String nick_)
        {
            usuario temp = buscar(nick_, this.raiz);
            if (temp != null)
            {
                if(temp.izq == null)
                {
                    if(temp.der == null)
                    {//el nodo es una hoja
                        if (temp.raiz != null)
                        {
                            if (temp.raiz.izq == temp) temp.raiz.izq = null;
                            else if (temp.raiz.der == temp) temp.raiz.der = null;
                        }
                        else raiz = null;//el nodo a eliminar era la raiz
                    }
                    //el nodo tiene un hijo por la derecha
                    else
                    {
                        if (temp.raiz != null)
                        {
                            if (temp.raiz.izq == temp) temp.raiz.izq = temp.der;
                            else if (temp.raiz.der == temp) temp.raiz.der = temp.der;
                        }
                        else raiz = temp.der;//el nodo era la raiz
                    }
                }
                else
                {
                    //el nodo tiene un hijo por la izquierda
                    if(temp.der == null)
                    {
                        if (temp.raiz != null)
                        {
                            if (temp.raiz.izq == temp) temp.raiz.izq = temp.izq;
                            else if (temp.raiz.der == temp) temp.raiz.der = temp.izq;
                        }
                        else raiz = temp.izq;//el nodo era la raiz
                    }
                    //el nodo tiene dos hijos
                    else
                    {
                        usuario sust = buscarmin(temp.der);
                        if (temp.raiz != null)
                        {
                            if (temp.raiz.izq == temp) temp.raiz.izq = sust;
                            else if (temp.raiz.der == temp) temp.raiz.der = sust;
                        }
                        else raiz = sust;//el nodo era la raiz
                        sust.izq = temp.izq;
                        sust.der = temp.der;
                    }
                }

                //buscar el nodo adecuado para ocupar el lugar del nodo que se esta eliminando
                /*usuario aux = sustituir(temp);
                if(aux != null) aux.raiz = temp.raiz;
                if (temp.raiz != null)
                {
                    if (temp == temp.raiz.izq) temp.raiz.izq = aux;
                    else if (temp == temp.raiz.der) temp.raiz.der = aux;
                }
                else raiz = aux;//establecer nueva raiz*/
            }
        }

        //insertar lista de juegos
        public void insertarjuego(String userbase_, String oponente_, int desplegadas_, int sobrevivientes_, int destruidas_, int gano_)
        {
            usuario insert = buscar(userbase_, raiz);
            insert.insertarjuego(oponente_, desplegadas_, sobrevivientes_, destruidas_, gano_);
        }

        /*public usuario sustituir(usuario u)
        {
            if (u != null)
            {
                //si hay nodos por la izquierda
                if (u.izq != null)
                {
                    usuario temp = buscarmax(u);
                    if(temp != null) temp.der = u.der;
                    return temp;
                }
                //si hay nodos por la derecha
                else if (u.der != null)
                {
                    usuario temp = buscarmin(u);
                    if (temp != null) temp.izq = u.izq;
                    return temp;
                }
                //si no hay nodos hijos
                else return null;
            }
            return null;
        }*/
        //buscar nodo para sustitución por la derecha
        public usuario buscarmin(usuario u)
        {
            if (u != null)
            {
                if (u.izq == null)
                {
                    eliminar(u.getnick());
                    return u;
                }
                else return buscarmin(u.izq);
            }
            return null;
        }
        //buscar nodo para sustitución por la izquierda
        public usuario buscarmax (usuario u)
        {
            if (u != null)
            {
                if (u.der == null)
                {
                    if (u.izq == null)
                    {
                        return null;//el valor a sustituir es nulo porque es una hoja
                    }
                    else u.izq.raiz = null;
                    return u;
                }
                else return buscarmax(u.der);
            }
            return null;
        }

        //editar elementos de un nodo
        public void editar (usuario u,String newnick,String newpass)
        {
            u.setnick(newnick);
            u.setpass(newpass);
        }
    }
}