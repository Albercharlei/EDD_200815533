<%@ Page Title="" Language="C#" MasterPageFile="~/master/admin.Master" AutoEventWireup="true" CodeBehind="addusers.aspx.cs" Inherits="ProyectServer.master.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titleplaceholder" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Menuplaceholder" runat="server">
    <asp:Label Text="Menú de opciones"  runat="server"/>
    <div></div>
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
    <asp:Label runat="server" Text="Agregar un nuevo usuario al sistema" />
    <asp:Table runat="server">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Ingrese el nombre: </asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox runat ="server" ID="tbidnuevo" />
                <asp:RequiredFieldValidator ID="validarnombre" runat="server" ControlToValidate="tbidnuevo" ErrorMessage="Debe ingresar el nombre del nuevo usuario" BackColor="Red"/>
                    </asp:TableCell></asp:TableRow><asp:TableRow runat="server">
            <asp:TableCell runat="server">Ingrese la contraseña: </asp:TableCell><asp:TableCell runat="server"><asp:TextBox runat ="server" ID="tbpassnuevo" />
                <asp:RequiredFieldValidator ID="validarpass" runat="server" ControlToValidate="tbpassnuevo" ErrorMessage="Debe ingresar la contraseña del nuevo usuario" BackColor="Red"/>
                                                                                 </asp:TableCell></asp:TableRow><asp:TableRow runat="server">
            <asp:TableCell runat="server"></asp:TableCell><asp:TableCell runat="server"><asp:Button runat="server" Text="Completar el ingreso" id="btningresar" OnClick="agregaruser"/></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
