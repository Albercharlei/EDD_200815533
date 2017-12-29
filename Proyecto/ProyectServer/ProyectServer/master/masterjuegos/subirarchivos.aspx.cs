using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectServer.master.masterjuegos
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cargarlistajuegos(object sender, EventArgs e)
        {
            if (listajuegosup.HasFile)
            {
                String ruta = HttpContext.Current.Server.MapPath("~/cargas/") + listajuegosup.FileName;//obtener nombre de ruta
                listajuegosup.SaveAs(ruta);
                String entrada = File.ReadAllText(ruta);//leer texto
                //obtener cada línea del texto
                String[] lineas = entrada.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                //separa por comas
                binario bin = (binario)Application["arbolusuarios"];
                if(bin != null)
                {
                    for (int i = 1; i < lineas.Length; i++)
                    {
                        String[] contenido = lineas[i].Split(',');
                        //ingresar el contenido
                        try
                        {
                            bin.insertarjuego(contenido[0].ToString(), contenido[1].ToString(), Int32.Parse(contenido[2].ToString()), Int32.Parse(contenido[3].ToString()), Int32.Parse(contenido[4].ToString()), Int32.Parse(contenido[5].ToString()));
                        }
                        catch (IndexOutOfRangeException ex) { String outex = ex.ToString(); }
                    }
                    Application["arbolusuarios"] = bin;
                }
                
            }
        }
        //cargar juego actual
        protected void cargarjuego(object sender, EventArgs e)
        {
            if (juegoactualup.HasFile)
            {
                String ruta = HttpContext.Current.Server.MapPath("~/cargas/") + juegoactualup.FileName;//obtener nombre de ruta
                juegoactualup.SaveAs(ruta);
                String entrada = File.ReadAllText(ruta);//leer texto
                //obtener cada línea del texto
                String[] lineas = entrada.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                //obtener parámetros del juego
                String[] par = lineas[1].Split(',');
                //obtener tamaño del tablero
                int sizex = Int32.Parse(par[6].ToString());
                int sizey = Int32.Parse(par[7].ToString());
                int variante = Int32.Parse(par[8].ToString());
                //almacenar juego actual
                Application["tablero"] = new mo(sizex, sizey, variante, par[9].ToString());
                mo tab = (mo)Application["tablero"];//obtener el tablero de inserción
                tab.user1 = par[0].ToString();
                tab.user2 = par[1].ToString();
                tab.naves[0] = Int32.Parse(par[2].ToString());
                tab.naves[1] = Int32.Parse(par[3].ToString());
                tab.naves[2] = Int32.Parse(par[4].ToString());
                tab.naves[3] = Int32.Parse(par[5].ToString());
                Application["tablero"] = tab;//almacenar tablero actual
                labeluser1.Text = par[0].ToString();
                labeluser2.Text = par[1].ToString();
                labelunits1.Text = par[2].ToString();
                labelunits2.Text = par[3].ToString();
                labelunits3.Text = par[4].ToString();
                labelunits4.Text = par[5].ToString();
                if (par[8].ToString().Equals("1")) labeltipo.Text = "Normal";
                else if (par[8].ToString().Equals("2")) labeltipo.Text = "Tiempo";
                else if (par[8].ToString().Equals("3")) labeltipo.Text = "Base";
                labeltiempo.Text = par[9].ToString();
            }
        }
        //cargar tablero de juego
        protected void cargartablero(object sender, EventArgs e)
        {
            if (tableroup.HasFile)
            {
                String ruta = HttpContext.Current.Server.MapPath("~/cargas/") + tableroup.FileName;//obtener nombre de ruta
                tableroup.SaveAs(ruta);
                String entrada = File.ReadAllText(ruta);//leer texto
                //obtener cada línea del texto
                String[] lineas = entrada.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                //separa por comas
                mo tab = (mo)Application["tablero"];
                if (tab != null)
                {
                    for (int i = 1; i < lineas.Length; i++)
                    {
                        try
                        {
                            String[] contenido = lineas[i].Split(',');
                            String user = contenido[0].ToString();
                            String col = contenido[1].ToString();
                            int fila = Int32.Parse(contenido[2].ToString());
                            String id = contenido[3].ToString();
                            //ingresar el contenido
                            tab.insertar(col, fila, id, user);
                        }
                        catch (IndexOutOfRangeException ex) { String outex = ex.ToString(); }
                    }
                    Application["tablero"] = tab;
                }

            }
        }
    }
}