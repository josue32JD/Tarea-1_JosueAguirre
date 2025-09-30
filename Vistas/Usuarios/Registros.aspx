<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registros.aspx.cs" Inherits="Tarea_1_JosueAguirre.Vistas.Usuarios.Registros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container mt-4">
        <h2>Registro de Usuario</h2>
        
        <!-- Mensajes de error o éxito -->
        <asp:Label ID="lblError" runat="server" ForeColor="Red" CssClass="d-block mb-2"></asp:Label>
        <asp:Label ID="lblExito" runat="server" ForeColor="Green" CssClass="d-block mb-2"></asp:Label>
        
        <div>
            <!--Nombre complero-->
            <div class="form-group mb-3">
                <asp:Label ID="lbNombre" runat="server" Text="Nombre Completo" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="Ingrese su nombre completo"></asp:TextBox>
            </div>

            <!--Correo-->
            <div class="form-group mb-3">
                <asp:Label ID="lbCorreo" runat="server" Text="Correo Electrónico" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" TextMode="Email" ClientIDMode="Static" placeholder="correo@ejemplo.com"></asp:TextBox>
            </div>

            <!--Telefono-->
            <div class="form-group mb-3">
                <asp:Label ID="lbTelefono" runat="server" Text="Número de Teléfono" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="88221412"></asp:TextBox>
            </div>

            <!--Nombre de usuario-->
            <div class="form-group mb-3">
                <asp:Label ID="lbUsuario" runat="server" Text="Nombre de Usuario" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="usuario123"></asp:TextBox>
            </div>

            <!--Contra-->
            <div class="form-group mb-3">
                <asp:Label ID="lbContraseña" runat="server" Text="Contraseña" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control" TextMode="Password" ClientIDMode="Static" placeholder="Mínimo 8 caracteres"></asp:TextBox>
            </div>

            <!--Confirmar contra-->
            <div class="form-group mb-3">
                <asp:Label ID="lbConfirmar" runat="server" Text="Confirmar Contraseña" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtConfirmar" runat="server" CssClass="form-control" TextMode="Password" ClientIDMode="Static" placeholder="Repita su contraseña"></asp:TextBox>
            </div>

            <!--Fecha-->
            <div class="form-group mb-3">
                <asp:Label ID="lbFecha" runat="server" Text="Fecha de Nacimiento" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" TextMode="Date" ClientIDMode="Static"></asp:TextBox>
                <small class="form-text text-muted">Debes ser mayor de 18 años</small>
            </div>

            <!--Terminos-->
            <div class="form-check mb-3">
                <asp:CheckBox ID="checkTerminos" runat="server" CssClass="form-check-input" ClientIDMode="Static"></asp:CheckBox>
                <asp:Label ID="lbTerminos" runat="server" Text="Acepto los términos y condiciones" CssClass="form-check-label" AssociatedControlID="checkTerminos"></asp:Label>
            </div>

            <!--Boton de registro de usuarios-->
            <div class="mb-3">
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary btn-lg" OnClick="btnRegistrar_Click" ClientIDMode="Static" />
            </div>
        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="ValidacionesUsuarios2.js?v=1.1"></script>
</asp:Content>