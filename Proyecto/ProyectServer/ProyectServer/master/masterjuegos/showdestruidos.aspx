﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterjuegos/masterpartidas.Master" AutoEventWireup="true" CodeBehind="showdestruidos.aspx.cs" Inherits="ProyectServer.master.masterjuegos.WebForm4" %>
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
                <asp:MenuItem NavigateUrl="~/master/masterjuegos/showsobrevivientes.aspx" Text="Mostrar unidades sobrevivientes" Value="Mostrar unidades sobrevivientes"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/master/masterjuegos/showdestruidos.aspx" Text="Mostrar unidades destruídas" Value="Mostrar unidades destruídas"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/master/loginmaster.aspx" Text="Salir del sistema" Value="Salir del sistema"></asp:MenuItem>
        </Items>
    </asp:Menu>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <asp:Label runat="server" Text="Nivel 1" Font-Size="14" />
    <asp:Image ID="lvl1" runat="server" />
    <div />
    <asp:Label runat="server" Text="Nivel 2" Font-Size="14" />
    <asp:Image ID="lvl2" runat="server" />
    <div />
    <asp:Label runat="server" Text="Nivel 3" Font-Size="14" />
    <asp:Image ID="lvl3" runat="server" />
    <div />
    <asp:Label runat="server" Text="Nivel 4" Font-Size="14" />
    <asp:Image ID="lvl4" runat="server" />
</asp:Content>