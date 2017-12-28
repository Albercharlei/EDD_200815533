using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectServer
{
    public class pos
    {
        public int val;
        public unit primero;
        public pos siguiente;
        public pos anterior;

        public pos() { }

        public pos(int val_)
        {
            primero = null;
            val = val_;
            siguiente = null;
            anterior = null;
        }

        public unit buscar(int val, String coord)
        {
            unit temp = primero;
            if (temp != null)
            {
                if (coord.Equals("X"))//buscar en las coordenadas en x
                {
                    while (temp != null)
                    {
                        if (temp.x == val) return temp;
                        else temp = temp.der;
                    }
                }
                else if (coord.Equals("Y"))//buscar en las coordenadas en y
                {
                    while (temp != null)
                    {
                        if (temp.y == val) return temp;
                        else temp = temp.abajo;
                    }
                }
            }
            return null;
        }
    }

    public class coord
    {
        public pos primero;

        public coord() { primero = null; }

        public pos buscar(int val_)
        {
            pos temp = primero;
            if (temp != null)
            {
                while (temp != null)
                {
                    if (temp.val == val_) return temp;
                    else temp = temp.siguiente;
                }
            }
            return null;
        }

        public pos insertar(int val_)
        {
            pos nuevo = new pos(val_);
            pos temp = primero;
            if (temp == null) primero = nuevo;

            else
            {
                //insertar al inicio
                if (temp.val > nuevo.val)
                {
                    temp.anterior = nuevo;
                    nuevo.siguiente = temp;
                    primero = nuevo;
                    return nuevo;
                }
                else
                {
                    //insertar al medio
                    while (temp.siguiente != null)
                    {
                        if (temp.siguiente.val > nuevo.val)
                        {
                            nuevo.siguiente = temp.siguiente;
                            temp.siguiente.anterior = nuevo;
                            nuevo.anterior = temp;
                            temp.siguiente = nuevo;
                            return nuevo;
                        }
                        else temp = temp.siguiente;
                    }
                }

            }
            return null;
        }
        //eliminar una coordenada
        public void eliminar(int val_)
        {
            pos temp = buscar(val_);
            if(temp != null)
            {
                if (temp.anterior != null) temp.anterior.siguiente = temp.siguiente;
                else
                {
                    primero = temp.siguiente;
                    temp.siguiente.anterior = null;
                }
                if (temp.siguiente != null) temp.siguiente.anterior = temp.anterior;
            }
        }
    }
}