<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarPerfil.aspx.cs" Inherits="Tarea_1_JosueAguirre.Vistas.Usuarios.EditarPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card shadow">
                    <div class="card-header bg-primary text-white">
                        <h3>Editar Perfil</h3>
                    </div>
                    <div class="card-body">
                        <asp:Label ID="lblMensaje" runat="server" CssClass="alert d-none" ClientIDMode="Static"></asp:Label>

                        <!-- Nombre -->
                        <div class="mb-3">
                            <asp:Label ID="lbNombre" runat="server" Text="Nombre"></asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>

                        <!-- Correo -->
                         <asp:Label ID="lblError" runat="server" ForeColor="Red" CssClass="d-block mb-2"></asp:Label>
                        <div class="mb-3">
                            <asp:Label ID="lbCorreo" runat="server" Text="Correo"></asp:Label>
                            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" TextMode="Email" ClientIDMode="Static"></asp:TextBox>
                        </div>

                        <!-- Teléfono -->
                        <div class="mb-3">
                            <asp:Label ID="lbTelefono" runat="server" Text="Teléfono"></asp:Label>
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>

                        <!-- Contraseña -->
                        <div class="mb-3">
                            <asp:Label ID="lbContrasena" runat="server" Text="Contraseña"></asp:Label>
                            <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" TextMode="Password" ClientIDMode="Static"></asp:TextBox>
                        </div>

                        <!-- Confirmar Contraseña -->
                        <div class="mb-3">
                            <asp:Label ID="lbConfirmar" runat="server" Text="Confirmar Contraseña"></asp:Label>
                            <asp:TextBox ID="txtConfirmar" runat="server" CssClass="form-control" TextMode="Password" ClientIDMode="Static"></asp:TextBox>
                        </div>

                        <br />
                        <!-- Botón Guardar -->
                        <button id="btnGuardar" class="btn btn-success w-100">Guardar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="EditarPerfil2.js"></script>

</asp:Content>
