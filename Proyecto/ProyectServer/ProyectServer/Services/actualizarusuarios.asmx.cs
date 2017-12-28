using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ProyectServer
{
    /// <summary>
    /// Summary description for actualizarusuarios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class actualizarusuarios : System.Web.Services.WebService
    {

        [WebMethod]
        public binario actualizar(usuario user_, String nick_, String pass_,binario bin_)
        {
            //user_.setnick(nick_);
            //user_.setpass(pass_);
            bin_.eliminar(user_.getnick());
            bin_.insertar(nick_, pass_, bin_.raiz);
            return bin_;
        }

        [WebMethod]
        public usuario buscar(binario bin_, String nick_)
        {
            return bin_.buscar(nick_, bin_.raiz);
        }

        [WebMethod]
        public binario insertar(binario bin_, String nick_, String pass_)
        {
            bin_.insertar(nick_, pass_, null);
            return bin_;
        }

        [WebMethod]
        public binario eliminar(binario bin_, String nick_)
        {
            bin_.eliminar(nick_);
            return bin_;
        }
    }
}
