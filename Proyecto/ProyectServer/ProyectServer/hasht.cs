using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ProyectServer
{
    public class hasht
    {
        public usuario[] listado;
        public double ocupacion;

        public hasht(binario usuarios)
        {
            listado = new usuario[43];
            insertarusers(usuarios.raiz);
        }

        public void insertar(usuario user, usuario[] listado_)
        {
            int pos = hash(user.getnick());//obtener posicion
            listado[pos] = user;//insertar usuario
            int cont = 0;
            int aux = 0;
            while(aux < listado_.Length)
            {
                if (listado_[aux] != null) cont++;
                aux++;
            }
            double porcentaje = (double)cont / (double)listado_.Length;
            ocupacion = porcentaje;
            //si el porcentaje de ocupacion maximo se ha alcanzado, expandir el listado
            if (porcentaje >= 0.5) expandir();
        }

        public int hash(String str)
        {
            //plegamiento, obtener suma de codigos ascii
            int suma = 0;
            foreach (char c in str) suma += c;
            //modular por el tamaño de la tabla
            int mod = suma % listado.Length;
            if (listado[mod] == null) return mod;//obtener posicion
            else return rehash(mod, 1);//aplicar politica de colision
        }

        public int rehash(int hash, int iter)
        {
            int cuadratico = hash + iter + (iter ^ 2);
            int ret = cuadratico % listado.Length;
            if (listado[ret] == null) return ret;
            else return rehash(hash, iter + 1);
        }

        public void expandir()
        {
            //crear nueva tabla
            int siguiente = nextprimo(listado.Length);
            usuario[] nuevo = new usuario[siguiente];
            //insertar los elementos
            for (int i = 0; i < listado.Length; i++) if (listado[i] != null) insertar(listado[i], nuevo);
            //sustituir tabla
            this.listado = nuevo;
        }

        public String graficar()
        {
            String dotgraph = "Digraph hash {\nRankdir = TD\nnode[shape = rectangle]\n";

            for(int i = 0; i < listado.Length; i++)
            {//agregar usuario si existe
                usuario temp = listado[i];
                if(temp != null)
                {//agregar nodos
                    dotgraph += temp.getnick() + " [label=\"Usuario: " + temp.getnick() + "\nContraseña: " + temp.getpass() + "\nemail: " + temp.email + "\nPosición: " + i.ToString() + "\"];\n";
                    int aux = i - 1;
                    while (aux >= 0)
                    {//agregar apuntador del nodo anterior si existe
                        if (listado[aux] != null && listado[aux] != temp)
                        {
                            dotgraph += listado[aux].getnick() + " -> " + temp.getnick() + ";\n";
                            break;
                        }
                        else aux--;
                    }
                }
            }
            //terminar el grafo
            dotgraph += "}";
            return guardar(dotgraph);
        }

        public String guardar(String grafo)
        {
            String ruta = HttpContext.Current.Server.MapPath("~/grafos/") + "\\hash.dot";
            //guardar archivo
            System.IO.File.WriteAllText(ruta, grafo);
            //cambiar el directorio
            String comando1 = "cd " + HttpContext.Current.Server.MapPath("~/grafos/");
            //generar grafo
            String comando2 = "dot -Tjpg -O hash.dot";
            //String comandoabrir = "usuarios.dot.jpg";
            //iniciar proceso de terminal
            System.Diagnostics.Process proceso = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
            info.FileName = "cmd.exe";
            info.RedirectStandardInput = true;
            info.UseShellExecute = false;
            proceso.StartInfo = info;
            proceso.Start();
            //agregar comandos
            StreamWriter sw = proceso.StandardInput;
            sw.WriteLine(comando1);
            sw.WriteLine(comando2);
            //sw.WriteLine(comandoabrir);
            sw.Close();
            return HttpContext.Current.Server.MapPath("~/") + "hash.dot.jpg";
        }

        public void insertarusers(usuario user)
        {
            if(user != null)
            {
                if (user.izq != null) insertarusers(user.izq);
                insertar(user, listado);
                if (user.der != null) insertarusers(user.der);
            }
        }

        public int nextprimo(int val)
        {
            int sig = val + 1;
            bool primo = false;
            while(primo == false)
            {
                if (esprimo(sig)) primo = true;
                else sig++;
            }
            return sig;
        }

        public bool esprimo(int num)
        {
            int div = 2;
            while(div < num)
            {
                if (num % div == 0) return false;
                else div++;
            }
            return true;
        }
    }
}