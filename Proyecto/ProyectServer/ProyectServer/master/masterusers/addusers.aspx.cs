using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectServer.master
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        actualizarusuarios userupdate;
        protected void Page_Load(object sender, EventArgs e)
        {
            userupdate = new actualizarusuarios();
        }

        protected void agregaruser(object sender,EventArgs e)
        {
            if (Application["arbolusuarios"] == null) Application["arbolusuarios"] = new binario();
            String nick = tbidnuevo.Text;
            String pass = tbpassnuevo.Text;
            String email = tbemail.Text;
            binario usertree = (binario)Application["arbolusuarios"];
            Application["arbolusuarios"] = userupdate.insertar(usertree, nick, email, 0, pass);//realizar la inserción en el arbol
        }
        
    }
}