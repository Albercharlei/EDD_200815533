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
                int altura = bin.altura(bin.raiz);
                int niveles = altura - 1;
                int hojas = bin.hojas(0, bin.raiz);
                int ramas = bin.ramas(0, bin.raiz);

                labelaltura.Text = altura.ToString();
                labelniveles.Text = niveles.ToString();
                labelhojas.Text = hojas.ToString();
                labelramas.Text = ramas.ToString();
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