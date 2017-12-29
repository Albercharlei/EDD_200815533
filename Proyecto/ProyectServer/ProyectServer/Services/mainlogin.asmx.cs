using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Drawing;

namespace ProyectServer
{
    /// <summary>
    /// Summary description for mainlogin
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class mainlogin : System.Web.Services.WebService
    {

        [WebMethod]
        public bool LogIn(String id, String pass)
        {
            if(id == "admin")
            {
                if (pass == "pass") return true;
            }
            return false;
        }

        [WebMethod]
        public binario prueba()
        {
            binario prueba = new binario();
            prueba.insertar("user3", "pass3", "email3", 0, prueba.raiz);
            prueba.insertar("user5", "pass5", "email5", 0, prueba.raiz);
            prueba.insertar("user1", "pass1", "email1", 0, prueba.raiz);
            prueba.insertar("user2", "pass2", "email2", 0, prueba.raiz);
            
            prueba.insertar("user4", "pass4", "email4", 0, prueba.raiz);

            usuario buscar1 = prueba.buscar("user1", prueba.raiz);
            buscar1.setnick("user1modificado");
            usuario buscar2 = prueba.buscar("user5", prueba.raiz);

            buscar1 = buscar2;
            buscar1.setnick("user5modificado");
            prueba.insertar("user4", "pass4", "email4", 0, prueba.raiz);
            //utilizar graficador
            graficarusuarios ugraph = new graficarusuarios();
            ugraph.graficar(prueba);
            return prueba;
        }

    }
}
