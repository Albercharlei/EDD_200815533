<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterjuegos/masterpartidas.Master" AutoEventWireup="true" CodeBehind="subirarchivos.aspx.cs" Inherits="ProyectServer.master.masterjuegos.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titleplaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Menuplaceholder" runat="server">
    <asp:Menu ID="Menu1" runat="server">
        <Items>
            <asp:MenuItem Text="Jugadores" Value="Jugadores">
                <asp:MenuItem NavigateUrl="~/master/masterusers/addusers.aspx" Text="Agregar jugadores" Value="Agregar jugadores"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterusers/updateusers.aspx" Text="Editar o eliminar jugadores" Value="Editar o eliminar jugadores"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterusers/showusers.aspx" Text="Ver árbol de jugadores" Value="Ver árbol de jugadores"></asp:MenuItem>
                <asp:MenuItem Text="Ver árbol espejo" Value="Ver árbol espejo" NavigateUrl="~/master/masterusers/showespejo.aspx"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterusers/cargarjugadores.aspx" Text="Cargar archivo de jugadores" Value="Cargar archivo de jugadores"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterusers/showcontactos.aspx" Text="Ver contactos" Value="Ver contactos"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterusers/hash.aspx" Text="Diccionario de contactos" Value="Diccionario de contactos"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterusers/reportes.aspx" Text="Reportes" Value="Reportes"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="Juego" Value="Juego">
                <asp:MenuItem NavigateUrl="~/master/masterjuegos/crearjuego.aspx" Text="Crear juego nuevo" Value="Crear juego nuevo"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterjuegos/agregarunidades.aspx" Text="Agregar unidades al juego actual" Value="Agregar unidades al juego actual"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterjuegos/showtablero.aspx" Text="Mostrar tablero inicial" Value="Mostrar tablero inicial"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterjuegos/showsobrevivientes.aspx" Text="Mostrar unidades sobrevivientes" Value="Mostrar unidades sobrevivientes"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterjuegos/showdestruidos.aspx" Text="Mostrar unidades destruídas" Value="Mostrar unidades destruídas"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterjuegos/subirarchivos.aspx" Text="Cargar archivos" Value="Cargar archivos"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterjuegos/historial.aspx" Text="Mostrar historial" Value="Mostrar historial"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterjuegos/reportes.aspx" Text="Reportes de juegos" Value="Reportes de juegos"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/master/loginmaster.aspx" Text="Salir del sistema" Value="Salir del sistema"></asp:MenuItem>
        </Items>
    </asp:Menu>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    
    <asp:Table runat="server" BorderWidth="1">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Seleccionar archivo de juego actual</asp:TableCell>
            <asp:TableCell runat="server">
                <asp:FileUpload ID="juegoactualup" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" />
            <asp:TableCell runat="server">
                <asp:Button runat="server" ID="btnjuego" Text="Cargar archivo de juego" OnClick="cargarjuego" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <div>Información del juego actual: </div>
    <asp:Table runat="server" BorderColor="Black" BorderWidth="1" GridLines="Both">
        <asp:TableHeaderRow runat="server">
            <asp:TableCell runat="server">Jugador 1</asp:TableCell>
            <asp:TableCell runat="server">Jugador 2</asp:TableCell>
            <asp:TableCell runat="server">Unidades del primer nivel</asp:TableCell>
            <asp:TableCell runat="server">Unidades del segundo nivel</asp:TableCell>
            <asp:TableCell runat="server">Unidades del tercer nivel</asp:TableCell>
            <asp:TableCell runat="server">Unidades del cuarto nivel</asp:TableCell>
            <asp:TableCell runat="server">Tipo</asp:TableCell>
            <asp:TableCell runat="server">Tiempo</asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label runat="server" ID="labeluser1" /></asp:TableCell>
            <asp:TableCell runat="server"><asp:Label runat="server" ID="labeluser2" /></asp:TableCell>
            <asp:TableCell runat="server"><asp:Label runat="server" ID="labelunits1" /></asp:TableCell>
            <asp:TableCell runat="server"><asp:Label runat="server" ID="labelunits2" /></asp:TableCell>
            <asp:TableCell runat="server"><asp:Label runat="server" ID="labelunits3" /></asp:TableCell>
            <asp:TableCell runat="server"><asp:Label runat="server" ID="labelunits4" /></asp:TableCell>
            <asp:TableCell runat="server"><asp:Label runat="server" ID="labeltipo" /></asp:TableCell>
            <asp:TableCell runat="server"><asp:Label runat="server" ID="labeltiempo" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <div></div>
    
    <asp:Table runat="server" BorderWidth="1">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Seleccionar archivo de tablero de juego</asp:TableCell>
            <asp:TableCell runat="server">
                <asp:FileUpload ID="tableroup" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"></asp:TableCell>
            <asp:TableCell runat="server"><asp:Button runat="server" ID="btntablero" Text="Cargar archivo de tablero" OnClick="cargartablero" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    <div></div>
    
    <asp:Table runat="server" BorderWidth="1">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Seleccionar archivo de listas de juegos</asp:TableCell>
            <asp:TableCell runat="server">
                <asp:FileUpload ID="listajuegosup" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"></asp:TableCell>
            <asp:TableCell runat="server"><asp:Button runat="server" ID="btnlista" Text="Cargar archivo" OnClick="cargarlistajuegos"/></asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <div></div>
    
    <asp:Table runat="server" BorderWidth ="1">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Seleccionar archivo de historial de ataques</asp:TableCell>
            <asp:TableCell runat="server"><asp:FileUpload ID="historialup" runat="server" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Ingrese el grado del árbol: </asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox runat="server" ID="tbgradohistorial" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Ingrese tipo de ordenamiento: </asp:TableCell>
            <asp:TableCell runat="server"><asp:DropDownList runat="server" ID="ddlordenamientob">
                <asp:ListItem runat="server" Text="Por fecha"></asp:ListItem>
                <asp:ListItem runat="server" Text="Por número de ataque"></asp:ListItem>
                                          </asp:DropDownList></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"></asp:TableCell>
            <asp:TableCell runat="server">
                <asp:Button runat="server" ID="btnhistorial" Text="Cargar archivo de historial" OnClick="cargarhistorial"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <div></div>
</asp:Content>
