using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ProyectServer
{
    /// <summary>
    /// Summary description for graficarusuarios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class graficarusuarios : System.Web.Services.WebService
    {
        
        [WebMethod]
        public String graficar(binario bin)
        {
            String dotgraph = "Digraph users {\nRankdir=TD\nnode [shape =circle]";
            usuario temp = bin.raiz;

            if (temp != null) dotgraph += usergraph(temp);
            //terminar grafo
            dotgraph += "}";

            return guardar(dotgraph);
        }

        //[WebMethod]
        public String usergraph(usuario user)
        {
            String salida = "";
            if (user != null)
            {
                salida += user.getnick() + " [label=\"Usuario: " + user.getnick() + "\nContraseña: " + user.getpass() + "\nemail: " + user.email + "\"];\n";
                if (user.izq != null)
                {
                    salida += usergraph(user.izq);
                    salida += user.getnick() + " -> " + user.izq.getnick() + ";\n";
                }
                if (user.der != null)
                {
                    salida += usergraph(user.der);
                    salida += user.getnick() + " -> " + user.der.getnick() + ";\n";
                }
                salida += listajuegos(user);
            }
            return salida;
        }

        public String listajuegos(usuario user)
        {
            if (user.listado != null)
            {
                String salida = "Subgraph lista" + user.getnick() + "{\nnode [shape =rectangle]";
                juego temp = user.listado.primero;
                //agregar nodos
                while (temp != null)
                {
                    salida += "lista" + user.getnick() + temp.cont.ToString() + " [label=\"Oponente: " + temp.oponente + "\nUnidades desplegadas: " + temp.desplegadas.ToString();
                    salida += "\nUnidades sobrevivientes: " + temp.sobrevivientes.ToString() + "\nUnidades destruidas: " + temp.destruidas.ToString();
                    switch (temp.gano)
                    {
                        case 0:
                            salida += "Resultado: derrota\"];\n";
                            break;
                        case 1:
                            salida += "Resultado: victoria\"];\n";
                            break;
                    }
                    temp = temp.siguiente;
                }
                //agregar apuntadores
                temp = user.listado.primero;
                salida += user.getnick() + " -> " + "lista" + user.getnick() + temp.cont.ToString() + ";\n";
                while(temp.siguiente != null)
                {
                    salida += "lista" + user.getnick() + temp.cont.ToString() + " -> lista" + user.getnick() + temp.siguiente.cont.ToString() + ";\n";
                    salida += "lista" + user.getnick() + temp.siguiente.cont.ToString() + " -> lista" + user.getnick() + temp.cont.ToString() + ";\n";
                    temp = temp.siguiente;
                }
                salida += "}\n";
                return salida;
            }

            else return null;
        }

        public String guardar(String grafo)
        {
            String ruta = HttpContext.Current.Server.MapPath("~/grafos/") + "\\usuarios.dot";
            //guardar archivo
            System.IO.File.WriteAllText(ruta, grafo);
            //cambiar el directorio
            String comando1 = "cd " + HttpContext.Current.Server.MapPath("~/grafos/");
            //generar grafo
            String comando2 = "dot -Tjpg -O usuarios.dot";
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
            return HttpContext.Current.Server.MapPath("~/") + "usuarios.dot.jpg";
        }
    }
}
