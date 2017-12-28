<%@ Page Title="" Language="C#" MasterPageFile="~/master/admin.Master" AutoEventWireup="true" CodeBehind="loginmaster.aspx.cs" Inherits="ProyectServer.master.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titleplaceholder" runat="server">
    <asp:Label Text="Ingrese los datos de inicio de sesión del administrador" runat="server"/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Menuplaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>Ingrese el nombre del administrador: </asp:TableCell>
            <asp:TableCell><asp:TextBox ID="tbiduser" runat="server" /></asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Ingrese la contraseña: </asp:TableCell><asp:TableCell><asp:TextBox ID="tbidpass" runat="server" TextMode="Password" /></asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell /><asp:TableCell><asp:Button ID ="btlogin" AutoPostBack="false" runat ="server" Text="Iniciar sesión" OnClick="click"/></asp:TableCell></asp:TableRow>
    </asp:Table></asp:Content>