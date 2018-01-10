using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ProyectServer
{
    /// <summary>
    /// Summary description for graficarb
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class graficarb : System.Web.Services.WebService
    {

        [WebMethod]
        public String graficar(arbolb arbol)
        {
            String dotgraph = "Digraph historial {\nRankdir=TD\nnode [shape = record]\n";

            if (arbol.raiz != null) dotgraph += addnodos(arbol.raiz);

            dotgraph += "}";//terminar el grafo
            //retornar la direccion del grafo
            return guardar(dotgraph);
        }
        //graficar los nodos
        public String addnodos(nodob ingreso)
        {
            String salida = "";
            if (ingreso != null)
            {
                salida += "nodob" + ingreso.llaves[0].cont.ToString();//el numero del nodo es el primer numero que aparece en las llaves
                int pos = 0;
                if (ingreso.llaves[pos] != null)
                {//ingresar primera posicion
                    salida += " [label = \"<h" + pos.ToString() + ">|<l" + pos.ToString() + "> Atacante: " + ingreso.llaves[pos].atacante.id + "\n";
                    salida += "Defensor: " + ingreso.llaves[pos].defensor.id + "\nResultado: " + ingreso.llaves[pos].resultado + "\n";
                    salida += "Emisor: " + ingreso.llaves[pos].emisor + "\nReceptor: " + ingreso.llaves[pos].receptor + "\n";
                    salida += "Fecha: " + ingreso.llaves[pos].fecha.ToString() + "\nTiempo restante: " + ingreso.llaves[pos].restante.ToLongTimeString() + "\n";
                    salida += "Número de ataque: " + ingreso.llaves[pos].cont.ToString();
                }
                pos++;
                while (ingreso.llaves[pos] != null)
                {
                    salida += "|<h" + pos.ToString() + ">|<l" + pos.ToString() + "> Atacante: " + ingreso.llaves[pos].atacante.id + "\n";
                    salida += "Defensor: " + ingreso.llaves[pos].defensor.id + "\nResultado: " + ingreso.llaves[pos].resultado + "\n";
                    salida += "Emisor: " + ingreso.llaves[pos].emisor + "\nReceptor: " + ingreso.llaves[pos].receptor + "\n";
                    salida += "Fecha: " + ingreso.llaves[pos].fecha.ToString() + "\nTiempo restante: " + ingreso.llaves[pos].restante.ToLongTimeString() + "\n";
                    salida += "Número de ataque: " + ingreso.llaves[pos].cont.ToString();
                    pos++;
                }
                //ingresar final de nodo
                salida += "|<h" + pos.ToString() + ">\"];\n";
                //ingresar nodos hijos
                pos = 0;
                if (ingreso.hijos[pos] != null)
                {
                    while (ingreso.hijos[pos] != null)
                    {
                        salida += addnodos(ingreso.hijos[pos]);
                        salida += "nodob" + ingreso.llaves[0].cont.ToString() + ":h" + pos.ToString() + "->" + "nodob" + ingreso.hijos[pos].llaves[0].cont.ToString() + ";\n";
                        pos++;
                    }
                }
            }
            return salida;
        }
        //guardar la imagen del grafo
        public String guardar(String grafo)
        {
            String ruta = HttpContext.Current.Server.MapPath("~/grafos/") + "\\historial.dot";
            //guardar archivo
            System.IO.File.WriteAllText(ruta, grafo);
            //cambiar el directorio
            String comando1 = "cd " + HttpContext.Current.Server.MapPath("~/grafos/");
            //generar grafo
            String comando2 = "dot -Tjpg -O historial.dot";
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
            return HttpContext.Current.Server.MapPath("~/") + "historial.dot.jpg";
        }
    }
}
