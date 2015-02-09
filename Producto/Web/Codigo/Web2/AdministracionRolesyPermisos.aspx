<%@ Page Title="Geoparking - Administración Roles y Permisos" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AdministracionRolesyPermisos.aspx.cs" Inherits="Web2.AdministracionRolesyPermisos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <asp:HiddenField ID="hdPermisos" runat="server" />
    <asp:HiddenField ID="hdCrearRolValidacion" runat="server" />
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">Administración de Roles y Permisos</h3>
        </div>
        <div class="panel-body">
            <div class="container-fluid">
                <div class="col-md-4 col-md-offset-4" id="divCrearRol" runat="server">
                    <div class="page-header">
                        <h3 style="text-align: center;"><span class="glyphicon glyphicon-plus"></span> Crear Rol</h3>
                    </div>
                    <div class="form-group" id="valNombreRol">
                        <!--ABM Rol -->
                        <label id="lbltxtNombreRol" for="txtNombreRol" class="control-label">Nombre</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-align-justify"></i></span>
                            <input id="txtNombreRol" tabindex="1" placeholder="Nombre del Rol" name="txtNombreRol" class="form-control input-lg" oninput="javascript: CampoRequeridoNombre();" />
                            <i id="icontxtNombreRol" style="display: none" class="form-control-feedback" data-bv-icon-for="txtNombreRol"></i>
                        </div>
                        <small id="smalltxtNombreRol" class="help-block" style="display: none;" data-bv-validator="notEmpty" data-bv-icon-for="txtNombreRol" data-bv-result="INVALID">
                            <label id="errortxtNombreRol"></label>
                        </small>
                    </div>
                    <div class="form-group" id="valDescripcionRol">
                        <label id="lbltxtDescripcionRol" for="txtDescripcion" class="control-label">Descripción</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-info"></i></span>
                            <textarea id="txtDescripcionRol" placeholder="Descripcion del Rol" tabindex="2" name="txtDescripcionRol" class="form-control input-lg" oninput="javascript: CampoRequeridoDescripcion();"></textarea>
                            <i id="icontxtDescripcionRol" style="display: none" class="form-control-feedback" data-bv-icon-for="txtDescripcionRol"></i>
                        </div>
                        <small id="smalltxtDescripcionRol" class="help-block" style="display: none;" data-bv-validator="notEmpty" data-bv-icon-for="txtDescripcionRol" data-bv-result="INVALID">
                            <label id="errortxtDescripcionRol"></label>
                        </small>
                    </div>
                    <%--FIN ABMC ROL--%>
                </div>

                <div class="col-md-4 col-md-offset-4" id="divAsignarPermiso" runat="server">
                    <div class="page-header">
                        <h3 style="text-align: center;"><span class="glyphicon glyphicon-check"></span> Asignar Permisos a Rol</h3>
                    </div>
                    <div class="form-group">
                        <label for="ddlRol" class="control-label">Rol</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-list-ul"></i></span>
                            <asp:DropDownList ID="ddlRolPermisos" runat="server" CssClass="form-control required">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="ddlRol" class="control-label">Permisos</label>
                        <br />
                        <div>
                            <asp:CheckBoxList ID="cblPermiso" runat="server">
                            </asp:CheckBoxList>
                        </div>
                    </div>
                    <%--FIN Asignar Permisos a Rol--%>
                </div>

                <div class="col-md-4 col-md-offset-4" id="divAsignarRol" runat="server">
                    <div class="page-header">
                        <h3 style="text-align: center;"><span class="glyphicon glyphicon-transfer"></span> Asignar Rol a Usuario</h3>
                    </div>
                    <div class="form-group">
                        <label for="ddlUsuario" class="control-label">Usuario</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-list-ul"></i></span>
                            <asp:DropDownList ID="ddlUsuario" CssClass="form-control required" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="ddlRol" class="control-label">Rol</label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-list-ul"></i></span>
                            <asp:DropDownList ID="ddlRol" CssClass="form-control required" runat="server" />
                        </div>
                    </div>
                    <%--FIN Asignar Rol a Usuario--%>
                </div>

                <asp:Panel ID="panelBotones" class="col-md-12" runat="server">
                    <div id="divBotones" class="form-group col-md-4 col-md-offset-4">
                        <button type="button" class="btn btn-primary btn-md pull-left" id="btnGuardar">Guardar</button>
                        <button type="button" class="btn btn-md pull-right" id="btnCancelar">Cancelar</button>
                    </div>

                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="js/administracionRolesyPermisos.js" type="text/javascript"></script>
    <script src="js/irakValidator.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            if ($('#Main_divAsignarPermiso').is(":visible")) {
                cargarPermisosPorRol($("#Main_hdPermisos").val());
            }
            if ($('#Main_divAsignarRol').is(":visible")) {
                selectIndexchangedRolUsuario($("#Main_ddlUsuario").val());
            }
        });

        function CampoRequeridoNombre() {
            validarCampoVacio($('[id=valNombreRol]').attr("id"), $('[id=txtNombreRol]').attr("id"));
        }

        function CampoRequeridoDescripcion() {
            validarCampoVacio($('[id=valDescripcionRol]').attr("id"), $('[id=txtDescripcionRol]').attr("id"));
        }

        $("#<%=ddlRolPermisos.ClientID%>").change(function () {
            selectIndexchangedRolPermisos($("#Main_ddlRolPermisos").val());
        });

        $("#<%=ddlUsuario.ClientID%>").change(function () {
            selectIndexchangedRolUsuario($("#Main_ddlUsuario").val());
        });

        $('#btnGuardar').click(function () {

            if ($('#Main_divCrearRol').is(":visible")) {
                var val1 = validarCampoVacio($('[id=valDescripcionRol]').attr("id"), $('[id=txtDescripcionRol]').attr("id"));
                var val2 = validarCampoVacio($('[id=valNombreRol]').attr("id"), $('[id=txtNombreRol]').attr("id"));
                if (!validar2Campos(val1, val2)) {
                    crearRol(($('[id=txtNombreRol]').val()), ($('[id=txtDescripcionRol]').val()));
                    limpiarValidaciones();
                }
            }
            if ($('#Main_divAsignarPermiso').is(":visible")) {
                guardarRolPermisos($("#Main_ddlRolPermisos").val());
            }
            if ($('#Main_divAsignarRol').is(":visible")) {
                guardarRolUsuario(($("#Main_ddlUsuario").val()), ($("#Main_ddlRol").val()));
            }

        });

        $('#btnCancelar').click(function () {
            if ($('#Main_divCrearRol').is(":visible")) {
                $('[id=txtNombreRol]').val("");
                $('[id=txtDescripcionRol]').val("");
                limpiarValidaciones();
            }
            if ($('#Main_divAsignarPermiso').is(":visible"))
                selectIndexchangedRolPermisos($("#Main_ddlRolPermisos").val());
        });

    </script>
</asp:Content>
