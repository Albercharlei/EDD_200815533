using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectServer.master.masterusers
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        mainlogin mainlogin;
        graficaravl graficador;
        protected void Page_Load(object sender, EventArgs e)
        {
            //mainlogin = new mainlogin();
            //mainlogin.pruebauser();//cargar arbol de jugadores
            graficador = new graficaravl();
            //obtener arbol de contactos
            if (!IsPostBack)//llenar la lista de usuarios una vez
            {
                binario bin = (binario)Application["arbolusuarios"];
                if (bin != null)
                {//cargar lista de contactos
                    inorder usuarios = new inorder(bin);
                    nodoinorder temp = usuarios.primero;
                    while (temp != null)
                    {
                        ddlusuarios.Items.Add(temp.user.getnick());
                        temp = temp.siguiente;
                    }
                }
            }
        }

        protected void graficar(object sender, EventArgs e)
        {
            String user = ddlusuarios.SelectedValue;
            binario bin = (binario)Application["arbolusuarios"];
            usuario jugador = bin.buscar(user, bin.raiz);
            String ruta = graficador.graficar(jugador.contactos);
            grafo.ImageUrl = "/grafos/contactos.dot.jpg";
        }

        protected void ddlusuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}