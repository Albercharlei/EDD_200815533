<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterjuegos/masterpartidas.Master" AutoEventWireup="true" CodeBehind="agregarunidades.aspx.cs" Inherits="ProyectServer.master.masterjuegos.WebForm6" %>
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
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/master/loginmaster.aspx" Text="Salir del sistema" Value="Salir del sistema"></asp:MenuItem>
        </Items>
    </asp:Menu>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <asp:Table runat="server">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Jugador: </asp:TableCell>
            <asp:TableCell runat="server"><asp:DropDownList runat="server" ID="ddluser"/></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Columna: </asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox runat="server" ID="tbcolumna" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Fila: </asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox runat="server" ID="tbfila" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Tipo: </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:DropDownList runat="server" ID="ddltipo">
                    <asp:ListItem runat="server" Text="Satélite" Value="Satelite" />
                    <asp:ListItem runat="server" Text="Bombardero" Value="Bombardero" />
                    <asp:ListItem runat="server" Text="Caza" Value="Caza" />
                    <asp:ListItem runat="server" Text="Helicóptero" Value="Helicoptero" />
                    <asp:ListItem runat="server" Text="Fragata" Value="Fragata" />
                    <asp:ListItem runat="server" Text="Crucero" Value="Crucero" />
                    <asp:ListItem runat="server" Text="Submarino" Value="Submarino" />
                </asp:DropDownList>
                <asp:Label runat="server" Text="Número: " /> <asp:TextBox runat="server" ID="tbno" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Destruido: </asp:TableCell>
            <asp:TableCell runat="server"><asp:DropDownList runat="server" ID="ddldestruido">
                <asp:ListItem runat="server" id="si" Text="Si" Value="0" /><asp:ListItem runat="server" id="no" Text="No" Value="1" />
                                          </asp:DropDownList></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Button runat="server" ID="btninsertar" Text="Cargar unidad al tablero" OnClick="insertar" />
    <asp:Label runat="server" ID="labelmensaje" />
</asp:Content>
