using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ProyectServer
{
    /// <summary>
    /// Summary description for graficartablero
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class graficartablero : System.Web.Services.WebService
    {

        [WebMethod]
        public void graficar(mo ingreso)
        {
            //generar grafo del primer nivel
            nivel temp = ingreso.primero;
            while(temp != null)
            {
                graficarnivel(temp);
                temp = temp.sup;
            }
        }

        public void graficarnivel(nivel ingreso)
        {
            String dotgraph = "Digraph nivel" + ingreso.val.ToString() + "{\nRankdir=TD\nnode [shape =rectangle]";
            if (ingreso.horizontal != null)
            {
                pos tempx = ingreso.horizontal.primero;
                //agregar nodos de las cabeceras
                dotgraph += "{rank=min;";
                while (tempx.siguiente != null)
                {
                    dotgraph += "Pos" + tempx.val.ToString() + "x [label=\"" + "Pos" + tempx.val.ToString() + "x\"];\n";
                    tempx = tempx.siguiente;
                }
                dotgraph += "Pos" + tempx.val.ToString() + "x [label=\"" + "Pos" + tempx.val.ToString() + "x\"]};\n";

                //agregar apuntadores de coordenadas en x
                tempx = ingreso.horizontal.primero;
                while (tempx.siguiente != null)
                {
                    dotgraph += "Pos" + tempx.val.ToString() + "x -> " + "Pos" + tempx.siguiente.val.ToString() + "x;\n";
                    dotgraph += "Pos" + tempx.siguiente.val.ToString() + "x -> " + "Pos" + tempx.val.ToString() + "x;\n";
                    tempx = tempx.siguiente;
                }
                //agregar filas
                pos tempy = ingreso.vertical.primero;
                while (tempy != null)
                {
                    dotgraph += "{rank=same;" + "Pos" + tempy.val.ToString() + "y [label=\"" + "Pos" + tempy.val.ToString() + "y\"]";
                    unit temp = tempy.primero;
                    while (temp != null)
                    {
                        dotgraph += ";Unit" + temp.id + temp.x.ToString() + temp.y.ToString();
                        dotgraph += " [label=\"Unidad: " + temp.id + "\nHp: " + temp.hp.ToString() + "\nAtaque: " + temp.atk.ToString() + "\nMovimiento: " + temp.mov.ToString() + "\"]";
                        temp = temp.der;
                    }
                    dotgraph += "};\n";
                    tempy = tempy.siguiente;
                }
                //agregar apuntadores verticales
                tempx = ingreso.horizontal.primero;
                while (tempx != null)
                {
                    unit temp = tempx.primero;
                    dotgraph += "Pos" + tempx.val.ToString() + "x -> Unit" + temp.id + temp.x.ToString() + temp.y.ToString() + ";\n";
                    while (temp.abajo != null)
                    {
                        dotgraph += "Unit" + temp.id + temp.x.ToString() + temp.y.ToString() + " -> " + "Unit" + temp.abajo.id + temp.abajo.x.ToString() + temp.abajo.y.ToString() + ";\n";
                        dotgraph += "Unit" + temp.abajo.id + temp.abajo.x.ToString() + temp.abajo.y.ToString() + " -> " + "Unit" + temp.id + temp.x.ToString() + temp.y.ToString() + ";\n";
                        temp = temp.abajo;
                    }
                    tempx = tempx.siguiente;
                }
                //agregar apuntadores de cabeceras en y
                tempy = ingreso.vertical.primero;
                while (tempy.siguiente != null)
                {
                    dotgraph += "Pos" + tempy.val.ToString() + "y -> " + "Pos" + tempy.siguiente.val.ToString() + "y;\n";
                    dotgraph += "Pos" + tempy.siguiente.val.ToString() + "y -> " + "Pos" + tempy.val.ToString() + "y;\n";
                    tempy = tempy.siguiente;
                }
                //agregar apuntadores horizontales
                tempy = ingreso.vertical.primero;
                while (tempy != null)
                {
                    unit temp = tempy.primero;
                    dotgraph += "Pos" + tempy.val.ToString() + "y -> Unit" + temp.id + temp.x.ToString() + temp.y.ToString() + ";\n";
                    while (temp.der != null)
                    {
                        dotgraph += "Unit" + temp.id + temp.x.ToString() + temp.y.ToString() + " -> " + "Unit" + temp.der.id + temp.der.x.ToString() + temp.der.y.ToString() + ";\n";
                        dotgraph += "Unit" + temp.der.id + temp.der.x.ToString() + temp.der.y.ToString() + " -> " + "Unit" + temp.id + temp.x.ToString() + temp.y.ToString() + ";\n";
                        temp = temp.der;
                    }
                    tempy = tempy.siguiente;
                }
            }
            
            //terminar grafo
            dotgraph += "}\n";
            //generar grafo
            guardar(dotgraph, ingreso.val);
        }

        public void guardar(String grafo,int nivel)
        {
            String ruta = HttpContext.Current.Server.MapPath("~/grafos/") + "\\nivel"+nivel.ToString()+".dot";
            //guardar archivo
            System.IO.File.WriteAllText(ruta, grafo);
            //cambiar el directorio
            String comando1 = "cd " + HttpContext.Current.Server.MapPath("~/grafos/");
            //generar grafo
            String comando2 = "dot -Tjpg -O nivel" + nivel.ToString() + ".dot";
            //String comandoabrir = "nivel" + nivel.ToString() + ".dot.jpg";
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
        }
    }
}
