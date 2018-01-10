using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectServer.master.masterjuegos
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        graficarb graficador;
        protected void Page_Load(object sender, EventArgs e)
        {
            graficador = new graficarb();
            arbolb historial = (arbolb)Application["historial"];
            if(historial != null)
            {
                String ruta = graficador.graficar(historial);
                grafob.ImageUrl = "/grafos/historial.dot.jpg";
            }
        }
    }
}