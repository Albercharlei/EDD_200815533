using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectServer.master.masterjuegos
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        graficarlistadejuegos graficador;
        protected void Page_Load(object sender, EventArgs e)
        {
            graficador = new graficarlistadejuegos();
            listajuegos listado = (listajuegos)Application["juegos"];
            if(listado != null)
            {
                graficador.graficar(listado);
                grafojuegos.ImageUrl = "/grafos/listajuegos.dot.jpg";
            }
        }
    }
}