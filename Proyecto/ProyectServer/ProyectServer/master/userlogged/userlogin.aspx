<%@ Page Title="" Language="C#" MasterPageFile="~/master/userlogged/masteruser.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="ProyectServer.master.userlogged.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titleplaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Menuplaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <asp:Table runat="server">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Ingrese el nombre del usuario: </asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox runat="server" ID="tbnombreuser" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Ingrese la contraseña del usuario: </asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox runat="server" ID="tbpassuser" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"></asp:TableCell>
            <asp:TableCell runat="server"><asp:Button runat="server" ID="btlogin" Text="Ingresar al sistema" OnClick="login"/></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
