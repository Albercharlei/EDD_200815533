<%@ Page Title="" Language="C#" MasterPageFile="~/master/admin.Master" AutoEventWireup="true" CodeBehind="updateusers.aspx.cs" Inherits="ProyectServer.master.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titleplaceholder" runat="server">
    <asp:Label Text="" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Menuplaceholder" runat="server">
    <asp:Menu ID="Menu1" runat="server">
        <Items>
            <asp:MenuItem Text="Jugadores" Value="Jugadores">
                <asp:MenuItem NavigateUrl="~/master/addusers.aspx" Text="Agregar jugadores" Value="Agregar jugadores"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/updateusers.aspx" Text="Editar o eliminar jugadores" Value="Editar o eliminar jugadores"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/showusers.aspx" Text="Ver árbol de jugadores" Value="Ver árbol de jugadores"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/master/juego.aspx" Text="Partida" Value="Partida"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/master/loginmaster.aspx" Text="Salir del sistema" Value="Salir del sistema"></asp:MenuItem>
        </Items>
    </asp:Menu>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <asp:Table runat="server">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label Text="Ingrese el nombre del usuario: " runat="server" /></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox runat="server" ID="tbingreso" /></asp:AccessDataSource></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Button runat="server" ID="botonbusqueda" Text="Buscar al usuario" OnClick="buscar"/>
    <div />
    <asp:Table runat="server">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label Text="Nombre del usuario: " runat="server" /></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox runat="server" ID="tbnewname" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Label Text="Contraseña: " runat="server" /></asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox runat="server" ID="tbnewpass" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"><asp:Button runat="server" ID="botonactualizar" Text="Actualizar datos del jugador" OnClick="actualizar"/></asp:TableCell>
            <asp:TableCell runat="server"><asp:Button runat="server" ID="Button1" Text="Eliminar jugador" OnClick="eliminar"/></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
</asp:Content>
