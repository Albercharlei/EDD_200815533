<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterusers/masterusers.Master" AutoEventWireup="true" CodeBehind="addusers.aspx.cs" Inherits="ProyectServer.master.WebForm2" %>
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
    <asp:Label runat="server" Text="Agregar un nuevo usuario al sistema" />
    <asp:Table runat="server">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Ingrese el nombre: </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox runat="server" ID="tbidnuevo" />
                <asp:RequiredFieldValidator ID="validarnombre" runat="server" ControlToValidate="tbidnuevo" ErrorMessage="Debe ingresar el nombre del nuevo usuario" BackColor="Red" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Ingrese el correo electrónico: </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox runat="server" ID="tbemail" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbemail" ErrorMessage="Debe ingresar el correo electrónico del nuevo usuario" BackColor="Red" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Ingrese la contraseña: </asp:TableCell><asp:TableCell runat="server">
                <asp:TextBox runat="server" ID="tbpassnuevo" />
                <asp:RequiredFieldValidator ID="validarpass" runat="server" ControlToValidate="tbpassnuevo" ErrorMessage="Debe ingresar la contraseña del nuevo usuario" BackColor="Red" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server"></asp:TableCell><asp:TableCell runat="server">
                <asp:Button runat="server" Text="Completar el ingreso" ID="btningresar" OnClick="agregaruser" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
