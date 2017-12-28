﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectServer
{
    public class mo
    {
        public int sizex;//tamaño de coordenadas de x
        public int sizey;//tamaño de coordenadas de y
        public nivel primero;//nivel 1

        public mo() { }

        public mo(int x,int y)//tamaño de coordenadas de y
        {
            sizex = x;
            sizey = y;
            insertnivel();
        }

        public void insertnivel()
        {
            if (primero == null) primero = new nivel(1);
            int lvl = 2;
            nivel temp = primero;
            while(lvl < 5)
            {
                temp.sup = new nivel(lvl);
                temp.sup.inf = temp;
                lvl++;
                temp = temp.sup;
            }
        }

        public unit buscar(int x_,int y_,int z_)
        {
            //obtener el nivel de búsqueda
            nivel temp = primero;
            while(temp != null)
            {
                if (temp.val == z_) break;
                else temp = temp.sup;
            }
            return temp.buscar(x_, y_);
        }
    }

    public class nivel
    {
        public coord horizontal;//listado de posiciones en x
        public coord vertical;//listado de posiciones en y
        public int val;
        public nivel sup;
        public nivel inf;

        public nivel() {}

        public nivel(int val_)
        {
            horizontal = null;
            vertical = null;
            val = val_;
            sup = null;
            inf = null;
        }
        //buscar un nodop
        public unit buscar(int x_,int y_)
        {
            //buscar la columna
            pos tempx = horizontal.buscar(x_);
            unit temp = tempx.primero;
            while(temp != null)
            {
                if (temp.y == y_) return temp;
                else temp = temp.abajo;
            }
            return null;
        }
        //insertar una unidad en el nivel
        public void insertar(unit nuevo,int x,int y)
        {
            if (horizontal == null) horizontal = new coord();
            if (vertical == null) vertical = new coord();
            //insertar en las coordenadas en x
            pos tempx = horizontal.buscar(x);
            if(tempx == null) tempx = horizontal.insertar(x);//insertar nueva coordenada en x
            unit ret = tempx.buscar(x, "X");
            if (ret == null)
            {
                //obtener el primer valor en la columna de tempx
                ret = tempx.primero;
                if (ret == null) tempx.primero = nuevo;
                else
                {
                    //insertar al inicio en la columna de tempx
                    if(ret.y > nuevo.y)
                    {
                        ret.arriba = nuevo;
                        nuevo.abajo = ret;
                        tempx.primero = nuevo;
                    }
                    else
                    {//insertar al medio
                        while(ret.abajo != null)
                        {
                            if (ret.abajo.y > nuevo.y)
                            {
                                nuevo.abajo = ret.abajo;
                                nuevo.arriba = ret;
                                ret.abajo.arriba = nuevo;
                                ret.abajo = nuevo;
                                break;
                            }
                            else ret = ret.abajo;
                            //insertar al final
                            if(ret.abajo == null)
                            {
                                ret.abajo = nuevo;
                                nuevo.arriba = ret;
                            }
                        }
                    }
                }
            }

            //insertar en las coordenadas en y
            pos tempy = vertical.buscar(y);
            if (tempy == null) tempy = vertical.insertar(y);//insertar nueva coordenada en x
            unit rety = tempy.buscar(y, "Y");
            if (rety == null)
            {
                //obtener el primer valor en la columna de tempx
                rety = tempy.primero;
                if (rety == null) tempy.primero = nuevo;
                else
                {
                    //insertar al inicio en la columna de tempx
                    if (rety.x > nuevo.x)
                    {
                        rety.izq = nuevo;
                        nuevo.der = rety;
                        tempy.primero = nuevo;
                    }
                    else
                    {//insertar al medio
                        while (rety.der != null)
                        {
                            if (rety.der.x > nuevo.x)
                            {
                                nuevo.der = rety.der;
                                nuevo.izq = rety;
                                rety.der.izq = nuevo;
                                rety.der = nuevo;
                                break;
                            }
                            else rety = rety.der;
                            //insertar al final
                            if (rety.der == null)
                            {
                                rety.der = nuevo;
                                nuevo.izq = rety;
                            }
                        }
                    }
                }
            }
        }
    }
}