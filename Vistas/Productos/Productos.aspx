<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Tarea_1_JosueAguirre.Vistas.Productos.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="container mt-4">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card shadow">
                    <div class="card-header bg-primary text-white">
                        <h3 class="mb-0">
                            <i class="fa fa-search"></i> Búsqueda de Productos  : <asp:Label ID="lblBienvenida" runat="server" CssClass="alert alert-info d-block mb-3"></asp:Label>
                        </h3>
                    </div>
                    <div class="card-body">
                        <div class="mb-3">
                            <label for="txtBuscar" class="form-label"><strong>Buscar producto:</strong></label>
                            <div class="input-group">
                                <span class="input-group-text"><i class="fa fa-search"></i></span>
                                <input type="text" id="txtBuscar"  placeholder="Escribe al menos 2 caracteres para buscar..."  class="form-control" autocomplete="off" />
                            </div>
                            <small class="form-text text-muted">Las sugerencias aparecerán automáticamente mientras escribes </small>
                        </div>
                        <!-- Lista de sugerencias -->
                        <div class="position-relative">
                            <ul id="sugerencias" 
                                class="list-group position-absolute w-100" 
                                style="z-index: 1050; display: none; max-height: 300px; overflow-y: auto;">
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Scripts -->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
   <script src="Productos2.js"></script>

</asp:Content>
