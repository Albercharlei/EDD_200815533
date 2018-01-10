using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectServer.master.userlogged
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        mainlogin wslogin;
        protected void Page_Load(object sender, EventArgs e)
        {
            wslogin = new mainlogin();
            wslogin.pruebauser();//cargar archivo de pruebas
        }

        protected void login(object sender, EventArgs e)
        {
            String id_ = tbnombreuser.Text;
            String pass_ = tbpassuser.Text;
            bool login = wslogin.Userlogin(id_, pass_);
            if(login == true)
            {
                binario usuarios = (binario)Application["arbolusuarios"];
                usuario user = usuarios.buscar(id_, usuarios.raiz);
                Session["user"] = user;//almacenar variable de sesion
                Response.Redirect("~/master/userlogged/userini.aspx");//cargar pagina de inicio
            }
        }
    }
}