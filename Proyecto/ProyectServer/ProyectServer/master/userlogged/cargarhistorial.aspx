<%@ Page Title="" Language="C#" MasterPageFile="~/master/userlogged/masteruser.Master" AutoEventWireup="true" CodeBehind="cargarhistorial.aspx.cs" Inherits="ProyectServer.master.userlogged.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titleplaceholder" runat="server">
    Cargar archivo de historial
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Menuplaceholder" runat="server">
    <asp:Table runat="server">
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
</asp:Content>
