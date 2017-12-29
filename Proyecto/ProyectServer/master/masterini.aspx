﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master/admin.Master" AutoEventWireup="true" CodeBehind="masterini.aspx.cs" Inherits="ProyectServer.master.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titleplaceholder" runat="server">
    <asp:Label Text="Bienvenido al sistema, seleccione una opción del menú lateral" runat="server"/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Menuplaceholder" runat="server">
    <asp:Menu ID="Menu1" runat="server">
        <Items>
            <asp:MenuItem Text="Jugadores" Value="Jugadores">
                <asp:MenuItem NavigateUrl="~/master/masterusers/addusers.aspx" Text="Agregar jugadores" Value="Agregar jugadores"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterusers/updateusers.aspx" Text="Editar o eliminar jugadores" Value="Editar o eliminar jugadores"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterusers/showusers.aspx" Text="Ver árbol de jugadores" Value="Ver árbol de jugadores"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterusers/cargarjugadores.aspx" Text="Cargar archivo de jugadores" Value="Cargar archivo de jugadores"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="Juego" Value="Juego">
                <asp:MenuItem NavigateUrl="~/master/masterjuegos/subirarchivos.aspx" Text="Cargar archivos" Value="Cargar archivos"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterjuegos/showtablero.aspx" Text="Mostrar tablero" Value="Mostrar tablero"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/master/loginmaster.aspx" Text="Salir del sistema" Value="Salir del sistema"></asp:MenuItem>
        </Items>
    </asp:Menu>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
</asp:Content>
