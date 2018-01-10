using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectServer.master.masterusers
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            binario usuarios = (binario)Application["arbolusuarios"];
            if(usuarios != null)
            {//insertar usuarios en el diccionario
                hasht diccionario = new hasht(usuarios);
                //generar grafo
                diccionario.graficar();
                tablahash.ImageUrl = "/grafos/hash.dot.jpg";
                labelocupacion.Text = "Porcentaje de ocupación: " + diccionario.ocupacion.ToString();
                labelsize.Text = "Tamaño de la tabla: " + diccionario.listado.Length.ToString();
            }
        }
    }
}