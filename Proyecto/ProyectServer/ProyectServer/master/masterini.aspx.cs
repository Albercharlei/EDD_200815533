using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectServer.master
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validarusuario();
        }
        public void validarusuario()
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("~/master/loginmaster.aspx");
            }
        }
    }
}