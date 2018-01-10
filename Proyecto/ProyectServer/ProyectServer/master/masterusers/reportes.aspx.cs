using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectServer.master.masterusers
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            binario bin = (binario)Application["arbolusuarios"];
            if(bin != null)
            {//obtener listado de usuarios
                inorder usuarios = new inorder(bin);
                topten ganadas = new topten(0);//top ten por unidades ganadas
                topten porcentaje = new topten(1);//top ten por porcentaje de unidades destruidas
                topten contactos = new topten(2);//top ten por cantidad de contactos
                topten cantidad = new topten(3);//top ten por cantidad de unidades destruidas
                nodoinorder tempinorder = usuarios.primero;
                while(tempinorder != null)
                {//insertar los elementos en los listados
                    ganadas.insertar(tempinorder);
                    porcentaje.insertar(tempinorder);
                    contactos.insertar(tempinorder);
                    cantidad.insertar(tempinorder);
                    tempinorder = tempinorder.siguiente;
                }
                //insertar los valores en las tablas
                int cont = 1;
                nodotopten temp = ganadas.primero;
                //crear fila de cabecera
                TableRow filahead = new TableRow();
                TableCell c1head = new TableCell();
                TableCell c2head = new TableCell();
                TableCell c3head = new TableCell();
                c1head.Text = "Posición";//agregar numero de usuario
                c2head.Text = "Nombre del jugador";//agregar nombre de usuario
                c3head.Text = "Cantidad de juegos ganados";//agregar cantidad de ganados
                filahead.Cells.Add(c1head);
                filahead.Cells.Add(c2head);
                filahead.Cells.Add(c3head);
                tablaganadas.Rows.Add(filahead);//agregar la fila a la tabla
                while (cont < 11)
                {//insertar usuarios en la tabla de unidades ganadas
                    if(temp != null)
                    {
                        TableRow fila = new TableRow();
                        TableCell c1 = new TableCell();
                        TableCell c2 = new TableCell();
                        TableCell c3 = new TableCell();
                        c1.Text = cont.ToString();//agregar numero de usuario
                        c2.Text = temp.user.getnick();//agregar nombre de usuario
                        c3.Text = temp.user.ganados.ToString();//agregar cantidad de ganados

                        fila.Cells.Add(c1);
                        fila.Cells.Add(c2);
                        fila.Cells.Add(c3);
                        tablaganadas.Rows.Add(fila);

                        cont++;
                        temp = temp.siguiente;
                    }
                    else break;//terminar el proceso si no hay mas elementos
                }

                //insertar los valores en las tablas
                cont = 1;
                temp = porcentaje.primero;
                //crear fila de cabecera
                TableRow filahead2 = new TableRow();
                TableCell c1head2 = new TableCell();
                TableCell c2head2 = new TableCell();
                TableCell c3head2 = new TableCell();
                c1head2.Text = "Posición";//agregar numero de usuario
                c2head2.Text = "Nombre del jugador";//agregar nombre de usuario
                c3head2.Text = "Porcentaje de unidades destruidas";//agregar porcentaje de unidades
                filahead2.Cells.Add(c1head2);
                filahead2.Cells.Add(c2head2);
                filahead2.Cells.Add(c3head2);
                tabladestruidas.Rows.Add(filahead2);//agregar la fila a la tabla
                while (cont < 11)
                {//insertar usuarios en la tabla de unidades ganadas
                    if (temp != null)
                    {
                        TableRow fila = new TableRow();
                        TableCell c1 = new TableCell();
                        TableCell c2 = new TableCell();
                        TableCell c3 = new TableCell();
                        c1.Text = cont.ToString();//agregar numero de usuario
                        c2.Text = temp.user.getnick();//agregar nombre de usuario
                        c3.Text = temp.user.porcentaje.ToString();//agregar porcentaje

                        fila.Cells.Add(c1);
                        fila.Cells.Add(c2);
                        fila.Cells.Add(c3);
                        tabladestruidas.Rows.Add(fila);

                        cont++;
                        temp = temp.siguiente;
                    }
                    else break;//terminar el proceso si no hay mas elementos
                }
                //tabla de contactos
                cont = 1;
                temp = contactos.primero;
                //crear fila de cabecera
                TableRow filahead3 = new TableRow();
                TableCell c1head3 = new TableCell();
                TableCell c2head3 = new TableCell();
                TableCell c3head3 = new TableCell();
                c1head3.Text = "Posición";//agregar numero de usuario
                c2head3.Text = "Nombre del jugador";//agregar nombre de usuario
                c3head3.Text = "Cantidad de contactos";//agregar porcentaje de unidades
                filahead3.Cells.Add(c1head3);
                filahead3.Cells.Add(c2head3);
                filahead3.Cells.Add(c3head3);
                tablacontactos.Rows.Add(filahead3);//agregar la fila a la tabla
                while (cont < 11)
                {//insertar usuarios en la tabla de unidades ganadas
                    if (temp != null)
                    {
                        TableRow fila = new TableRow();
                        TableCell c1 = new TableCell();
                        TableCell c2 = new TableCell();
                        TableCell c3 = new TableCell();
                        c1.Text = cont.ToString();//agregar numero de usuario
                        c2.Text = temp.user.getnick();//agregar nombre de usuario
                        c3.Text = temp.user.contactos.cont.ToString();//agregar porcentaje

                        fila.Cells.Add(c1);
                        fila.Cells.Add(c2);
                        fila.Cells.Add(c3);
                        tablacontactos.Rows.Add(fila);

                        cont++;
                        temp = temp.siguiente;
                    }
                    else break;//terminar el proceso si no hay mas elementos
                }
                //tabla por cantidad de unidades destruidas
                cont = 1;
                temp = cantidad.primero;
                //crear fila de cabecera
                TableRow filahead4 = new TableRow();
                TableCell c1head4 = new TableCell();
                TableCell c2head4 = new TableCell();
                TableCell c3head4 = new TableCell();
                c1head4.Text = "Posición";//agregar numero de usuario
                c2head4.Text = "Nombre del jugador";//agregar nombre de usuario
                c3head4.Text = "Cantidad de unidades destruidas";//agregar porcentaje de unidades
                filahead4.Cells.Add(c1head4);
                filahead4.Cells.Add(c2head4);
                filahead4.Cells.Add(c3head4);
                tablamasdestruidas.Rows.Add(filahead4);//agregar la fila a la tabla
                while (cont < 11)
                {//insertar usuarios en la tabla de unidades ganadas
                    if (temp != null)
                    {
                        TableRow fila = new TableRow();
                        TableCell c1 = new TableCell();
                        TableCell c2 = new TableCell();
                        TableCell c3 = new TableCell();
                        c1.Text = cont.ToString();//agregar numero de usuario
                        c2.Text = temp.user.getnick();//agregar nombre de usuario
                        c3.Text = temp.user.destruidos.ToString();//agregar porcentaje

                        fila.Cells.Add(c1);
                        fila.Cells.Add(c2);
                        fila.Cells.Add(c3);
                        tablamasdestruidas.Rows.Add(fila);

                        cont++;
                        temp = temp.siguiente;
                    }
                    else break;//terminar el proceso si no hay mas elementos
                }
            }
        }
    }
}