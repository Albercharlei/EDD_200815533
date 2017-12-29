using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ProyectServer.master.masterusers
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["arbolusuarios"] == null) Application["arbolusuarios"] = new binario();
        }

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
                binario bin = (binario)Application["arbolusuarios"];
                for (int i=1; i < lineas.Length; i++)
                {
                    String[] contenido = lineas[i].Split(',');
                    //ingresar el contenido
                    try
                    {
                        bin.insertar(contenido[0], contenido[1], contenido[2], Int32.Parse(contenido[3].ToString()), bin.raiz);
                    }
                    catch(IndexOutOfRangeException ex) { String outex = ex.ToString(); }
                }
                Application["arbolusuarios"] = bin;
            }
        }
    }
}