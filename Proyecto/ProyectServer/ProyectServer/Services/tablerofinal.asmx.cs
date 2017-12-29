using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ProyectServer
{
    /// <summary>
    /// Summary description for tablerofinal
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class tablerofinal : System.Web.Services.WebService
    {
        //obtener matriz con unidades sobrevivientes
        [WebMethod]
        public mo finalsobrevivientes(mo ingreso)
        {
            //crear tablero de retorno con las mismas caracteristicas
            mo ret = new mo(ingreso.sizex, ingreso.sizey, ingreso.variante, ingreso.tiempo);
            nivel templvl = ingreso.primero;
            //recorrer niveles
            while(templvl != null)
            {
                pos tempx = templvl.horizontal.primero;
                //recorrer columnas
                while(tempx != null)
                {
                    unit temp = tempx.primero;
                    while(temp != null)
                    {//insertar si aun existe en el tablero
                        if (temp.existe == 1)
                        {
                            String columna = ((char)(temp.x + 64)).ToString();//convertir coordenada a char y luego a string
                            ret.insertar(columna, temp.y, temp.id, temp.user, temp.existe);
                        }
                        temp = temp.abajo;
                    }
                    tempx = tempx.siguiente;
                }
                templvl = templvl.sup;
            }
            return ret;
        }
        //obtener matriz con unidades destruidas
        [WebMethod]
        public mo finaldestruidos(mo ingreso)
        {
            //crear tablero de retorno con las mismas caracteristicas
            mo ret = new mo(ingreso.sizex, ingreso.sizey, ingreso.variante, ingreso.tiempo);
            nivel templvl = ingreso.primero;
            //recorrer niveles
            while (templvl != null)
            {
                pos tempx = templvl.horizontal.primero;
                //recorrer columnas
                while (tempx != null)
                {
                    unit temp = tempx.primero;
                    while (temp != null)
                    {//insertar si aun existe en el tablero
                        if (temp.existe == 0)
                        {
                            String columna = ((char)(temp.x + 64)).ToString();//convertir coordenada a char y luego a string
                            ret.insertar(columna, temp.y, temp.id, temp.user, temp.existe);
                        }
                        temp = temp.abajo;
                    }
                    tempx = tempx.siguiente;
                }
                templvl = templvl.sup;
            }
            return ret;
        }
    }
}
