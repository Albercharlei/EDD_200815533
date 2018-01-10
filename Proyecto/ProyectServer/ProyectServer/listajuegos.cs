using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectServer
{
    public class listajuegos
    {
        public juego primero;
        public int cont;

        public listajuegos() {
            primero = null;
        }

        public juego insertar(String userbase_, String oponente_, int desplegadas_, int sobrevivientes_, int destruidas_, int gano_)
        {
            juego nuevo = new juego(userbase_, oponente_, desplegadas_, sobrevivientes_, destruidas_, gano_);
            nuevo.cont = this.cont;
            juego temp = primero;
            if (temp == null) primero = nuevo;
            else
            {
                while(temp.siguiente != null) { temp = temp.siguiente; }
                temp.siguiente = nuevo;
                nuevo.anterior = temp;
            }
            cont++;
            return nuevo;
        }
    }

    public class juego
    {
        public String userbase;
        public String oponente;
        public juego siguiente;
        public juego anterior;
        public int desplegadas;
        public int sobrevivientes;
        public int destruidas;
        public int gano;
        public int cont;

        public juego() { }

        public juego(String userbase_,String oponente_,int desplegadas_,int sobrevivientes_,int destruidas_,int gano_)
        {
            userbase = userbase_;
            oponente = oponente_;
            desplegadas = desplegadas_;
            sobrevivientes = sobrevivientes_;
            destruidas = destruidas_;
            gano = gano_;
            cont = 1;
            siguiente = null;
            anterior = null;
        }

        public class nodotopjuegos
        {
            public juego info;
            public nodotopjuegos anterior;
            public nodotopjuegos siguiente;
            public int ataques;

            public nodotopjuegos(juego ingreso)
            {
                info = ingreso;
                anterior = null;
                siguiente = null;
            }
        }

        public class topjuegos
        {
            public nodotopjuegos primero;
            public nodotopjuegos ultimo;

            public topjuegos()
            {
                primero = null;
                ultimo = null;
            }

            public void insertar(juego ingreso)
            {
                nodotopjuegos nuevo = new nodotopjuegos(ingreso);

                nodotopjuegos temp = primero;
                if(temp == null)
                {
                    primero = nuevo;
                    ultimo = nuevo;
                }

                else
                {
                    //insertar al inicio
                    //if(temp.info.)
                }
            }
        }
    }
}