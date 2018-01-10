using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectServer.master.userlogged
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //cargar historial de ataques
        protected void cargarhistorial(object sender, EventArgs e)
        {
            if (historialup.HasFile)
            {
                //obtener grado del arbol b
                int grado = Int32.Parse(tbgradohistorial.Text);
                //obtener parámetro de ordenamiento
                int tipo = ddlordenamientob.SelectedIndex;
                //establecer ruta
                String ruta = HttpContext.Current.Server.MapPath("~/cargas/") + historialup.FileName;//obtener nombre de ruta
                historialup.SaveAs(ruta);
                String entrada = File.ReadAllText(ruta);//leer texto
                //obtener cada línea del texto
                String[] lineas = entrada.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                //separa por comas
                arbolb arbol = (arbolb)Application["historial"];
                //crear arbol si no existe
                if (arbol == null) arbol = new arbolb(grado, tipo);
                for (int i = 1; i < lineas.Length; i++)
                {
                    try
                    {
                        String[] contenido = lineas[i].Split(',');
                        int x = Int32.Parse(contenido[0].ToString());//coordenada x
                        int y = Int32.Parse(contenido[1].ToString());//coordenada y
                        String id1 = contenido[2].ToString();//id de la primera unidad
                        int res = Int32.Parse(contenido[3].ToString());//int que identifica el resultado
                        String id2 = contenido[4].ToString();//id de la segunda unidad
                        String username1 = contenido[5].ToString();//nombre del usuario emisor
                        String username2 = contenido[6].ToString();//nombre del usuario receptor
                        DateTime fechain = DateTime.Parse(contenido[7].ToString());//convertir la fecha
                        DateTime restante = DateTime.ParseExact(contenido[8].ToString(), "mm:ss", System.Globalization.CultureInfo.InvariantCulture);//obtener el tiempo restante
                        int cont = Int32.Parse(contenido[9].ToString());//contador de registros
                        //crear unidades
                        unit atacante = new unit(id1, x, y);
                        atacante.user = username1;
                        unit defensor = new unit(id2, x, y);
                        defensor.user = username2;
                        //crear registro a insertar
                        ataque registro = new ataque(atacante, defensor, restante, cont);
                        registro.fecha = fechain;//asignar la fecha al registro
                        //agregar resultado
                        if (res == 0) registro.resultado = "Golpe";
                        else if (res == 1) registro.resultado = "Eliminación de objetivo";
                        //ingresar el registro
                        arbol.insertar(registro);
                    }
                    catch (IndexOutOfRangeException ex) { String outex = ex.ToString(); }
                }
                Application["historial"] = arbol;//almacenar la estructura
            }
        }
    }
}