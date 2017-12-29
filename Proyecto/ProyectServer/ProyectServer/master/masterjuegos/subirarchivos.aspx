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
            </asp:MenuItem>
            <asp:MenuItem Text="Juego" Value="Juego">
                <asp:MenuItem NavigateUrl="~/master/masterjuegos/subirarchivos.aspx" Text="Cargar archivos" Value="Cargar archivos"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterjuegos/showtablero.aspx" Text="Mostrar tablero inicial" Value="Mostrar tablero inicial"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterjuegos/showtablerofinal.aspx" Text="Mostrar tableros finales" Value="Mostrar tableros finales"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/master/loginmaster.aspx" Text="Salir del sistema" Value="Salir del sistema"></asp:MenuItem>
        </Items>
    </asp:Menu>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <asp:FileUpload ID="juegoactualup" runat="server" />
    <asp:Table runat="server">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Cargar archivo de juego actual</asp:TableCell>
            <asp:TableCell runat="server">
                <asp:Button runat="server" ID="btnjuego" Text="Seleccionar archivo" OnClick="cargarjuego" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
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
    <div />
    <asp:FileUpload ID="tableroup" runat="server" />
    <asp:Table runat="server">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Cargar archivo de tablero de juego</asp:TableCell>
            <asp:TableCell runat="server">
                <asp:Button runat="server" ID="btntablero" Text="Seleccionar archivo" OnClick="cargartablero" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    <div />
    <asp:FileUpload ID="listajuegosup" runat="server" />
    <asp:Table runat="server">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Cargar archivo de lista de juegos</asp:TableCell>
            <asp:TableCell runat="server">
                <asp:Button runat="server" ID="btnlista" Text="Seleccionar archivo" OnClick="cargarlistajuegos"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <div></div>
</asp:Content>
