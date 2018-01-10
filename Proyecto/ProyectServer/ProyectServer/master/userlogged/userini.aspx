<%@ Page Title="" Language="C#" MasterPageFile="~/master/userlogged/masteruser.Master" AutoEventWireup="true" CodeBehind="userini.aspx.cs" Inherits="ProyectServer.master.userlogged.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titleplaceholder" runat="server">
    Página principal de usuarios
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Menuplaceholder" runat="server">
    <asp:Menu ID="Menu1" runat="server">
    <Items>
        <asp:MenuItem Text="Contactos" Value="Contactos">
            <asp:MenuItem Text="Cargar archivo" Value="Cargar archivo" NavigateUrl="~/master/userlogged/cargarcontactos.aspx"></asp:MenuItem>
            <asp:MenuItem Text="Editar contactos" Value="Editar contactos"></asp:MenuItem>
            <asp:MenuItem Text="Mostrar contactos" Value="Mostrar contactos"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="Juego" Value="Juego">
            <asp:MenuItem Text="Empezar partida" Value="Empezar partida"></asp:MenuItem>
            <asp:MenuItem Text="Ver historial" Value="Ver historial"></asp:MenuItem>
            <asp:MenuItem Text="Cargar archivo de historial" Value="Cargar archivo de historial"></asp:MenuItem>
            <asp:MenuItem Text="Mostrar partida" Value="Mostrar partida"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="Cerrar sesión" Value="Cerrar sesión"></asp:MenuItem>
    </Items>
</asp:Menu>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
</asp:Content>
