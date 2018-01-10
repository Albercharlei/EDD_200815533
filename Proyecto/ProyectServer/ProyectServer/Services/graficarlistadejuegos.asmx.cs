using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ProyectServer
{
    /// <summary>
    /// Summary description for graficarlistadejuegos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class graficarlistadejuegos : System.Web.Services.WebService
    {

        [WebMethod]
        public String graficar(listajuegos listado)
        {
            String dotgraph = "Digraph juegos {\nRankdir=TD\nnode [shape =rectangle]\n";
            if (listado != null)
            {
                juego temp = listado.primero;
                while(temp != null)
                {
                    dotgraph += "juego" + temp.cont.ToString() + " [label=\"Jugador 1: " + temp.userbase + "\nJugador 2: " + temp.oponente;
                    dotgraph += "\nUnidades desplegadas: " + temp.desplegadas.ToString() + "\nUnidades sobrevivientes: " + temp.sobrevivientes.ToString() + "\nUnidades destruidas" + temp.destruidas.ToString();
                    if (temp.gano == 0) dotgraph += "\nGanó: Sí\"];\n";
                    else if (temp.gano == 1) dotgraph += "\nGanó: No\"];\n";
                    if (temp.anterior != null)
                    {
                        dotgraph += "juego" + temp.anterior.cont.ToString() + " -> juego" + temp.cont.ToString() + ";\n";
                        dotgraph += "juego" + temp.cont.ToString() + " -> juego" + temp.anterior.cont.ToString() + ";\n";
                    }
                        temp = temp.siguiente;
                }
            }

            dotgraph += "}";//finalizar grafo

            return guardar(dotgraph);//retornar la dirección de la imagen
        }

        public String guardar(String grafo)
        {
            String ruta = HttpContext.Current.Server.MapPath("~/grafos/") + "\\listajuegos.dot";
            //guardar archivo
            System.IO.File.WriteAllText(ruta, grafo);
            //cambiar el directorio
            String comando1 = "cd " + HttpContext.Current.Server.MapPath("~/grafos/");
            //generar grafo
            String comando2 = "dot -Tjpg -O listajuegos.dot";
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
            return HttpContext.Current.Server.MapPath("~/") + "listajuegos.dot.jpg";
        }
    }
}
