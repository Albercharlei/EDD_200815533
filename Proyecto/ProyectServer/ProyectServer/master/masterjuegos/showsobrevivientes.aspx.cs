using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectServer.master.masterjuegos
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        graficartablero graficador;
        tablerofinal tabfinal;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            if (Application["tablero"] != null)
            {
                graficador = new graficartablero();
                tabfinal = new tablerofinal();
                mo tab = (mo)Application["tablero"];
                mo final = tabfinal.finalsobrevivientes(tab);
                graficador.graficar(final);
                lvl1.ImageUrl = "/grafos/nivel1.dot.jpg";
                lvl2.ImageUrl = "/grafos/nivel2.dot.jpg";
                lvl3.ImageUrl = "/grafos/nivel3.dot.jpg";
                lvl4.ImageUrl = "/grafos/nivel4.dot.jpg";
            }
        }
    }
}