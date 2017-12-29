<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterjuegos/masterpartidas.Master" AutoEventWireup="true" CodeBehind="crearjuego.aspx.cs" Inherits="ProyectServer.master.masterjuegos.WebForm5" %>
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
            </asp:MenuItem>
            <asp:MenuItem Text="Juego" Value="Juego">
                <asp:MenuItem NavigateUrl="~/master/masterjuegos/crearjuego.aspx" Text="Crear juego nuevo" Value="Crear juego nuevo"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterjuegos/agregarunidades.aspx" Text="Agregar unidades al juego actual" Value="Agregar unidades al juego actual"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterjuegos/showtablero.aspx" Text="Mostrar tablero inicial" Value="Mostrar tablero inicial"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterjuegos/showsobrevivientes.aspx" Text="Mostrar unidades sobrevivientes" Value="Mostrar unidades sobrevivientes"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterjuegos/showdestruidos.aspx" Text="Mostrar unidades destruídas" Value="Mostrar unidades destruídas"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterjuegos/subirarchivos.aspx" Text="Cargar archivos" Value="Cargar archivos"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/master/loginmaster.aspx" Text="Salir del sistema" Value="Salir del sistema"></asp:MenuItem>
        </Items>
    </asp:Menu>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <asp:Table runat="server">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Jugador 1: </asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox runat="server" ID="tbjugador1"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Jugador 2: </asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox runat="server" ID="tbjugador2"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Tamaño de columnas: </asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox runat="server" ID="tbx"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Tamaño de filas: </asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox runat="server" ID="tby"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Tipo: </asp:TableCell>
            <asp:TableCell runat="server"><asp:DropDownList runat="server" ID="ddlvariante">
                <asp:ListItem runat="server" Text="Normal" Value="1" />
                <asp:ListItem runat="server" Text="Tiempo" Value="2" />
                <asp:ListItem runat="server" Text="Base" Value="3" />
                                          </asp:DropDownList></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Tiempo: </asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox runat="server" ID="tbtiempo"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Button runat="server" ID="btncrear" Text="Crear juego con los parámetros ingresados" OnClick="crearjuego" />
    <div />
    <asp:Label runat="server" ID="labelmensaje" />
</asp:Content>
