using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectServer.master
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        graficarusuarios graficador;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            if(Application["arbolusuarios"] != null)
            {
                graficador = new graficarusuarios();
                binario bin = (binario)Application["arbolusuarios"];
                String rutaimagen = graficador.graficar(bin);
                arbol.ImageUrl = "/grafos/usuarios.dot.jpg";
            }
            
        }

        public void validarusuario()
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("~/master/loginmaster.aspx");
            }
        }
    }
}