using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectServer.master
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        mainlogin wslogin;

        protected void Page_Load(object sender, EventArgs e)
        {
            //cerrar sesión al cargar la página
            logout();
            if (Application["arbolusuarios"] == null)
            {
                binario arbolusuarios = new binario();
                Application["arbolusuarios"] = arbolusuarios;
            }
            wslogin = new mainlogin();
            //Application["arbolusuarios"] = wslogin.prueba();
        }

        protected void click(object sender, EventArgs e)
        {
            String id_ = tbiduser.Text;
            String pass_ = tbidpass.Text;
            bool login = wslogin.LogIn(id_, pass_);
            if (login == true)
            {
                Session["Admin"] = id_;
                Response.Redirect("~/master/masterini.aspx");
            }
        }
        //cerrar sesion
        public void logout()
        {
            if (Session["Admin"] != null)
            {
                Session["Admin"] = null;
            }
        }
    }
}