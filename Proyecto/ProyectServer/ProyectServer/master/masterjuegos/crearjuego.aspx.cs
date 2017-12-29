using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectServer.master.masterjuegos
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void crearjuego(object sender, EventArgs e)
        {
            binario usuarios = (binario)Application["arbolusuarios"];
            if (usuarios != null)
            {
                String nick1 = tbjugador1.Text;
                String nick2 = tbjugador2.Text;
                //buscar usuarios
                usuario user1 = usuarios.buscar(nick1, usuarios.raiz);
                usuario user2 = usuarios.buscar(nick2, usuarios.raiz);
                //validar usuarios
                if (user1 != null)
                {
                    if(user2 != null)
                    {
                        int x = Int32.Parse(tbx.Text);
                        int y = Int32.Parse(tby.Text);
                        int variante = Int32.Parse(ddlvariante.SelectedValue);
                        String tiempo = tbtiempo.Text;
                        mo tablero = new mo(x, y, variante, tiempo);
                        tablero.user1 = user1.getnick();
                        tablero.user2 = user2.getnick();
                        Application["tablero"] = tablero;//almacenar el juego actual
                        labelmensaje.Text = "La partida ha sido creada";
                    }
                    else labelmensaje.Text = "No se encontró el segundo jugador";
                }
                else labelmensaje.Text = "No se encontró el primer jugador";
                
            }
            else labelmensaje.Text = "No hay usuarios en el sistema";
        }
    }
}