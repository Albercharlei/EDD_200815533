using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ProyectServer
{
    /// <summary>
    /// Summary description for graficaravl
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class graficaravl : System.Web.Services.WebService
    {

        [WebMethod]
        public String graficar(avl arbol)
        {
            String dotgraph = "Digraph contactos {\nRankdir=TD\nnode [shape =circle]\n";
            if(arbol != null)
            {
                nodoavl temp = arbol.raiz;
                if (temp != null)
                {
                    dotgraph += agregarnodos(temp);
                }
            }

            dotgraph += "}";//finalizar grafo

            return guardar(dotgraph);//retornar la dirección de la imagen
        }

        public String agregarnodos(nodoavl user)
        {
            String salida = "";
            if (user != null)
            {
                salida += user.nick + " [label=\"Usuario: " + user.nick + "\nContraseña: " + user.pass + "\nemail: " + user.email + "\"];\n";
                if (user.izq != null)
                {
                    salida += agregarnodos(user.izq);
                    salida += user.nick + " -> " + user.izq.nick + ";\n";
                }
                if (user.der != null)
                {
                    salida += agregarnodos(user.der);
                    salida += user.nick + " -> " + user.der.nick + ";\n";
                }
            }
            return salida;
        }

        public String guardar(String grafo)
        {
            String ruta = HttpContext.Current.Server.MapPath("~/grafos/") + "\\contactos.dot";
            //guardar archivo
            System.IO.File.WriteAllText(ruta, grafo);
            //cambiar el directorio
            String comando1 = "cd " + HttpContext.Current.Server.MapPath("~/grafos/");
            //generar grafo
            String comando2 = "dot -Tjpg -O contactos.dot";
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
            return HttpContext.Current.Server.MapPath("~/") + "contactos.dot.jpg";
        }
    }
}
