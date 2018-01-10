using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectServer
{
    public class ataque
    {
        public int x;//coordenadas en x
        public int y;//coordenadas en y
        public unit atacante;//unidad que ataca
        public unit defensor;//unidad que recibe el ataque
        public String resultado;//operación que muestra el daño o si la unidad fue destruida
        public String emisor;//usuario atacante
        public String receptor;//usuario defensor
        public DateTime fecha;//momento en que se hace el ataque
        public DateTime restante;//tiempo restante si aplica
        public int cont;//no de ataque
        //constructor para web service
        public ataque() { }

        public ataque(unit atacante_, unit defensor_, DateTime restante_, int cont_)
        {
            atacante = atacante_;
            defensor = defensor_;
            x = atacante_.x;
            y = atacante_.y;
            emisor = atacante_.user;
            receptor = defensor_.user;
            fecha = DateTime.Now;//obtener tiempo actual para la fecha
            restante = restante_;//tiempo restante de la partida
            cont = cont_;//no de ataque
        }
    }

    public class nodob
    {
        public ataque[] llaves;
        public int grado;//grado del nodo
        //public int?[] llaves;//arreglo de llaves
        public nodob[] hijos;//arreglo de hijos
        public nodob padre;//nodo padre
        public int tipo;//tipo de ordenamiento

        //constructor para web service
        public nodob() { }

        public nodob(int grado_, int tipo_)
        {
            grado = grado_;
            //llaves = new int?[grado];
            llaves = new ataque[grado];
            hijos = new nodob[grado+1];
            padre = null;
            tipo = tipo_;//si es 0, el ordenamiento es por fecha, si es 1, es por numero de ataque
        }

        //método de inserción en nodo
        public void insertar(/*int n,*/ataque ingreso, nodob nodoizq, nodob nododer)
        {
            //inserción de la llave
            int temp = 0;
            if (llaves[temp] == null) llaves[temp] = ingreso;
            else
            {
                //obtener el espacio de la inserción
                while (llaves[temp] != null)
                {
                    //ordenamiento por fecha
                    if(tipo == 0)
                    {
                        if (llaves[temp].fecha == ingreso.fecha)
                        {//encontrar la posición si la fecha es igual
                            if (llaves[temp].cont > ingreso.cont) break;//posición actual
                            else if(llaves[temp].cont < ingreso.cont)
                            {
                                temp++;//posición siguiente
                                //if (temp == grado) break;
                            }
                        }
                        else if (llaves[temp].fecha > ingreso.fecha) break;
                        else temp++;
                    }
                    //ordenamiento por numero
                    else if(tipo == 1)
                    {
                        if (llaves[temp].cont >= ingreso.cont) break;
                        else temp++;
                    }
                }
                //copiar el arreglo de llaves
                //int?[] aux = new int?[grado];

                ataque[] aux = new ataque[grado];
                aux = llaves;
                //insertar la nueva llave
                aux[temp] = ingreso;
                //correr los elementos
                for(int i = temp + 1; i < grado; i++) aux[i] = llaves[i];
                llaves = aux;//sustituir la lista de llaves
            }
            //inserción de los hijos
            if(nodoizq != null && nododer != null)
            {
                nodoizq.padre = this;
                nododer.padre = this;
                //copiar arreglo de hijos
                nodob[] nodotemp = new nodob[grado + 1];
                nodotemp = hijos;
                //insertar los valores
                nodotemp[temp] = nodoizq;
                nodotemp[temp + 1] = nododer;
                //correr los elementos
                for (int j = temp + 2; j < grado + 1; j++) nodotemp[j] = hijos[j];
                hijos = nodotemp;//sustituir los hijos
            }
        }

        //método de división de nodos hoja
        public nodob dividir()
        {//cuando el grado es impar, el valor del medio es llaves[grado/2]
            //metodo de prueba para llaves tipo int?
            /*int medio = llaves[grado/2].Value;
            //hijo izquierdo
            nodob izq = new nodob(grado);
            //obtener lista de llaves izquierdas
            for (int i = 0; i < grado / 2; i++) izq.llaves[i] = llaves[i];
            //obtener lista de hijos izquierdos
            for (int i = 0; i < grado / 2 + 1; i++) izq.hijos[i] = hijos[i];
            //hijo derecho
            nodob der = new nodob(grado);
            //obtener lista de llaves derechas
            for (int i = grado/2 +1; i < grado; i++) der.llaves[i] = llaves[i];
            //obtener lista de hijos derechos
            for (int i = grado/2 + 1; i < grado + 1; i++) der.hijos[i] = hijos[i];
            //insertar los valores en el nodo padre
            if(padre == null) padre = new nodob(grado);
            padre.insertar(medio, izq, der);
            return padre;*/
            //metodo para llaves tipo ataque
            ataque medio = llaves[grado / 2];
            //hijo izquierdo
            nodob izq = new nodob(grado,this.tipo);
            //obtener lista de llaves izquierdas
            for (int i = 0; i < grado / 2; i++) izq.llaves[i] = llaves[i];
            //obtener lista de hijos izquierdos
            for (int i = 0; i < grado / 2 + 1; i++) izq.hijos[i] = hijos[i];
            //hijo derecho
            nodob der = new nodob(grado, this.tipo);
            //obtener lista de llaves derechas
            for (int i = grado / 2 + 1; i < grado; i++) der.llaves[i - (grado / 2) - 1] = llaves[i];
            //obtener lista de hijos derechos
            for (int i = grado / 2 + 1; i < grado + 1; i++) der.hijos[i - (grado / 2) - 1] = hijos[i];
            //insertar los valores en el nodo padre
            if (padre == null) padre = new nodob(grado, this.tipo);
            padre.insertar(medio, izq, der);
            return padre;
        }

        //eliminar llave del nodo
        //public void eliminar(int n)
        public void eliminar(ataque registro)
        {
            int pos = 0;
            while(llaves[pos] != null)
            {
                if (llaves[pos] == registro) break;//obtener la posición de la llave a eliminar
                else pos++;//continuar con la búsqueda
            }
            //el nodo es una hoja
            if (hijos[0] == null)
            {
                //int?[] nuevo = new int?[grado];//prueba con llaves tipo int?
                ataque[] nuevo = new ataque[grado];
                //copiar las llaves
                for (int i = 0; i < pos; i++) if (i != pos) nuevo[i] = llaves[i];
                for (int i = pos + 1; i < grado; i++) nuevo[i - 1] = llaves[i];
                //verificar si se tiene la cantidad minima de llaves
                bool ismin = true;
                for (int i = 0; i < grado / 2; i++) if (nuevo[i] == null) ismin = false;
                if(ismin == false)
                {
                    //obtener nodo con las llaves del nodo y el nodo padre izquierdo
                    if(padre != null)
                    {
                        //int llaveadd = 0;
                        //ataque llaveadd;
                        try
                        {//obtener la llave izquierda del padre
                            if (padre.llaves[pos - 1] != null) //llaveadd = padre.llaves[pos - 1];
                            { padre.combinarhijos(pos - 1, false); }//combinar los hijos de la llave del padre, sin eliminar la llave
                        }
                        catch(IndexOutOfRangeException e)
                        {//padre.llaves[pos-1] está fuera del rango, se toma la llave derecha del padre por ser el primer elemento
                            //llaveadd = padre.llaves[pos];
                            padre.combinarhijos(pos, false);//combinar los hijos de la llave del padre, sin eliminar la llave
                        }
                    }
                }//else, se ha eliminado un elemento y el nodo tiene el número mímmino de elementos
            }
            //el nodo no es una hoja
            else
            {
                //verificar si el hijo izquierdo puede donar una llave
                nodob hijo = hijos[pos];
                int cont = 0;
                while (hijo.llaves[cont] != null) cont++;
                if(cont > grado / 2)
                {//el hijo izquierdo tiene suficientes elementos para donar el mayor
                    ataque sustituto = hijo.llaves[cont - 1];//obtener la llave mayor
                    hijo.eliminar(sustituto);//eliminar el elemento mayor en el hijo
                    llaves[pos] = sustituto;//correr la llave mayor a la lista de llaves
                }
                else
                {//verificar si el hijo derecho puede donar una llave
                    cont = 0;
                    hijo = hijos[pos + 1];
                    while (hijo.llaves[cont] != null) cont++;
                    if (cont > grado / 2)
                    {//el hijo derecho tiene suficientes elementos para donar el menor
                        ataque sustituto = hijo.llaves[0];//obtener la llave menor
                        hijo.eliminar(sustituto);//eliminar el elemento mayor en el hijo
                        llaves[pos] = sustituto;//correr la llave mayor a la lista de llaves
                    }
                    //ninguno de los hijos tiene suficientes llaves
                    else this.combinarhijos(pos, true);//combinar hijos, eliminar llave
                }
            }
        }

        public void combinarhijos(int pos, bool eliminar)
        {
            //int?[] insert = new int?[grado + 1];
            ataque[] insert = new ataque[grado + 1];
            if (eliminar == false)//no se debe eliminar la llave
            {
                insert[0] = llaves[pos];//obtener llave a mover
                                        //agregar el resto de las llaves del hijo izquierdo
                for (int i = 0; i < grado; i++) insert[i + 1] = hijos[pos + 1].llaves[i];
            }//agregar sólo las llaves del hijo izquierdo
            else for (int i = 0; i < grado; i++) insert[i] = hijos[pos + 1].llaves[i];
            //correr las llaves
            for (int i = pos; i < grado - 1; i++) llaves[i] = llaves[i + 1];
            llaves[grado - 1] = null;
            //obtener hijo que se va a combinar
            nodob hijocomb = hijos[pos + 1];//hijo derecho a la llave
                                            //correr hijos
            for (int i = pos + 1; i < grado; i++) hijos[i] = hijos[i + 1];
            //reinsertar las llaves al nodo
            for (int i = 0; i < grado + 1; i++) if (insert[i] != null) this.insertar(insert[i], null, null);
        }
    }


    public class arbolb
    {
        public int grado;//grado del árbol
        public nodob raiz;
        public int tipo;//tipo de ordenacion, si es 0, es por fecha, si es 1, es por numero de ataque

        //constructor para web service
        public arbolb() { }

        public arbolb(int grado_, int tipo_)
        {
            grado = grado_;
            raiz = null;
            tipo = tipo_;
        }

        //búsqueda de nodo
        //public nodob buscar(int n, nodob nodo)
        public nodob buscar(ataque registro, nodob nodo)
        {
            if (nodo != null)
            {
                if (nodo.llaves[0] != null)
                {
                    int pos = 0;
                    while (nodo.llaves[pos] != null)
                    {
                        if (nodo.llaves[pos] == registro) return nodo;
                        else
                        {
                            if(tipo == 0)//búsqueda por fecha
                            {
                                if(nodo.llaves[pos].fecha == registro.fecha)
                                {//si la fecha es igual, comparar el número de ataque
                                    if(nodo.llaves[pos].cont > registro.cont)
                                    {
                                        if (nodo.hijos[pos] != null) return buscar(registro, nodo.hijos[pos]);
                                        else return null;
                                    }
                                }
                                else if (nodo.llaves[pos].fecha > registro.fecha)
                                {
                                    if (nodo.hijos[pos] != null) return buscar(registro, nodo.hijos[pos]);
                                    else return null;
                                }
                                else pos++;
                            }
                            else if(tipo == 1)//la búsqueda es por numero de ataque
                            {
                                if (nodo.llaves[pos].cont > registro.cont)
                                {
                                    if (nodo.hijos[pos] != null) return buscar(registro, nodo.hijos[pos]);
                                    else return null;
                                }
                                else pos++;
                            }
                        }
                    }
                    if (nodo.hijos[pos] != null) return buscar(registro, nodo.hijos[pos]);
                    else return null;
                }
                else return null;
            }
            else return null;
        }

        //método de búsqueda de nodo para inserción, empieza por la raíz
        //actualizar para inserción con el mismo valor
        //public nodob buscarinsert(int n, nodob nodo)
        public nodob buscarinsert(ataque registro, nodob nodo)
        {
            if (nodo != null)
            {
                if (nodo.hijos[0] == null) return nodo;//el nodo es una hoja
                else
                {
                    int aux = 0;
                    //buscar el hijo
                    while(nodo.llaves[aux] != null)
                    {
                        //buscar por fecha
                        if(tipo == 0)
                        {
                            if (nodo.llaves[aux].fecha == registro.fecha)
                            {//buscar por numero si la fecha es igual
                                if (nodo.llaves[aux].cont > registro.cont)
                                {
                                    if (nodo.hijos[0] != null) return buscarinsert(registro, nodo.hijos[aux]);
                                    else return nodo;
                                }
                                else aux++;//continuar con la siguiente llave
                            }
                            else if (nodo.llaves[aux].fecha > registro.fecha) return buscarinsert(registro, nodo.hijos[aux]);
                            else aux++;
                        }
                        //buscar por numero
                        else if(tipo == 1)
                        {
                            if (nodo.llaves[aux].cont > registro.cont) return buscarinsert(registro, nodo.hijos[aux]);
                            else aux++;
                        }
                    }
                    //buscar en el último valor si todos los anteriores son menores
                    return buscarinsert(registro, nodo.hijos[aux]);
                }
            }
            else return null;
        }

        public nodob insertar(ataque nuevo/*, unit atacante_, unit defensor_, DateTime restante_, int cont_*/)
        {
            //buscar nodo de inserción
            nodob insert = buscarinsert(nuevo, raiz);
            if (insert == null)
            {
                raiz = new nodob(grado, tipo);
                insert = raiz;
            }
            //realizar la inserción 
            insert.insertar(nuevo, null, null);
            //si el nodo está lleno, dividir el nodo
            if (insert.llaves[grado - 1] != null)
            {
                nodob ret = insert.dividir();
                if (ret.padre == null) raiz = ret;
                return ret;
            }
            else return insert;
        }

        //eliminar nodo
        /*public nodob eliminar(int n)
        {

        }*/
    }
}
