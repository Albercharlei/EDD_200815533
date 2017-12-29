using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectServer.master.masterjuegos
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mo tablero = (mo)Application["tablero"];
            if(tablero != null)
            {
                //agregar los usuarios del juego actual
                ddluser.Items.Add(tablero.user1);
                ddluser.Items.Add(tablero.user2);
            }

        }

        protected void insertar(object sender, EventArgs e)
        {
            mo tablero = (mo)Application["tablero"];
            if (tablero != null)
            {
                String user = ddluser.SelectedValue;
                String col = tbcolumna.Text;
                int fila = Int32.Parse(tbfila.Text);
                String id = ddltipo.SelectedValue + tbno.Text;
                int existe = Int32.Parse(ddldestruido.SelectedValue);
                //ingresar el contenido
                tablero.insertar(col, fila, id, user, existe);
                Application["tablero"] = tablero;
                labelmensaje.Text = "Unidad insertada";
            }
            else labelmensaje.Text = "No hay una partida activa";
        }

        
    }
}