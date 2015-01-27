<%@ Page Title="Geoparking - Administración Usuarios" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AdministracionUsuarios.aspx.cs" Inherits="Web2.AdministracionUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="formulario" data-bv-message="El valor es requerido" data-bv-feedbackicons-valid="glyphicon glyphicon-ok"
        data-bv-feedbackicons-invalid="glyphicon glyphicon-remove" data-bv-feedbackicons-validating="glyphicon glyphicon-refresh">
        <div class="jumbotron" style="margin-top: 5%;">
            <div class="container-fluid">
                <div class="col-md-4 col-md-offset-4" id="divCrearRol" runat="server">
                    <div class="page-header">
                        <h2 style="text-align: center;"><span class="fa fa-fw fa-child"></span>Crear Rol</h2>
                    </div>
                    <div class="form-group">
                        <!--ABM Rol -->
                        <label for="txtNombre" class="col-sm-2 col-md-2 col-lg-2 control-label">Nombre</label>
                        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" TabIndex="1" data-bv-notempty="true"
                            data-bv-notempty-message="El nombre es requerido." data-bv-regexp-regexp="^[a-zA-Z0-9_\.]+$"
                            data-bv-regexp-message="El nombre de usuario sólo puede consistir en alfabético, número, puntos o subrayados"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtDescripcion" class="col-sm-2 col-md-2 col-lg-2 control-label">Descripcion</label>
                        <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server" TabIndex="2"
                            data-bv-stringlength="true"
                            data-bv-stringlength-message="Introduzca un valor entre 5 y 100 caracteres."
                            data-bv-stringlength-min="5"
                            data-bv-stringlength-max="100" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <%--FIN ABMC ROL--%>
                </div>

                <div class="col-md-4 col-md-offset-4" id="divAsignarPermiso" runat="server">
                    <div class="page-header">
                        <h2 style="text-align: center;"><span class="glyphicon glyphicon-check"></span>Asignar Permisos a Rol</h2>
                    </div>
                    <div class="form-group">
                        <label for="ddlRol" class="col-sm-2 col-md-2 col-lg-2 control-label">Rol</label>
                        <asp:DropDownList ID="ddlRolPermisos" runat="server" CssClass="form-control required">
                        </asp:DropDownList>

                    </div>
                    <div class="form-group">
                        <label for="ddlRol" class="col-sm-2 col-md-2 col-lg-2 control-label">Permisos</label>
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
                        <h2 style="text-align: center;"><span class="glyphicon glyphicon-eye-open"></span>Asignar Rol a Usuario</h2>
                    </div>
                    <div class="form-group">

                        <label for="ddlUsuario" class="col-sm-2 col-md-2 col-lg-2 control-label">Usuario</label>
                        <asp:DropDownList ID="ddlUsuario" CssClass="form-control required" runat="server"
                            AutoPostBack="True" />
                    </div>
                    <div class="form-group">
                        <label for="ddlRol" class="col-sm-2 col-md-2 col-lg-2 control-label">Rol</label>
                        <asp:DropDownList ID="ddlRol" CssClass="form-control required" runat="server" AutoPostBack="True" />
                    </div>
                    <%--FIN Asignar Rol a Usuario--%>
                </div>

                <asp:Panel ID="panelBotones" class="col-md-12" runat="server">
                    <div id="divBotones" class="form-group col-md-4 col-md-offset-4">
                        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success btn-md pull-left" Text="Guardar" />
                        <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-md pull-right" Text="Cancelar"
                            AutoPostBack="True" />
                    </div>

                </asp:Panel>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script>

        $(document).ready(function () {
            $('.formulario').bootstrapValidator();
        });

    </script>
</asp:Content>
