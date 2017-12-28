using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectServer.master
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        actualizarusuarios userupdate;
        protected void Page_Load(object sender, EventArgs e)
        {
            userupdate = new actualizarusuarios();
        }

        protected void buscar(object sender, EventArgs e)
        {
            if(Application["arbolusuarios"]!= null)
            {
                String busqueda = tbingreso.Text;
                usuario actual = userupdate.buscar((binario)Application["arbolusuarios"], busqueda);
                if(actual != null)
                {
                    tbnewname.Text = actual.getnick();
                    tbnewpass.Text = actual.getpass();
                    Application["actual"] = actual;//guardar el usuario actual
                }
                
            }
        }

        protected void actualizar(object sender, EventArgs e)
        {
            if(Application["arbolusuarios"] != null)
            {
                String nuevonombre = tbnewname.Text;
                String nuevopass = tbnewpass.Text;
                usuario actual = (usuario)Application["actual"];
                if(actual != null)
                {
                    binario bin = (binario)Application["arbolusuarios"];
                    bin = userupdate.actualizar(actual, nuevonombre, nuevopass, bin);
                    Application["actual"] = bin.buscar(nuevonombre, bin.raiz);
                    Application["arbolusuarios"] = bin;
                }
                
            }
            
        }

        protected void eliminar(object sender, EventArgs e)
        {
            if (Application["arbolusuarios"] != null)
            {
                String nick = tbnewname.Text;
                usuario actual = (usuario)Application["actual"];
                if(actual != null)
                {
                    binario bin = (binario)Application["arbolusuarios"];
                    bin = userupdate.eliminar(bin, nick);
                    Application["actual"] = null;
                    Application["arbolusuarios"] = bin;
                }
                
            }
        }
    }
}