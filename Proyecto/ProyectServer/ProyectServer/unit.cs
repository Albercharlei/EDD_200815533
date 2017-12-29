using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectServer
{
    public class unit
    {
        public String id;//nombre de la unidad
        public int x;//coordenada en x
        public int y;//coordenada en y
        public int nivel;//coordenada en z
        public int mov;
        public int rmin;
        public int rmax;
        public int hp;
        public int atk;
        public String user;
        public int existe;//indica si existe o no en el tablero

        public unit izq;
        public unit der;
        //punteros en y
        public unit arriba;
        public unit abajo;
        //punteros en z
        public unit sup;
        public unit inf;

        public unit() { }

        public unit(String id_, int x_, int y_)
        {
            id = id_;
            x = x_;
            y = y_;
            if (id_.Contains("Neosatelite"))
            {
                nivel = 4;
                mov = 6;
                rmin = 0;
                rmax = 0;
                hp = 10;
                atk = 2;
            }
            else if (id_.Contains("Bombardero"))
            {
                nivel = 3;
                mov = 7;
                rmin = 0;
                rmax = 0;
                hp = 10;
                atk = 5;
            }
            else if (id_.Contains("Caza"))
            {
                nivel = 3;
                mov = 9;
                rmin = 1;
                rmax = 1;
                hp = 20;
                atk = 2;
            }
            else if (id_.Contains("Helicoptero"))
            {
                nivel = 3;
                mov = 9;
                rmin = 1;
                rmax = 1;
                hp = 15;
                atk = 3;
            }
            else if (id_.Contains("Fragata"))
            {
                nivel = 2;
                mov = 5;
                rmin = 2;
                rmax = 6;
                hp = 10;
                atk = 3;
            }
            else if (id_.Contains("Crucero"))
            {
                nivel = 2;
                mov = 6;
                rmin = 1;
                rmax = 1;
                hp = 15;
                atk = 3;
            }
            else if (id_.Contains("Submarino"))
            {
                nivel = 1;
                mov = 5;
                rmin = 1;
                rmax = 1;
                hp = 10;
                atk = 2;
            }

            existe = 1;
        }
    }
}