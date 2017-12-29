using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectServer.master.masterusers
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        graficarusuarios graficador;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            if (Application["arbolusuarios"] != null)
            {
                graficador = new graficarusuarios();
                binario bin = (binario)Application["arbolusuarios"];
                binario espejo = bin.espejo();
                String rutaimagen = graficador.graficar(espejo);
                arbol.ImageUrl = "/grafos/usuarios.dot.jpg";
            }
        }
    }
}