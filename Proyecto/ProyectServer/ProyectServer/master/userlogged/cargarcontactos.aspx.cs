using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectServer.master.userlogged
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /*
        protected void cargar(object sender, EventArgs e)
        {
            if (fileup.HasFile)
            {
                String ruta = HttpContext.Current.Server.MapPath("~/cargas/") + fileup.FileName;//obtener nombre de ruta
                fileup.SaveAs(ruta);
                String entrada = File.ReadAllText(ruta);//leer texto
                //obtener cada línea del texto
                String[] lineas = entrada.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                //separa por comas
                usuario user = (usuario)Session["user"];//obtener el nodo de la session de usuario
                avl contactos = new avl();
                for (int i = 1; i < lineas.Length; i++)
                {
                    String[] contenido = lineas[i].Split(',');
                    //ingresar el contenido
                    try
                    {
                        String nickname = contenido[0].ToString();
                        String pass = contenido[1].ToString();
                        contactos.insertar(nuevouser, contactos.raiz);
                    }
                    catch (IndexOutOfRangeException ex) { String outex = ex.ToString(); }
                }
                Application["arbolusuarios"] = bin;
            }
        }*/
    }
}