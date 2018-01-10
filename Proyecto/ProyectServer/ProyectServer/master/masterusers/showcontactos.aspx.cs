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
        actualizarusuarios userupdate;
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
            userupdate = new actualizarusuarios();
        }

        protected void graficar(object sender, EventArgs e)
        {
            String user = ddlusuarios.SelectedValue;
            binario bin = (binario)Application["arbolusuarios"];
            if (bin != null)
            {
                usuario jugador = bin.buscar(user, bin.raiz);
                if (jugador != null)
                {
                    String ruta = graficador.graficar(jugador.contactos);
                    grafo.ImageUrl = "/grafos/contactos.dot.jpg";
                }
            }
        }

        protected void ddlusuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void insertar(object sender, EventArgs e)
        {
            if (Application["arbolusuarios"] == null) Application["arbolusuarios"] = new binario();
            String usuarioactual = ddlusuarios.SelectedValue;
            String nick = tbidnuevo.Text;
            String pass = tbpassnuevo.Text;
            String email = tbemail.Text;
            binario usertree = (binario)Application["arbolusuarios"];
            usuario user = usertree.buscar(usuarioactual, usertree.raiz);
            //buscar contacto a insertar
            usuario contacto = usertree.buscar(nick, usertree.raiz);
            //crear el usuario si no existe
            if (contacto == null) contacto = usertree.insertar(nick, pass, email, 0, usertree.raiz);
            user.insertarcontacto(contacto);
            //almacenar el arbol
            Application["arbolusuarios"] = usertree;
        }
    }
}