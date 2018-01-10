using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ProyectServer.master.masterusers
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["arbolusuarios"] == null) Application["arbolusuarios"] = new binario();
        }

        protected void cargar(object sender, EventArgs e)
        {
            if (fileup.HasFile)
            {
                String ruta = HttpContext.Current.Server.MapPath("~/cargas/") + fileup.FileName;//obtener nombre de ruta
                fileup.SaveAs(ruta);
                String entrada = File.ReadAllText(ruta);//leer texto
                //obtener cada línea del texto
                String[] lineas = entrada.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                //separa por comas
                binario bin = (binario)Application["arbolusuarios"];
                for (int i=1; i < lineas.Length; i++)
                {
                    String[] contenido = lineas[i].Split(',');
                    //ingresar el contenido
                    try
                    {
                        bin.insertar(contenido[0], contenido[1], contenido[2], Int32.Parse(contenido[3].ToString()), bin.raiz);
                    }
                    catch(IndexOutOfRangeException ex) { String outex = ex.ToString(); }
                }
                Application["arbolusuarios"] = bin;
            }
        }

        protected void cargarcontactos(object sender, EventArgs e)
        {
            if (contactosup.HasFile)
            {
                String ruta = HttpContext.Current.Server.MapPath("~/cargas/") + contactosup.FileName;//obtener nombre de ruta
                contactosup.SaveAs(ruta);
                String entrada = File.ReadAllText(ruta);//leer texto
                //obtener cada línea del texto
                String[] lineas = entrada.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                binario bin = (binario)Application["arbolusuarios"];//obtener el arbol de usuarios
                if (bin == null) bin = new binario();
                //separa por comas
                for (int i = 1; i < lineas.Length; i++)
                {
                    String[] contenido = lineas[i].Split(',');
                    //ingresar el contenido
                    try
                    {
                        String user = contenido[0].ToString();
                        String contacto = contenido[1].ToString();
                        String pass = contenido[2].ToString();
                        String email = contenido[3].ToString();

                        usuario userpadre = bin.buscar(user, bin.raiz);
                        if (userpadre.contactos == null) userpadre.contactos = new avl();
                        usuario nuevocontacto = bin.buscar(contacto, bin.raiz);
                        //si el nuevo contacto no existe, insertar el contacto en el arbol
                        if (nuevocontacto == null) nuevocontacto = bin.insertar(contacto, pass, email, 0, bin.raiz);
                        userpadre.insertarcontacto(nuevocontacto);
                    }
                    catch (IndexOutOfRangeException ex) { String outex = ex.ToString(); }
                }
                Application["arbolusuarios"] = bin;
            }
        }
    }
}