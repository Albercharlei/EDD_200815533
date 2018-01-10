<%@ Page Title="" Language="C#" MasterPageFile="~/master/userlogged/masteruser.Master" AutoEventWireup="true" CodeBehind="cargarcontactos.aspx.cs" Inherits="ProyectServer.master.userlogged.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titleplaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Menuplaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <asp:FileUpload runat="server" ID="fileup" />
    <asp:Table runat="server">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Cargar archivo de contactos</asp:TableCell>
            <asp:TableCell runat="server">
                <asp:Button runat="server" ID="btncarga" Text="Cargar archivo" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
