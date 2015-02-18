<%@ MasterType VirtualPath="~/MasterAdmin.master" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true"
    CodeBehind="Zonas.aspx.cs"
    Inherits="Web2.Zonas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <asp:HiddenField ID="hdZonas" runat="server" />
    <asp:HiddenField ID="hdUsuarioId" runat="server" />

    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">Administración de zonas</h3>
        </div>
        <div class="panel-body">

            <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="form-group">                    
                    <div class="controls">
                        <div class="input-group">
                            
                            <input placeholder="Nombre de la zona" class="hidden form-control input-lg" id="txtNombreZona" data-bv-notempty="true" data-bv-notempty-message="El nombre es requerido." disabled />
                            <div class="input-group-btn">
                                <button type="button" class="btn btn-default btn-lg " id="btnEditarZona" style="display: none;">
                                    Editar Zona</button>
                                <button type="button" class="btn btn-success btn-lg" id="btnNuevaZona"><i class="fa fa-plus"></i>&nbsp; Agregar</button>
                                <button type="button" class="btn btn-danger btn-lg" id="btnEliminarZona" style="display: none;">
                                    Eliminar Zona</button>
                                <button type="button" class="btn btn-success btn-lg" id="btnGuardarZona" style="display: none;">
                                    Guardar</button>
                                <button type="button" class="btn btn-default btn-lg" id="btnCancelar" style="display: none;">
                                    Cancelar</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="col-lg-12 col-md-12 col-sm-12">
                <div id="map-canvas" style="height: 500px;"></div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false&libraries=drawing"></script>
    <script src="js/entidades.js" type="text/javascript"></script>
    <script src="js/zonas.js" type="text/javascript"></script>

    <script>
        $(document).ready(function () {
            $("#li_Zonas").addClass("active");
            $('#btnNuevaZona').click(function () {

                configurarNuevaZona();
                nuevaZona();
            });
            $('#btnEditarZona').click(function () {
                configurarEditarZona();
            });
            $('#btnGuardarZona').click(function () {
                guardarZona();

            });

            $('#btnCancelar').click(function () {
                configurarCancelarZona();
            });
            $('#btnEliminarZona').click(function () {
                Alerta_openModalConfirmacion("¿Desea eliminar la zona " + selectedShape.Nombre + " ?", "Elminar Zona", function () { eliminarZona() })
            });
        });
    </script>
</asp:Content>
