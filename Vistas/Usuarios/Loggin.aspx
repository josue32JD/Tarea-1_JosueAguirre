<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Loggin.aspx.cs" Inherits="Tarea_1_JosueAguirre.Vistas.Usuarios.Loggin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h2>Iniciar Sesión</h2>
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label><br />


    <asp:TextBox ID="txtUsuario" runat="server" Placeholder="Usuario"></asp:TextBox><br /><br />
    <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" Placeholder="Contraseña"></asp:TextBox><br /><br />
    
    <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" CssClass="btn btn-primary" /><br /><br />
   <%-- 
    <!-- Botón para ir a registro -->
    <asp:Button ID="btnRegistro" runat="server" Text="Registrarse" OnClick="btnRegistro_Click" CssClass="btn btn-secondary" />--%>

     <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>
